using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using IronPython.Hosting;

namespace Aplikacja
{
    
    public partial class Form1 : Form
    {
        Pipe myPipe;
        Process python;
        string availableNotes="";
        string fileName;
        string outputFile;
        bool mode = false;
        bool cudaReady = false;
        public Form1()
        {
            InitializeComponent();
            StartPython();
            myPipe = new Pipe();
            //Thread t = new Thread(myPipe.StartConnection);
            //t.Start();
            myPipe.StartConnection();
            generateFromComboBox.SelectedIndex = 0;
            timeSpaceComboBox.SelectedIndex = 0;
            progressBar1.SetState(3);
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (mode == false)
            {                
                if (myPipe.dataIsNew)
                {
                    availableNotes = myPipe.data.ToString();
                    notesCountLabel.Text = notesCountLabel.Text + "(max " + availableNotes + ")";
                    notesCountNumeric.Maximum = Convert.ToDecimal(availableNotes);
                    myPipe.dataIsNew = false;
                    timer1.Enabled = false;
                    mode = true;                    
                }
            }
            else
            {
                if (!cudaReady)
                {
                    if (myPipe.dataIsNew)
                    {
                        progressBar1.Value = myPipe.data*500;
                        cudaReady = true;
                    }
                }
                else
                {
                    progressBar1.Visible = true;
                    myPipe.AsyncRead();
                    if (myPipe.dataIsNew == true)
                    {
                        progressBar1.Value = myPipe.data;
                        myPipe.dataIsNew = false;
                        if (progressBar1.Value == progressBar1.Maximum)
                        {
                            progressBar1.Refresh();
                            progressBar1.Visible = false;
                            timer1.Enabled = false;
                            MessageBox.Show("File generation complete!");
                            resetButton.Enabled = true;
                            playButton.Enabled = true;

                        }
                    }
                }
            }
        }
        private void addButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.Title = "Select your .mid file";
            fd.Filter = "MIDI Files (*.mid)|*.mid|All Files (*.*)|*.*";
            DialogResult dr = fd.ShowDialog();
            if (dr == DialogResult.OK)
            {
                fileName = fd.FileName;
                seedLabel.Text =  fileName.Split('\\').Last();
                seedLabel.Visible = true;
            }
        }

        private void applyButton_Click(object sender, EventArgs e)
        {

            if (generateFromComboBox.Text == "Built-in library")
            {
                myPipe.WriteMessage("From library");
                mode = true;
                timeSpaceComboBox.Items.RemoveAt(0);
                timeSpaceComboBox.SelectedIndex = 0;
            }
            else
            {
                if (fileName != null)
                {                    
                    myPipe.WriteMessage(fileName);                    
                    timer1.Enabled = true;
                    backgroundWorker1.RunWorkerAsync();
                    //myPipe.AsyncRead();
                }
                else
                {
                    MessageBox.Show("Please select seed file first!");
                    return;
                }
            }
            generateCountNumeric.Enabled = true;
            notesCountNumeric.Enabled = true;
            offsetFirstParamNumeric.Enabled = true;
            offsetSecondParamNumeric.Enabled = true;
            timeSpaceComboBox.Enabled = true;
            generateButton.Enabled = true;

            addButton.Enabled = false;
            applyButton.Enabled = false;
            generateFromComboBox.Enabled = false;

        }

        private void generateButton_Click(object sender, EventArgs e)
        {           
            SaveFileDialog sd = new SaveFileDialog();
            sd.Title = "Save your .mid file";
            sd.Filter = "MIDI Files (*.mid)|*.mid|All Files (*.*)|*.*";
            DialogResult dr = sd.ShowDialog();
            if (dr == DialogResult.OK)
            {
                outputFile = sd.FileName;

                string myMessage = notesCountNumeric.Value.ToString() + " " + generateCountNumeric.Value.ToString();
                if (timeSpaceComboBox.Text == "Average from seed")
                    myMessage += " 0 0 0 "+outputFile;
                else if (timeSpaceComboBox.Text == "Given value")
                    myMessage += " 1 " + offsetFirstParamNumeric.Value.ToString() + " 0 "+outputFile;
                else
                    myMessage += " 2 " + offsetFirstParamNumeric.Value.ToString() + " " + offsetSecondParamNumeric.Value.ToString()+" "+outputFile;
                myPipe.WriteMessage(myMessage);
                timer1.Enabled = true;
                progressBar1.Maximum = ((int)generateCountNumeric.Value - 1);               
                generateButton.Enabled = false;
                generateCountNumeric.Enabled = false;
                notesCountNumeric.Enabled = false;
                timeSpaceComboBox.Enabled = false;
                offsetFirstParamNumeric.Enabled = false;
                offsetSecondParamNumeric.Enabled = false;
                
                backgroundWorker1.RunWorkerAsync();
            }          
        }

