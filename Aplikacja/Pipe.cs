using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aplikacja
{
    class Pipe
    {
        private NamedPipeServerStream server;
        private BinaryReader br;
        private BinaryWriter bw;
        public int data;
        public bool dataIsNew;

        public Pipe()
        {
            server = new NamedPipeServerStream("AIMusic");
            br = new BinaryReader(server);
            bw = new BinaryWriter(server);
            data = 0;
            dataIsNew = false;
        }
        public void StartConnection()
        {
            server.WaitForConnection();
        }

        public bool IsMessageComplete()
        {
            return server.IsMessageComplete;
        }
        public bool IsConnected()
        { 
            return server.IsConnected;
        }
        public void AsyncRead()
        {            
            try
            {
                var len = (int)br.ReadUInt32();
                var str = new string(br.ReadChars(len));
                data = Convert.ToInt32(str);
                dataIsNew = true;
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        public void WriteMessage(String str)
        {
            try
            {
                str = new string(str.ToArray());

                var buf = Encoding.ASCII.GetBytes(str);         
                bw.Write((uint)buf.Length);               
                bw.Write(buf);                              
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        public void EndConnection()
        {
            server.Close();
            server.Dispose();
        }
    }
}
