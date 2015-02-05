using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Karaoke_Monsutaa
{

    public partial class Room : UserControl
    {
        [DllImport("user32.dll")]
        protected static extern IntPtr GetFocus();

        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr window, int message, int wparam, int lparam);
        const int WM_VSCROLL = 0x115;
        const int SB_BOTTOM = 7;

        static private List<String> ignoreList = new List<String>();

        private String stageName = "";


        public Room()
        {
            InitializeComponent();
        }

        private void Room_Load(object sender, EventArgs e)
        {
            textEntry.Select();
        }

        static public bool IsIgnored(String name)
        {
            return ignoreList.Contains(name);
        }

        public void LogText(String s)
        {
            if (!textLog1.Visible || textLog1.Disposing)
                return;

            String time = DateTime.Now.ToString("hh:mm:ss");
            textLog1.AppendText("[" + time + "]  " + s);

            // scroll down
            if (!textLog1.Focused)
                SendMessage(textLog1.Handle, WM_VSCROLL, SB_BOTTOM, 0);
        }

        private Color[] NameColors = { Color.MediumAquamarine, Color.MediumBlue, Color.MediumOrchid, Color.MediumPurple, Color.MediumSeaGreen, Color.Crimson, Color.Brown, Color.MediumVioletRed, Color.DarkGoldenrod, Color.MidnightBlue, Color.Chocolate, Color.LightSalmon };

        public void LogChat(String user, String msg)
        {
            if (!textLog1.Visible || textLog1.Disposing)
                return;

            String time = DateTime.Now.ToString("hh:mm:ss");
            textLog1.AppendText("[" + time + "]  ");

            textLog1.SelectionFont = new Font(textLog1.SelectionFont.Name, textLog1.SelectionFont.Size, FontStyle.Bold);
            textLog1.SelectionStart = textLog1.Text.Length;
            textLog1.SelectionColor = NameColors[Math.Abs(user.GetHashCode()) % NameColors.Length];
            textLog1.AppendText(user);

            textLog1.SelectionFont = new Font(textLog1.SelectionFont.Name, textLog1.SelectionFont.Size, FontStyle.Regular);
            textLog1.SelectionColor = Color.Black;
            textLog1.AppendText(": " + msg);

            // scroll down
            if (!textLog1.Focused)
                SendMessage(textLog1.Handle, WM_VSCROLL, SB_BOTTOM, 0);
        }

        public bool ParseCommand(List<string> obj)
        {
            switch (obj[0])
            {
                case "karaoke":
                    {
                        //textLog.AppendText("Connected to Lounge.\r\n");
                        memberList.Items.Clear();
                        break;
                    }
                case "disconnect":
                    {
                        LogText("Disconnected.\r\n");
                        break;
                    }
                case "welcome":
                    {
                        Console.WriteLine("# = " + obj.Count);
                        LogText(obj[2].Replace("\n", "\r\n") + "\r\n");
                        return true;
                        break;
                    }
                case "join":
                    {
                        string name = "";
                        bool alert = false;
                        for (int i = 1; i < obj.Count; i += 2)
                        {
                            if (obj[i] == "name")
                                name = obj[i + 1];
                            else if (obj[i] == "alert")
                            {
                                try
                                {
                                    alert = Int32.Parse(obj[i + 1]) == 1;
                                }
                                catch (FormatException fe)
                                {
                                    Console.WriteLine("FE: " + fe.Message);
                                }
                            }
                        }

                        memberList.Items.Add(name);

                        if (alert && !IsIgnored(name))
                            LogText("*** " + name + " has joined the channel. ***\r\n");

                        break;
                    }
                case "left":
                    {
                        string name = "";
                        bool alert = false;
                        for (int i = 1; i < obj.Count; i += 2)
                        {
                            if (obj[i] == "name")
                                name = obj[i + 1];
                            else if (obj[i] == "alert")
                            {
                                try
                                {
                                    alert = Int32.Parse(obj[i + 1]) == 1;
                                }
                                catch (FormatException fe)
                                {
                                    Console.WriteLine("FE: " + fe.Message);
                                }

                            }
                        }
                        if (alert && !IsIgnored(name))
                            LogText("*** " + name + " has left the channel. ***\r\n");

                        memberList.Items.Remove(name);
                        break;
                    }
                case "action":
                    {
                        string name = "";
                        string msg = "";
                        for (int i = 1; i < obj.Count; i += 2)
                        {
                            if (obj[i] == "name")
                                name = obj[i + 1];
                            else if (obj[i] == "CHARS")
                                msg = obj[i + 1];
                        }
                        if (!IsIgnored(name))
                        {
                            LogText(" * " + name + " " + msg.Substring("/me ".Length) + " *\r\n");
                            return true;
                        }
                        break;
                    }
                case "msg":
                    {
                        string name = "";
                        string msg = "";
                        for (int i = 1; i < obj.Count; i += 2)
                        {
                            if (obj[i] == "name")
                                name = obj[i + 1];
                            else if (obj[i] == "CHARS")
                                msg = obj[i + 1];
                        }
                        if (!IsIgnored(name))
                        {
                            LogChat(name, msg + "\r\n");
                            return name != Login.Username;
                        }
                        break;
                    }
                case "stage":
                    {
                        string name = "";
                        for (int i = 1; i < obj.Count; i += 2)
                        {
                            if (obj[i] == "name")
                                name = obj[i + 1];
                        }
                        if (name != "")
                            LogText("*** " + name + " has taken the stage! ***\r\n");
                        else
                            LogText("*** The stage is now open. ***\r\n");

                        stageName = name;

                        return true;
                        break;
                    }
                case "song":
                    {

                        string owner = "";
                        string title = "";
                        string artist = "";
                        string source = "";

                        for (int i = 1; i < obj.Count; i += 2)
                        {
                            if (obj[i] == "owner")
                                owner = obj[i + 1];
                            else if (obj[i] == "title")
                                title = obj[i + 1];
                            else if (obj[i] == "artist")
                                artist = obj[i + 1];
                            else if (obj[i] == "source")
                                source = obj[i + 1];

                        }

                        string name = "";
                        if (title.Length > 0 && artist.Length > 0)
                            name = artist + " - " + title;
                        else if (title.Length > 0)
                            name = title;
                        else
                            name = System.IO.Path.GetFileNameWithoutExtension(source);

                        if(!IsIgnored(name))
                            LogText("*** " + owner + " has begun broadcasting " + name + " ***\r\n");
                        break;
                    }
            }
            return false;
        }

        private void textEntry_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13 && textEntry.Text.Length > 0)
            {
                //textLog.AppendText("<msg name=\"" + login.Username + "\"><![CDATA[" + textEntry.Text.Replace("]]>","") + "]]></msg>\r\n");
                //Network.Send("<msg name=\"" + Login.Username + "\"><![CDATA[" + textEntry.Text.Replace("]]>", "") + "]]></msg>\r\n");
                string s = textEntry.Text.Replace("\r\n", "\n");

                while (s.StartsWith("\n"))
                    s = s.Remove(0, 1);

                string s2 = s.Replace("\n", "").Trim();
                if (s2.Length > 0)
                    Network.Send(new string[] { "msg", "name", Login.Username, s });
                textEntry.Clear();
                e.Handled = true;
                e.SuppressKeyPress = true;

            }
        }

        private void textLog1_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            if (e.LinkText.StartsWith("http"))
            {
                System.Diagnostics.Process.Start(e.LinkText);
            }
        }

        private void memberList_MouseDown(object sender, MouseEventArgs e)
        {
            // select one
            memberList.SelectedIndex = memberList.IndexFromPoint(e.Location);
            if (e.Button == MouseButtons.Right && memberList.SelectedIndex >= 0)
            {
                String name = (String) memberList.SelectedItem;
                if (IsIgnored(name))
                    ignoreToolStripMenuItem.Checked = true;
                else
                    ignoreToolStripMenuItem.Checked = false;

                if (name == stageName)
                    stageToolStripMenuItem.Checked = true;
                else
                    stageToolStripMenuItem.Checked = false;

                contextMenuStrip1.Show(memberList, e.Location);
            }

        }

        private void ignoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String name = (String) memberList.SelectedItem;
            Console.WriteLine(name);
            if (ignoreList.Contains(name))
            {
                ignoreList.Remove(name);
                LogText(name + " is no longer ignored.\n");
            }
            else
            {
                ignoreList.Add(name);
                LogText(name + " is now ignored.\n");
            }
        }

        private void stageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String name = (String)memberList.SelectedItem;
            if (stageToolStripMenuItem.Checked == false)
            {
                Network.Send(new string[] {"msg", "/2stage2 " + name});
            }
            else
            {
                Network.Send(new string[] {"msg", "/2stage2 " });
            }
        }
    }
}
