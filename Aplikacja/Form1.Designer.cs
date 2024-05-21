namespace Aplikacja
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.generateFromComboBox = new System.Windows.Forms.ComboBox();
            this.generateModeLabel = new System.Windows.Forms.Label();
            this.addButton = new System.Windows.Forms.Button();
            this.notesCountNumeric = new System.Windows.Forms.NumericUpDown();
            this.notesCountLabel = new System.Windows.Forms.Label();
            this.generateCountLabel = new System.Windows.Forms.Label();
            this.generateCountNumeric = new System.Windows.Forms.NumericUpDown();
            this.timeSpaceComboBox = new System.Windows.Forms.ComboBox();
            this.timeSpaceLabel = new System.Windows.Forms.Label();
            this.playButton = new System.Windows.Forms.Button();
            this.generateButton = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.applyButton = new System.Windows.Forms.Button();
            this.offsetFirstParamNumeric = new System.Windows.Forms.NumericUpDown();
            this.offsetSecondParamNumeric = new System.Windows.Forms.NumericUpDown();
            this.firstOffsetLabel = new System.Windows.Forms.Label();
            this.secondOffsetLabel = new System.Windows.Forms.Label();
            this.seedLabel = new System.Windows.Forms.Label();
            this.resetButton = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.notesCountNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.generateCountNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.offsetFirstParamNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.offsetSecondParamNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            this.progressBar1.BackColor = System.Drawing.Color.Maroon;
            this.progressBar1.ForeColor = System.Drawing.Color.Gray;
            this.progressBar1.Location = new System.Drawing.Point(24, 267);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(536, 28);
            this.progressBar1.TabIndex = 1;
            this.progressBar1.Visible = false;
            // 
            // generateFromComboBox
            // 
            this.generateFromComboBox.BackColor = System.Drawing.Color.Black;
            this.generateFromComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.generateFromComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.generateFromComboBox.Font = new System.Drawing.Font("Sitka Small", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.generateFromComboBox.ForeColor = System.Drawing.Color.White;
            this.generateFromComboBox.FormattingEnabled = true;
            this.generateFromComboBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.generateFromComboBox.Items.AddRange(new object[] {
            "Seed file",
            "Built-in library"});
            this.generateFromComboBox.Location = new System.Drawing.Point(24, 54);
            this.generateFromComboBox.Name = "generateFromComboBox";
            this.generateFromComboBox.Size = new System.Drawing.Size(266, 32);
            this.generateFromComboBox.TabIndex = 5;
            this.generateFromComboBox.TextChanged += new System.EventHandler(this.generateFromComboBox_TextChanged);
            // 
            // generateModeLabel
            // 
            this.generateModeLabel.AutoSize = true;
            this.generateModeLabel.BackColor = System.Drawing.Color.Transparent;
            this.generateModeLabel.Font = new System.Drawing.Font("Sitka Small", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.generateModeLabel.ForeColor = System.Drawing.Color.White;
            this.generateModeLabel.Location = new System.Drawing.Point(21, 27);
            this.generateModeLabel.Name = "generateModeLabel";
            this.generateModeLabel.Size = new System.Drawing.Size(138, 24);
            this.generateModeLabel.TabIndex = 6;
            this.generateModeLabel.Text = "Generate from:";
            // 
            // addButton
            // 
            this.addButton.BackColor = System.Drawing.Color.Transparent;
            this.addButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.addButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.addButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addButton.Font = new System.Drawing.Font("Sitka Small", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addButton.ForeColor = System.Drawing.Color.White;
            this.addButton.Location = new System.Drawing.Point(312, 54);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(110, 33);
            this.addButton.TabIndex = 7;
            this.addButton.Tag = "addButton";
            this.addButton.Text = "Add seed";
            this.addButton.UseVisualStyleBackColor = false;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // notesCountNumeric
            // 
            this.notesCountNumeric.BackColor = System.Drawing.Color.Black;
            this.notesCountNumeric.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.notesCountNumeric.Enabled = false;
            this.notesCountNumeric.Font = new System.Drawing.Font("Microsoft Sans Serif", 17.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.notesCountNumeric.ForeColor = System.Drawing.Color.White;
            this.notesCountNumeric.Location = new System.Drawing.Point(24, 137);
            this.notesCountNumeric.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.notesCountNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.notesCountNumeric.Name = "notesCountNumeric";
            this.notesCountNumeric.Size = new System.Drawing.Size(230, 34);
            this.notesCountNumeric.TabIndex = 8;
            this.notesCountNumeric.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.notesCountNumeric.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // notesCountLabel
            // 
            this.notesCountLabel.AutoSize = true;
            this.notesCountLabel.BackColor = System.Drawing.Color.Transparent;
            this.notesCountLabel.Font = new System.Drawing.Font("Sitka Small", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.notesCountLabel.ForeColor = System.Drawing.Color.White;
            this.notesCountLabel.Location = new System.Drawing.Point(20, 111);
            this.notesCountLabel.Name = "notesCountLabel";
            this.notesCountLabel.Size = new System.Drawing.Size(153, 23);
            this.notesCountLabel.TabIndex = 9;
            this.notesCountLabel.Text = "Seed notes count:";
            // 
            // generateCountLabel
            // 
            this.generateCountLabel.AutoSize = true;
            this.generateCountLabel.BackColor = System.Drawing.Color.Transparent;
            this.generateCountLabel.Font = new System.Drawing.Font("Sitka Small", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.generateCountLabel.ForeColor = System.Drawing.Color.White;
            this.generateCountLabel.Location = new System.Drawing.Point(308, 111);
            this.generateCountLabel.Name = "generateCountLabel";
            this.generateCountLabel.Size = new System.Drawing.Size(231, 23);
            this.generateCountLabel.TabIndex = 11;
            this.generateCountLabel.Text = "Count of notes to generate:";
            // 
            // generateCountNumeric
            // 
            this.generateCountNumeric.BackColor = System.Drawing.Color.Black;
            this.generateCountNumeric.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.generateCountNumeric.Enabled = false;
            this.generateCountNumeric.Font = new System.Drawing.Font("Microsoft Sans Serif", 17.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.generateCountNumeric.ForeColor = System.Drawing.Color.White;
            this.generateCountNumeric.Location = new System.Drawing.Point(312, 137);
            this.generateCountNumeric.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.generateCountNumeric.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.generateCountNumeric.Name = "generateCountNumeric";
            this.generateCountNumeric.Size = new System.Drawing.Size(230, 34);
            this.generateCountNumeric.TabIndex = 10;
            this.generateCountNumeric.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.generateCountNumeric.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            // 
            // timeSpaceComboBox
            // 
            this.timeSpaceComboBox.BackColor = System.Drawing.Color.Black;
            this.timeSpaceComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.timeSpaceComboBox.Enabled = false;
            this.timeSpaceComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.timeSpaceComboBox.Font = new System.Drawing.Font("Sitka Small", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeSpaceComboBox.ForeColor = System.Drawing.Color.White;
            this.timeSpaceComboBox.FormattingEnabled = true;
            this.timeSpaceComboBox.Items.AddRange(new object[] {
            "Average from seed",
            "Given value",
            "Random"});
            this.timeSpaceComboBox.Location = new System.Drawing.Point(24, 213);
            this.timeSpaceComboBox.Name = "timeSpaceComboBox";
            this.timeSpaceComboBox.Size = new System.Drawing.Size(266, 32);
            this.timeSpaceComboBox.TabIndex = 12;
            this.timeSpaceComboBox.TextChanged += new System.EventHandler(this.timeSpaceComboBox_TextChanged);
            // 
            // timeSpaceLabel
            // 
            this.timeSpaceLabel.AutoSize = true;
            this.timeSpaceLabel.BackColor = System.Drawing.Color.Transparent;
            this.timeSpaceLabel.Font = new System.Drawing.Font("Sitka Small", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeSpaceLabel.ForeColor = System.Drawing.Color.White;
            this.timeSpaceLabel.Location = new System.Drawing.Point(21, 187);
            this.timeSpaceLabel.Name = "timeSpaceLabel";
            this.timeSpaceLabel.Size = new System.Drawing.Size(227, 23);
            this.timeSpaceLabel.TabIndex = 13;
            this.timeSpaceLabel.Text = "Time space between notes:";
            // 
            // playButton
            // 
            this.playButton.BackColor = System.Drawing.Color.Transparent;
            this.playButton.Enabled = false;
            this.playButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.playButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.playButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.playButton.Font = new System.Drawing.Font("Sitka Small", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playButton.ForeColor = System.Drawing.Color.White;
            this.playButton.Location = new System.Drawing.Point(241, 311);
            this.playButton.Name = "playButton";
            this.playButton.Size = new System.Drawing.Size(100, 38);
            this.playButton.TabIndex = 14;
            this.playButton.Text = "Play";
            this.playButton.UseVisualStyleBackColor = false;
            this.playButton.Click += new System.EventHandler(this.playButton_Click);
            // 
            // generateButton
            // 
            this.generateButton.BackColor = System.Drawing.Color.Transparent;
            this.generateButton.Enabled = false;
            this.generateButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.generateButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.generateButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.generateButton.Font = new System.Drawing.Font("Sitka Small", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.generateButton.ForeColor = System.Drawing.Color.White;
            this.generateButton.Location = new System.Drawing.Point(24, 311);
            this.generateButton.Name = "generateButton";
            this.generateButton.Size = new System.Drawing.Size(100, 38);
            this.generateButton.TabIndex = 15;
            this.generateButton.Text = "Generate";
            this.generateButton.UseVisualStyleBackColor = false;
            this.generateButton.Click += new System.EventHandler(this.generateButton_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 50;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // applyButton
            // 
            this.applyButton.BackColor = System.Drawing.Color.Transparent;
            this.applyButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.applyButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.applyButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.applyButton.Font = new System.Drawing.Font("Sitka Small", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.applyButton.ForeColor = System.Drawing.Color.White;
            this.applyButton.Location = new System.Drawing.Point(450, 54);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(110, 33);
            this.applyButton.TabIndex = 16;
            this.applyButton.Text = "Apply";
            this.applyButton.UseVisualStyleBackColor = false;
            this.applyButton.Click += new System.EventHandler(this.applyButton_Click);
            // 
            // offsetFirstParamNumeric
            // 
            this.offsetFirstParamNumeric.BackColor = System.Drawing.Color.Black;
            this.offsetFirstParamNumeric.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.offsetFirstParamNumeric.DecimalPlaces = 1;
            this.offsetFirstParamNumeric.Enabled = false;
            this.offsetFirstParamNumeric.Font = new System.Drawing.Font("Microsoft Sans Serif", 17.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.offsetFirstParamNumeric.ForeColor = System.Drawing.Color.White;
            this.offsetFirstParamNumeric.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.offsetFirstParamNumeric.Location = new System.Drawing.Point(305, 213);
            this.offsetFirstParamNumeric.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.offsetFirstParamNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.offsetFirstParamNumeric.Name = "offsetFirstParamNumeric";
            this.offsetFirstParamNumeric.Size = new System.Drawing.Size(124, 34);
            this.offsetFirstParamNumeric.TabIndex = 17;
            this.offsetFirstParamNumeric.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.offsetFirstParamNumeric.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.offsetFirstParamNumeric.ValueChanged += new System.EventHandler(this.offsetFirstParamNumeric_ValueChanged);
            // 
            // offsetSecondParamNumeric
            // 
            this.offsetSecondParamNumeric.BackColor = System.Drawing.Color.Black;
            this.offsetSecondParamNumeric.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.offsetSecondParamNumeric.DecimalPlaces = 1;
            this.offsetSecondParamNumeric.Enabled = false;
            this.offsetSecondParamNumeric.Font = new System.Drawing.Font("Microsoft Sans Serif", 17.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.offsetSecondParamNumeric.ForeColor = System.Drawing.Color.White;
            this.offsetSecondParamNumeric.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.offsetSecondParamNumeric.Location = new System.Drawing.Point(446, 213);
            this.offsetSecondParamNumeric.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.offsetSecondParamNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.offsetSecondParamNumeric.Name = "offsetSecondParamNumeric";
            this.offsetSecondParamNumeric.Size = new System.Drawing.Size(124, 34);
            this.offsetSecondParamNumeric.TabIndex = 18;
            this.offsetSecondParamNumeric.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.offsetSecondParamNumeric.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            // 
            // firstOffsetLabel
            // 
            this.firstOffsetLabel.AutoSize = true;
            this.firstOffsetLabel.BackColor = System.Drawing.Color.Transparent;
            this.firstOffsetLabel.Font = new System.Drawing.Font("Sitka Small", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.firstOffsetLabel.ForeColor = System.Drawing.Color.White;
            this.firstOffsetLabel.Location = new System.Drawing.Point(302, 192);
            this.firstOffsetLabel.Name = "firstOffsetLabel";
            this.firstOffsetLabel.Size = new System.Drawing.Size(48, 16);
            this.firstOffsetLabel.TabIndex = 19;
            this.firstOffsetLabel.Text = "Offset:";
            // 
            // secondOffsetLabel
            // 
            this.secondOffsetLabel.AutoSize = true;
            this.secondOffsetLabel.BackColor = System.Drawing.Color.Transparent;
            this.secondOffsetLabel.Font = new System.Drawing.Font("Sitka Small", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.secondOffsetLabel.ForeColor = System.Drawing.Color.White;
            this.secondOffsetLabel.Location = new System.Drawing.Point(443, 192);
            this.secondOffsetLabel.Name = "secondOffsetLabel";
            this.secondOffsetLabel.Size = new System.Drawing.Size(123, 16);
            this.secondOffsetLabel.TabIndex = 20;
            this.secondOffsetLabel.Text = "Random max value:";
            // 
            // seedLabel
            // 
            this.seedLabel.AutoSize = true;
            this.seedLabel.BackColor = System.Drawing.Color.Transparent;
            this.seedLabel.Font = new System.Drawing.Font("Sitka Small", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.seedLabel.ForeColor = System.Drawing.Color.White;
            this.seedLabel.Location = new System.Drawing.Point(310, 33);
            this.seedLabel.Name = "seedLabel";
            this.seedLabel.Size = new System.Drawing.Size(46, 18);
            this.seedLabel.TabIndex = 21;
            this.seedLabel.Text = "label1";
            this.seedLabel.Visible = false;
            // 
            // resetButton
            // 
            this.resetButton.BackColor = System.Drawing.Color.Transparent;
            this.resetButton.Enabled = false;
            this.resetButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.resetButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.resetButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.resetButton.Font = new System.Drawing.Font("Sitka Small", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resetButton.ForeColor = System.Drawing.Color.White;
            this.resetButton.Location = new System.Drawing.Point(460, 311);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(100, 38);
            this.resetButton.TabIndex = 22;
            this.resetButton.Text = "Reset";
            this.resetButton.UseVisualStyleBackColor = false;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(584, 361);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.seedLabel);
            this.Controls.Add(this.secondOffsetLabel);
            this.Controls.Add(this.firstOffsetLabel);
            this.Controls.Add(this.offsetSecondParamNumeric);
            this.Controls.Add(this.offsetFirstParamNumeric);
            this.Controls.Add(this.applyButton);
            this.Controls.Add(this.generateButton);
            this.Controls.Add(this.playButton);
            this.Controls.Add(this.timeSpaceLabel);
            this.Controls.Add(this.timeSpaceComboBox);
            this.Controls.Add(this.generateCountLabel);
            this.Controls.Add(this.generateCountNumeric);
            this.Controls.Add(this.notesCountLabel);
            this.Controls.Add(this.notesCountNumeric);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.generateModeLabel);
            this.Controls.Add(this.generateFromComboBox);
            this.Controls.Add(this.progressBar1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "AI Chopin";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.notesCountNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.generateCountNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.offsetFirstParamNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.offsetSecondParamNumeric)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ComboBox generateFromComboBox;
        private System.Windows.Forms.Label generateModeLabel;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.NumericUpDown notesCountNumeric;
        private System.Windows.Forms.Label notesCountLabel;
        private System.Windows.Forms.Label generateCountLabel;
        private System.Windows.Forms.NumericUpDown generateCountNumeric;
        private System.Windows.Forms.ComboBox timeSpaceComboBox;
        private System.Windows.Forms.Label timeSpaceLabel;
        private System.Windows.Forms.Button playButton;
        private System.Windows.Forms.Button generateButton;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button applyButton;
        private System.Windows.Forms.NumericUpDown offsetFirstParamNumeric;
        private System.Windows.Forms.NumericUpDown offsetSecondParamNumeric;
        private System.Windows.Forms.Label firstOffsetLabel;
        private System.Windows.Forms.Label secondOffsetLabel;
        private System.Windows.Forms.Label seedLabel;
        private System.Windows.Forms.Button resetButton;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}

