using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.ComponentModel;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;

namespace Karaoke_Monsutaa
{
    public class BroadcastStream : Stream
    {
        public static bool LowBandwidth = false;

        private Socket s = null;
        private BackgroundWorker bw = null;
        private NetworkStream ns = null;

        private String source = "";
        private Queue<byte[]> outgoingcomm = new Queue<byte[]>();
        private Track.MODE mode = Track.MODE.MUSIC;

        public BroadcastStream(String sourceIn, uint length, Track.MODE modeIn)
        {
            Console.WriteLine("BroadcastStream cons");
            source = sourceIn;
            mode = modeIn;
        }

        public override void Close()
        {
            base.Close();
            bw.CancelAsync();
            lock (outgoingcomm)
            {
                Monitor.Pulse(outgoingcomm);
            }
            Console.WriteLine("BS Closing");
        }

        void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            Console.WriteLine("RS DW Begin");
            if (s == null)
            {
                s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                try
                {

                    s.Connect(Network.ServerAddr, Network.ServerPortBroadcast);
                    ns = new NetworkStream(s);

                    String modes = "";
                    switch (mode)
                    {
                        case Track.MODE.MUSIC:
                            modes = "Music";
                            break;
                        case Track.MODE.USER:
                            modes = "User";
                            break;
                    }

                    String header = "Karaoke Monster BROADCAST Stream\n" +
                        "User\n" +
                        Login.Username + "\n" +
                        "Source\n" +
                        System.IO.Path.GetFileNameWithoutExtension(source) + "\n" +
                        "Type\n" +
                        modes + "\n" +
                        "END\n" +
                        "BEGIN";

                    byte[] encoded = ASCIIEncoding.ASCII.GetBytes(header);

                    byte[] headerBuff = new byte[1024];
                    Array.Clear(headerBuff, 0, headerBuff.Length);
                    Buffer.BlockCopy(encoded, 0, headerBuff, 0, encoded.Length);
                    ns.Write(headerBuff, 0, headerBuff.Length);
                }
                catch (SocketException se)
                {
                    Console.WriteLine("Err = " + se.Message);
                    ns = null;
                }

                while (!bw.CancellationPending)
                {

                    byte[] buff = null;
                    lock (outgoingcomm)
                    {
                        while (outgoingcomm.Count == 0 && !bw.CancellationPending)
                            Monitor.Wait(outgoingcomm);

                        if (bw.CancellationPending)
                        {
                            Console.WriteLine("BW Cancelled");
                            break;
                        }

                        buff = outgoingcomm.Dequeue();
                    }

                    if (ns != null)
                    {
                        try
                        {
                            ns.Write(buff, 0, buff.Length);
                        }
                        catch (IOException ex)
                        {
                            // stuff it
                            Console.WriteLine("err on outgoing + " + ex.Message);
                            ns.Close();
                            ns = null;
                        }
                    }
                }

                if (ns != null)
                {
                    Console.WriteLine("NS closed");
                    ns.Flush();
                    ns.Close();
                    ns.Dispose();

                    ns = null;
                }

                if (s != null)
                {
                    Console.WriteLine("S closed");
                    try
                    {
                        if (s.Connected)
                            s.Shutdown(SocketShutdown.Both);
                        s.Disconnect(false);
                    }
                    catch (SocketException se) { }

                    s.Close();
                    s = null;
                }

            }
            Console.WriteLine("RS DW End");
            
        }

        public override bool CanRead
        {
            get { return false; }
        }
        public override bool CanSeek
        {
            get { return false; }
        }
        public override bool CanWrite
        {
            get { return true; }
        }
        public override long Position
        {
            get { throw new InvalidOperationException(); }
            set { throw new InvalidOperationException(); }
        }
        public override long Length
        {
            get { throw new InvalidOperationException(); }
        }
        public override void Flush()
        {
        }
        public override void SetLength(long len)
        {
            throw new InvalidOperationException();
        }
        public override long Seek(long pos, SeekOrigin o)
        {
            throw new InvalidOperationException();
        }
        public override int Read(byte[] buf, int ofs, int count)
        {
            throw new InvalidOperationException();
        }
        public override void Write(byte[] buf, int ofs, int count)
        {
            byte[] temp = new byte[count];
            Buffer.BlockCopy(buf, ofs, temp, 0, count);
            if (bw == null)
            {
                bw = new BackgroundWorker();
                bw.WorkerSupportsCancellation = true;
                bw.DoWork += new DoWorkEventHandler(bw_DoWork);
                bw.RunWorkerAsync();
            }
            lock (outgoingcomm)
            {
                outgoingcomm.Enqueue(temp);
                Monitor.Pulse(outgoingcomm);
            }
            if (outgoingcomm.Count > 100 && !LowBandwidth)
            {
                LowBandwidth = true;
                MessageBox.Show("Low bandwidth mode enabled.");
                Console.WriteLine("Low on bandwidth");
            }
        }
    }
}
