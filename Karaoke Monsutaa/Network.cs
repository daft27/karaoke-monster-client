using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Net.Sockets;
using System.Threading;
using System.IO;
using System.Xml;

namespace Karaoke_Monsutaa
{
    public partial class Network : Component
    {
        public static String ServerAddr = "localhost";//haruhi.fansub.tv
        public static readonly int ServerPortComm = 41842;
        public static readonly int ServerPortBroadcast = 41843;
        public static readonly int ServerPortRelay = 41844;

        private NetworkStream ns = null;
        static private Queue<String> outgoingcomm = new Queue<String>();

        public Network()
        {
            InitializeComponent();
        }

        public Network(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public String MakeHeaders(String source, uint size)
        {
            return
"POST /" + Login.Username + @"
Source: " + source + @"
Content-Length: " + size + @" bytes

";
        }

        static public string EncodeTo64(string toEncode)
        {

            byte[] toEncodeAsBytes

                  = System.Text.UnicodeEncoding.Unicode.GetBytes(toEncode);

            string returnValue

                  = System.Convert.ToBase64String(toEncodeAsBytes);

            return returnValue;

        }

        static public string DecodeFrom64(string encodedData)
        {

            byte[] encodedDataAsBytes

                = System.Convert.FromBase64String(encodedData);

            string returnValue =

               System.Text.UnicodeEncoding.Unicode.GetString(encodedDataAsBytes);

            return returnValue;

        }
        static public void Send(string[] sends)
        {
            MemoryStream ms = new MemoryStream();
            StringWriter sw = new StringWriter();
            XmlTextWriter xtw = new XmlTextWriter(ms, new UnicodeEncoding(false, false));
            //XmlTextWriter xtw = new XmlTextWriter(sw);
            xtw.WriteStartElement(sends[0]);

            // write attributes
            for (int i = 1; i < sends.Length - 1; i += 2)
            {
                xtw.WriteAttributeString(sends[i], sends[i + 1]);
            }

            // stack in CDATA
            if (sends.Length % 2 == 0)
            {
                xtw.WriteCData(sends[sends.Length - 1]);
            }

            xtw.WriteEndElement();
            xtw.WriteString("\r\n");
            xtw.Close();
            Send(Encoding.Unicode.GetString(ms.ToArray()));
            //sw.Write("\r\n");
            //Send(sw.ToString());
        }

        static public void Send(string msg)
        {
            Console.WriteLine("msg [" + msg.Length + "] = " + msg);
            lock (outgoingcomm)
            {
                outgoingcomm.Enqueue(msg);
                Monitor.Pulse(outgoingcomm);
            }
        }

        public void Activate()
        {
            backgroundWorker1.RunWorkerAsync();
            backgroundWorker2.RunWorkerAsync();
        }

        #region Events

        public delegate void MsgReceiveHandler(List<String> obj);
        [Category("Action")]
        [Description("Fires when a msg is received.")]
        public event MsgReceiveHandler MsgReceived;
        protected virtual void OnMsgReceived(List<string> obj)
        {
            if (MsgReceived != null)
                MsgReceived(obj);  // Notify Subscribers
        }


        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                try
                {
                    s.ReceiveBufferSize = 16384;
                    s.SendBufferSize = 16384;
                    s.Connect(Network.ServerAddr, Network.ServerPortComm);
                    ns = new NetworkStream(s, true);

                    // send communication declaration
                    byte[] encodedstart = UnicodeEncoding.Unicode.GetBytes("<?xml version=\"1.0\" encoding=\"UTF-16\"?>");
                    ns.Write(encodedstart, 0, encodedstart.Length);


                    //Send("<enter name=\"" + Login.Username + "\" />\r\n");
                    Send(new string[] { "enter", "name", Login.Username });

                    //String online = "<enter name=\"" + login.Username + "\" />\r\n";
                    //byte[] encoded = UnicodeEncoding.Unicode.GetBytes(online);

                    //ns.Write(encoded, 0, encoded.Length);
                    byte[] buffer = new byte[1024];
                    StringBuilder sb = new StringBuilder();

                    TextReader tr = new StreamReader(ns, Encoding.Unicode);
                    XmlReader reader = XmlReader.Create(tr);

                    Stack<String> names = new Stack<String>();
                    List<string> obj = new List<string>();
                    while (true)
                    {
                        //String data = tr.ReadLine();
                        if (reader.Read())
                        {
                            switch (reader.NodeType)
                            {
                                case XmlNodeType.Element:
                                    {
                                        obj.Add(reader.Name);
                                        Console.WriteLine("{0}<{1} />", reader.Depth, reader.Name);

                                        bool empty = reader.IsEmptyElement;

                                        while (reader.MoveToNextAttribute())
                                        {
                                            Console.WriteLine("<{0}>{1}</{0}>", reader.Name, reader.Value);
                                            obj.Add(reader.Name);
                                            obj.Add(reader.Value);
                                        }

                                        if (empty || obj[0] == "karaoke")
                                        {
                                            backgroundWorker1.ReportProgress(0, obj);
                                            obj = new List<string>();
                                            Console.WriteLine("Submitting");
                                        }
                                    }
                                    break;
                                case XmlNodeType.Text:
                                    Console.Write(reader.Value);
                                    break;
                                case XmlNodeType.CDATA:
                                    {
                                        obj.Add("CHARS");
                                        obj.Add(reader.Value);
                                        Console.Write("<![{0} C2ATA[{1}]]>", reader.Name, reader.Value);
                                    }
                                    break;
                                case XmlNodeType.ProcessingInstruction:
                                    Console.Write("<?{0} {1}?>", reader.Name, reader.Value);
                                    break;
                                case XmlNodeType.Comment:
                                    Console.Write("<!--{0}-->", reader.Value);
                                    break;
                                case XmlNodeType.XmlDeclaration:
                                    Console.Write("<?xml version='1.0' encoding='UTF-16'?>");
                                    break;
                                case XmlNodeType.Document:
                                    break;
                                case XmlNodeType.DocumentType:
                                    Console.Write("<!DOCTYPE {0} [{1}]", reader.Name, reader.Value);
                                    break;
                                case XmlNodeType.EntityReference:
                                    Console.Write(reader.Name);
                                    break;
                                case XmlNodeType.EndElement:
                                    if (obj.Count > 0)
                                    {
                                        backgroundWorker1.ReportProgress(0, obj);
                                        obj = new List<string>();
                                    }
                                    Console.Write("</{0}> popped", reader.Name);
                                    break;
                            }
                        }

                        //int l = ns.Read(buffer, 0, 1024);
                        /*String data = UnicodeEncoding.Unicode.GetString(buffer);

                        sb.Append(data);
                        Console.WriteLine("l = " + l + " [" + data + "]]]");
                        int index = -1;
                        if (data.Index("\n") >= 0)
                        {

                            StringReader sr = new StringReader(sb.ToString());
                            String line = sr.ReadLine();
                            sb.Remove(0, line.Length);
                            Console.WriteLine("Line: " + line);
                        }*/
                    }
                }
                catch (SocketException se)
                {
                    ns = null;
                    Console.WriteLine("SocketException: " + se.Message);
                }
                catch (XmlException se)
                {
                    ns = null;
                    s.Close();
                    Console.WriteLine("XMLException: " + se.Message);
                    List<string> obj = new List<string>();
                    obj.Add("disconnect");
                    backgroundWorker1.ReportProgress(0, obj);
                }
                catch (IOException se)
                {
                    ns = null;
                    s.Close();
                    Console.WriteLine("IOException: " + se.Message);
                    List<string> obj = new List<string>();
                    obj.Add("disconnect");
                    backgroundWorker1.ReportProgress(0, obj);
                }
                Thread.Sleep(5000);
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // hit callback
            List<string> obj = (List<string>)e.UserState;
            OnMsgReceived(obj);
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                string msg = "";
                lock (outgoingcomm)
                {
                    while (outgoingcomm.Count == 0)
                        Monitor.Wait(outgoingcomm);

                    msg = outgoingcomm.Dequeue();
                }

                if (ns != null)
                {
                    try
                    {
                        byte[] encoded = UnicodeEncoding.Unicode.GetBytes(msg);
                        ns.Write(encoded, 0, encoded.Length);
                    }
                    catch (IOException ex)
                    {
                        // stuff it
                        Console.WriteLine("err on outgoing + " + ex.Message);
                    }
                }
            }
        }
        #endregion

    }
}
