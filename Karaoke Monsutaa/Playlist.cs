using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Karaoke_Monsutaa
{
    public partial class Playlist : UserControl
    {
        private List<Song> songs = new List<Song>();

        public Playlist()
        {
            InitializeComponent();
        }

        private void Playlist_Load(object sender, EventArgs e)
        {
            listBox1.DataSource = songs;
        }

        public void AddSong(Song s)
        {
            Song f = songs.Find(delegate(Song c) { return s.Source == c.Source && (s.Owner == c.Owner || (s.Owner == "" && c.Owner == Login.Username)); });
            if (f == null)
            {
                Console.WriteLine("Adding");
                songs.Insert(0, s);
                //songs.Add(s);
                Refresh();
                if (listBox1.SelectedItems.Count <= 1)
                {
                    if (listBox1.SelectedIndex >= 0)
                        listBox1.SetSelected(listBox1.SelectedIndex, false);
                    //listBox1.SelectedIndex = listBox1.Items.Count - 1;
                    listBox1.SelectedIndex = 0;
                }
            }
            else
            {
                f.Pitch = s.Pitch;
                f.Live = s.Live;
                if (listBox1.SelectedItems.Count <= 1)
                {
                    if (listBox1.SelectedIndex >= 0)
                        listBox1.SetSelected(listBox1.SelectedIndex, false);
                    listBox1.SelectedIndex = songs.IndexOf(f);
                }

                Refresh();
            }
            
        }

        public void EndLive(String s)
        {
            List<Song> fs = songs.FindAll(delegate(Song c) { return s == c.Owner && c.Live == 1; });

            for (int i = 0; i < fs.Count; i++)
            {
                fs[i].Live = 0;
            }

            Refresh();
        }

        public void RemoveOwner(String o)
        {
            int i = songs.RemoveAll(delegate(Song c) { return o == c.Owner; });
            Console.WriteLine("Removed " + i + " items");

            Refresh();
        }

        public void ParseCommand(List<string> obj)
        {
            switch (obj[0])
            {
                case "clear":
                    {
                        string name = "";
                        for (int i = 1; i < obj.Count; i += 2)
                        {
                            if (obj[i] == "name")
                                name = obj[i + 1];
                        }

                        RemoveOwner(name);
                        break;
                    }
                case "recend":
                    {
                        string name = "";
                        for (int i = 1; i < obj.Count; i += 2)
                        {
                            if (obj[i] == "name")
                                name = obj[i + 1];
                        }

                        EndLive(name);
                        break;
                    }
                case "song":
                    {

                        string owner = "";
                        string title = "";
                        string artist = "";
                        string source = "";
                        float pitch = 1;
                        int live = 0;
                        int length = 0;

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
                            else if (obj[i] == "pitch")
                            {
                                Console.WriteLine("ADXP = " + obj[i + 1]);
                                try
                                {
                                    pitch = float.Parse(obj[i + 1]);
                                }
                                catch (FormatException fe)
                                {
                                    Console.WriteLine("FE: " + fe.Message);
                                }

                            }
                            else if (obj[i] == "live")
                            {
                                try
                                {
                                    live = int.Parse(obj[i + 1]);
                                }
                                catch (FormatException fe)
                                {
                                    Console.WriteLine("FE: " + fe.Message);
                                }

                            }
                            else if (obj[i] == "length")
                            {
                                try
                                {
                                    length = int.Parse(obj[i + 1]);
                                }
                                catch (FormatException fe)
                                {
                                    Console.WriteLine("FE: " + fe.Message);
                                }

                            }
                        }
                        Console.WriteLine("ADDSONG p = " + pitch);
                        //<owner>sss</owner>
                        //<title>KOTOKO</title>
                        //<artist>Special Life!</artist>
                        //<source>C:\Backup\Kamen no Maid Guy OP Single - Special Life  [KOTOKO] [Nipponsei]\01 - Special Life!.mp3</source>

                        if(!Room.IsIgnored(owner))
                            AddSong(new Song(owner, artist, title, source, pitch, live, length));

                        break;
                    }
            }
        }

        public override void Refresh()
        {
            base.Refresh();
            ((CurrencyManager)listBox1.BindingContext[listBox1.DataSource]).Refresh();
        }

        public Song SelectedSong
        {
            get
            {
                return (Song)listBox1.SelectedValue;
            }
        }

        #region Events

        public delegate void SongStartHandler(Song s);
        [Category("Action")]
        [Description("Fires when a song is doubleclicked.")]
        public event SongStartHandler SongStarted;
        protected virtual void OnSongStarted(Song s)
        {
            if (SongStarted != null)
                SongStarted(s);  // Notify Subscribers
        }


        private void listBox1_DragDrop(object sender, DragEventArgs e)
        {
            string[] valid = { ".aiff", ".asf", ".dls", ".flac", ".fsb", ".it", ".mid", ".mod", ".mp2", ".mp3", ".ogg", ".s3m", ".vag", ".wav", ".wma", ".xm" };
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            foreach (string file in files)
            {
                bool foundvalid = false;
                foreach (string ext in valid)
                {
                    if (file.EndsWith(ext))
                    {
                        foundvalid = true;
                        break;
                    }
                }
                if(foundvalid)
                    AddSong(new Song("", "", "", file, 0, 0, -1));
            }
        }

        private void listBox1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false) == true)
                e.Effect = DragDropEffects.All;
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                Song s = (Song)listBox1.SelectedValue;
                
                // record new songs
                if (s.SelfOwn && s.Owner == "")
                {
                    recordToolStripMenuItem_Click(sender, e);
                }
                else if (s.SelfOwn) //playback already recorded sonsg
                {
                    playbackMenuItem_Click(sender, e);
                }
                else // listen to other people's songs
                {
                    listenToolStripMenuItem_Click(sender, e);
                }
            }
        } 

        #endregion

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            /*if (listBox1.SelectedIndex < 0)
            {
                contextMenuStrip1.Close();
            }*/
        }

        private void listBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                // deselect everything
                for (int i = 0; i < songs.Count; i++)
                {
                    listBox1.SetSelected(i, false);
                }
                // select one
                listBox1.SelectedIndex = listBox1.IndexFromPoint(e.Location);
                Song s = (Song)listBox1.SelectedValue;
                if (s != null)
                {

                    if (s.SelfOwn && s.Owner == "")
                    {
                        stageSongToolStripMenuItem.Visible = true;
                        recordToolStripMenuItem.Visible = true;
                        playbackMenuItem.Visible = false;
                        listenToolStripMenuItem.Visible = false;
                        rerecordToolStripMenuItem.Visible = false;
                        coverToolStripMenuItem.Visible = false;
                    }
                    else if (s.SelfOwn)
                    {
                        stageSongToolStripMenuItem.Visible = true;

                        recordToolStripMenuItem.Visible = false;
                        rerecordToolStripMenuItem.Visible = true;
                        if (s.Owner != "")
                            playbackMenuItem.Visible = true;
                        else
                            playbackMenuItem.Visible = false;
                        listenToolStripMenuItem.Visible = false;
                        coverToolStripMenuItem.Visible = false;
                    }
                    else
                    {
                        stageSongToolStripMenuItem.Visible = false;

                        recordToolStripMenuItem.Visible = false;
                        rerecordToolStripMenuItem.Visible = false;
                        playbackMenuItem.Visible = false;
                        listenToolStripMenuItem.Visible = true;
                        coverToolStripMenuItem.Visible = true;

                    }
                    contextMenuStrip1.Show(this, e.Location);
                }
            }
        }

        private void queueSong_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
            }
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            foreach (string file in openFileDialog1.FileNames)
                AddSong(new Song("", "", "", file, 0, 0, -1));
        }

        private void delistSong_Click(object sender, EventArgs e)
        {
            int removed = 0;
            foreach (int i in listBox1.SelectedIndices)
            {
                songs.RemoveAt(i - removed);
                removed++;
            }
            Refresh();
        }

        private void listenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Song s = (Song)listBox1.SelectedValue;
            if (s != null)
            {
                s.Playback = false;
                OnSongStarted(s);
            }

        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Song s = (Song)listBox1.SelectedValue;
            if (s != null)
            {
                songs.Remove(s);
                Refresh();
            }

        }

        private void recordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Song s = (Song)listBox1.SelectedValue;
            if (s != null && MessageBox.Show("You are about to record this song.", "Continue?", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                s.Playback = false;
                OnSongStarted(s);
            }

        }

        private void listBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                delistSong_Click(null, null);
                e.Handled = true;
            }
            if (e.KeyCode == Keys.Enter)
            {
                listBox1_DoubleClick(null, null);
                e.Handled = true;
            }
        }

        private void playbackMenuItem_Click(object sender, EventArgs e)
        {
            Song s = (Song)listBox1.SelectedValue;
            if (s != null)
            {
                s.Playback = true;
                OnSongStarted(s);
            }
        }

        private void stageSongToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Song s = (Song)listBox1.SelectedValue;
            if (s != null && s.SelfOwn)
            {
                Network.Send(new string[] { "stagereq", "source", s.Source, "song", s.ToGenericName() });
            }
        }

        private void stageButton_Click(object sender, EventArgs e)
        {
            contextMenuStrip2.Show(stageButton, 0, 0);
        }

        private void rerecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Song s = (Song)listBox1.SelectedValue;
            if (s != null && MessageBox.Show("You are about to re-record this song.", "Continue?", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                s.Playback = false;
                OnSongStarted(s);
            }
        }

        private void coverToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Song s = (Song)listBox1.SelectedValue;
            if (s != null && MessageBox.Show("You are about to record this song.", "Continue?", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                s.Playback = false;

                Song cover = new Song("", "", s.Title, s.GetSource(0), 1.0f, 0, s.LengthPassed);
                AddSong(cover);
                OnSongStarted(cover);
            }
        }

       
    }
}