        private void playButton_Click(object sender, EventArgs e)
        {
            OpenWithDefaultProgram(outputFile);
        }

        private void offsetFirstParamNumeric_ValueChanged(object sender, EventArgs e)
        {           
            if (timeSpaceComboBox.Text != "Average from seed")
            {             
                offsetSecondParamNumeric.Minimum = offsetFirstParamNumeric.Value + 0.1m;
                offsetSecondParamNumeric.Value = offsetFirstParamNumeric.Value + 0.1m;

            }

        }

        private void timeSpaceComboBox_TextChanged(object sender, EventArgs e)
        {
            if(timeSpaceComboBox.Text == "Average from seed")
            {
                offsetFirstParamNumeric.Visible = false;
                offsetSecondParamNumeric.Visible = false;
                firstOffsetLabel.Visible = false;
                secondOffsetLabel.Visible = false;
            }
            else if(timeSpaceComboBox.Text == "Given value")
            {
                offsetFirstParamNumeric.Visible = true;
                offsetSecondParamNumeric.Visible = false;
                firstOffsetLabel.Visible = true;
                secondOffsetLabel.Visible = false;
                firstOffsetLabel.Text = "Offset:";
            }
            else
            {
                offsetFirstParamNumeric.Visible = true;
                offsetSecondParamNumeric.Visible = true;
                firstOffsetLabel.Visible = true;
                secondOffsetLabel.Visible = true;
                firstOffsetLabel.Text = "Random min value:";
            }
        }

        private void generateFromComboBox_TextChanged(object sender, EventArgs e)
        {
            if(generateFromComboBox.Text != "Seed file")
            {
                addButton.Enabled = false;
                seedLabel.Text = "";
            }
            else
            {
                addButton.Enabled = true;
                seedLabel.Visible = false;
            }
        }
        private void StartPython()
        {
            string path = Directory.GetCurrentDirectory();
            path = path.Substring(0,path.Length - 9);
            path = path + "Classical-Piano-Composer-master";
            string strCmdText = "/k C:\\ProgramData\\Anaconda3\\Scripts\\activate NewNeural&cd "+path+"&python predictApplication.py";
            python = new Process();
            python.StartInfo.FileName = "CMD.exe";
            python.StartInfo.Arguments = strCmdText;
            python.StartInfo.WindowStyle = ProcessWindowStyle.Minimized;
            python.Start();          
        }
        private void OpenWithDefaultProgram(string path)
        {
            Process fileopener = new Process();

            fileopener.StartInfo.FileName = "explorer";
            fileopener.StartInfo.Arguments = "\"" + path + "\"";
            fileopener.Start();
        }


        private void resetButton_Click(object sender, EventArgs e)
        {
            mode = false;
            generateFromComboBox.Enabled = true;
            addButton.Enabled = true;
            timer1.Enabled = false;
            notesCountLabel.Text = "Seed notes count:";
            resetButton.Enabled = false;
            applyButton.Enabled = true;
            progressBar1.Value = 0;
            
            progressBar1.Refresh();
            progressBar1.Update();
            progressBar1.Visible = false;
            playButton.Enabled = false;
            if (generateFromComboBox.Text == "Built-in library")
            {
                timeSpaceComboBox.Items.Insert(0, "Average from seed");
                timeSpaceComboBox.SelectedIndex = 0;
            }
            generateFromComboBox.SelectedIndex = 0;
            cudaReady = false;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                python.CloseMainWindow();
            }
            catch
            {
                MessageBox.Show("Failed to close Python process!");
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {            
            if(!backgroundWorker1.CancellationPending)
                myPipe.AsyncRead();
        }
    }
    public static class ModifyProgressBarColor
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
        static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr w, IntPtr l);
        public static void SetState(this ProgressBar pBar, int state)
        {
            SendMessage(pBar.Handle, 1040, (IntPtr)state, IntPtr.Zero);
        }
    }
}
