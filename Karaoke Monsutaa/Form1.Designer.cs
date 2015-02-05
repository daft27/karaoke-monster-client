namespace Karaoke_Monsutaa
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
            if (disposing)
            {
                FMOD.RESULT result;

                /*
                    Shut down
                */
                if (alertSound != null)
                {
                    result = alertSound.release();
                    //ERRCHECK(result);
                }

                if (system != null)
                {
                    result = system.close();
                    //ERRCHECK(result);
                    result = system.release();
                    //ERRCHECK(result);
                }

                if (components != null)
                {
                    components.Dispose();
                }
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
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.avatar1 = new Karaoke_Monsutaa.Avatar();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.playlist1 = new Karaoke_Monsutaa.Playlist();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.noteLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.voiceInputLabel = new System.Windows.Forms.Label();
            this.volumeBar1 = new System.Windows.Forms.ProgressBar();
            this.volumeBar2 = new System.Windows.Forms.ProgressBar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.alertCheckBox = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.playNewCheckBox = new System.Windows.Forms.CheckBox();
            this.progressBarLoading = new System.Windows.Forms.ProgressBar();
            this.delay2 = new System.Windows.Forms.CheckBox();
            this.timeLabel = new System.Windows.Forms.Label();
            this.volumeBarTrack2 = new System.Windows.Forms.TrackBar();
            this.reverbToggle1 = new System.Windows.Forms.CheckBox();
            this.delay1 = new System.Windows.Forms.CheckBox();
            this.stopTrack1 = new System.Windows.Forms.Button();
            this.volumeTrack1 = new System.Windows.Forms.TrackBar();
            this.playTrack1 = new System.Windows.Forms.Button();
            this.loadTrack1 = new System.Windows.Forms.Button();
            this.pitchUp = new System.Windows.Forms.Button();
            this.pitchNormal = new System.Windows.Forms.Button();
            this.pitchDown = new System.Windows.Forms.Button();
            this.songLabel = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.room1 = new Karaoke_Monsutaa.Room();
            this.network1 = new Karaoke_Monsutaa.Network(this.components);
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.volumeBarTrack2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.volumeTrack1)).BeginInit();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // openFileDialog
            // 
            this.openFileDialog.AddExtension = false;
            this.openFileDialog.Filter = "Music Files | *.aiff;*.asf;*.dls;*.flac;*.fsb;*.it;*.mid;*.mod;*.mp2;*.mp3;*.ogg;" +
                "*.s3m;*.vag;*.wav;*.wma;*.xm;*.m4a;*.aac";
            this.openFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.White;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer3);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(919, 415);
            this.splitContainer1.SplitterDistance = 247;
            this.splitContainer1.TabIndex = 10;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.avatar1);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.groupBox5);
            this.splitContainer3.Size = new System.Drawing.Size(247, 415);
            this.splitContainer3.SplitterDistance = 246;
            this.splitContainer3.SplitterWidth = 1;
            this.splitContainer3.TabIndex = 0;
            // 
            // avatar1
            // 
            this.avatar1.BackColor = System.Drawing.Color.White;
            this.avatar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.avatar1.Location = new System.Drawing.Point(0, 0);
            this.avatar1.Name = "avatar1";
            this.avatar1.Size = new System.Drawing.Size(247, 246);
            this.avatar1.TabIndex = 0;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.playlist1);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox5.Location = new System.Drawing.Point(0, 0);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(5, 1, 5, 5);
            this.groupBox5.Size = new System.Drawing.Size(247, 168);
            this.groupBox5.TabIndex = 2;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Song Selection";
            // 
            // playlist1
            // 
            this.playlist1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.playlist1.Location = new System.Drawing.Point(5, 14);
            this.playlist1.Name = "playlist1";
            this.playlist1.Size = new System.Drawing.Size(237, 149);
            this.playlist1.TabIndex = 0;
            this.playlist1.SongStarted += new Karaoke_Monsutaa.Playlist.SongStartHandler(this.playlist1_SongStarted);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer2.IsSplitterFixed = true;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.BackColor = System.Drawing.SystemColors.Window;
            this.splitContainer2.Panel1.Controls.Add(this.groupBox2);
            this.splitContainer2.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.groupBox6);
            this.splitContainer2.Size = new System.Drawing.Size(668, 415);
            this.splitContainer2.SplitterDistance = 85;
            this.splitContainer2.SplitterWidth = 1;
            this.splitContainer2.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.noteLabel);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.voiceInputLabel);
            this.groupBox2.Controls.Add(this.volumeBar1);
            this.groupBox2.Controls.Add(this.volumeBar2);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox2.Location = new System.Drawing.Point(487, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(181, 85);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Levels";
            // 
            // noteLabel
            // 
            this.noteLabel.AutoSize = true;
            this.noteLabel.Location = new System.Drawing.Point(144, 47);
            this.noteLabel.Name = "noteLabel";
            this.noteLabel.Size = new System.Drawing.Size(14, 13);
            this.noteLabel.TabIndex = 19;
            this.noteLabel.Text = "C";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Music Track";
            // 
            // voiceInputLabel
            // 
            this.voiceInputLabel.AutoSize = true;
            this.voiceInputLabel.Location = new System.Drawing.Point(6, 47);
            this.voiceInputLabel.Name = "voiceInputLabel";
            this.voiceInputLabel.Size = new System.Drawing.Size(65, 13);
            this.voiceInputLabel.TabIndex = 18;
            this.voiceInputLabel.Text = "Vocal Track";
            // 
            // volumeBar1
            // 
            this.volumeBar1.Location = new System.Drawing.Point(8, 29);
            this.volumeBar1.Maximum = 90;
            this.volumeBar1.Minimum = 25;
            this.volumeBar1.Name = "volumeBar1";
            this.volumeBar1.Size = new System.Drawing.Size(150, 15);
            this.volumeBar1.TabIndex = 15;
            this.volumeBar1.Value = 25;
            // 
            // volumeBar2
            // 
            this.volumeBar2.Location = new System.Drawing.Point(8, 60);
            this.volumeBar2.Maximum = 90;
            this.volumeBar2.Minimum = 25;
            this.volumeBar2.Name = "volumeBar2";
            this.volumeBar2.Size = new System.Drawing.Size(150, 15);
            this.volumeBar2.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.volumeBar2.TabIndex = 16;
            this.volumeBar2.Value = 25;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.alertCheckBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.playNewCheckBox);
            this.groupBox1.Controls.Add(this.progressBarLoading);
            this.groupBox1.Controls.Add(this.delay2);
            this.groupBox1.Controls.Add(this.timeLabel);
            this.groupBox1.Controls.Add(this.volumeBarTrack2);
            this.groupBox1.Controls.Add(this.reverbToggle1);
            this.groupBox1.Controls.Add(this.delay1);
            this.groupBox1.Controls.Add(this.stopTrack1);
            this.groupBox1.Controls.Add(this.volumeTrack1);
            this.groupBox1.Controls.Add(this.playTrack1);
            this.groupBox1.Controls.Add(this.loadTrack1);
            this.groupBox1.Controls.Add(this.pitchUp);
            this.groupBox1.Controls.Add(this.pitchNormal);
            this.groupBox1.Controls.Add(this.pitchDown);
            this.groupBox1.Controls.Add(this.songLabel);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(481, 85);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Music Track";
            // 
            // alertCheckBox
            // 
            this.alertCheckBox.AutoSize = true;
            this.alertCheckBox.Checked = true;
            this.alertCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.alertCheckBox.Location = new System.Drawing.Point(252, 0);
            this.alertCheckBox.Name = "alertCheckBox";
            this.alertCheckBox.Size = new System.Drawing.Size(85, 17);
            this.alertCheckBox.TabIndex = 19;
            this.alertCheckBox.Text = "Audible Alert";
            this.alertCheckBox.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(427, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Vocal";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(384, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Music";
            // 
            // playNewCheckBox
            // 
            this.playNewCheckBox.AutoSize = true;
            this.playNewCheckBox.Checked = true;
            this.playNewCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.playNewCheckBox.Location = new System.Drawing.Point(172, -1);
            this.playNewCheckBox.Name = "playNewCheckBox";
            this.playNewCheckBox.Size = new System.Drawing.Size(71, 17);
            this.playNewCheckBox.TabIndex = 13;
            this.playNewCheckBox.Text = "Play New";
            this.playNewCheckBox.UseVisualStyleBackColor = true;
            // 
            // progressBarLoading
            // 
            this.progressBarLoading.Location = new System.Drawing.Point(87, 19);
            this.progressBarLoading.Maximum = 40;
            this.progressBarLoading.Name = "progressBarLoading";
            this.progressBarLoading.Size = new System.Drawing.Size(75, 23);
            this.progressBarLoading.TabIndex = 12;
            this.progressBarLoading.Visible = false;
            // 
            // delay2
            // 
            this.delay2.Appearance = System.Windows.Forms.Appearance.Button;
            this.delay2.AutoSize = true;
            this.delay2.Location = new System.Drawing.Point(452, 57);
            this.delay2.Name = "delay2";
            this.delay2.Size = new System.Drawing.Size(23, 23);
            this.delay2.TabIndex = 18;
            this.delay2.Text = "<";
            this.delay2.UseVisualStyleBackColor = true;
            this.delay2.CheckedChanged += new System.EventHandler(this.delay2_CheckedChanged);
            // 
            // timeLabel
            // 
            this.timeLabel.AutoSize = true;
            this.timeLabel.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeLabel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.timeLabel.Location = new System.Drawing.Point(4, 24);
            this.timeLabel.MinimumSize = new System.Drawing.Size(80, 0);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(80, 14);
            this.timeLabel.TabIndex = 3;
            this.timeLabel.Text = "    ";
            this.timeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.timeLabel.Visible = false;
            // 
            // volumeBarTrack2
            // 
            this.volumeBarTrack2.BackColor = System.Drawing.Color.White;
            this.volumeBarTrack2.Location = new System.Drawing.Point(428, 17);
            this.volumeBarTrack2.Name = "volumeBarTrack2";
            this.volumeBarTrack2.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.volumeBarTrack2.Size = new System.Drawing.Size(45, 61);
            this.volumeBarTrack2.TabIndex = 14;
            this.volumeBarTrack2.Value = 10;
            this.volumeBarTrack2.Scroll += new System.EventHandler(this.volumeBarTrack2_Scroll);
            // 
            // reverbToggle1
            // 
            this.reverbToggle1.AutoSize = true;
            this.reverbToggle1.Checked = true;
            this.reverbToggle1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.reverbToggle1.Location = new System.Drawing.Point(97, -1);
            this.reverbToggle1.Name = "reverbToggle1";
            this.reverbToggle1.Size = new System.Drawing.Size(61, 17);
            this.reverbToggle1.TabIndex = 11;
            this.reverbToggle1.Text = "Reverb";
            this.reverbToggle1.UseVisualStyleBackColor = true;
            this.reverbToggle1.Click += new System.EventHandler(this.reverbToggle1_CheckedChanged);
            // 
            // delay1
            // 
            this.delay1.Appearance = System.Windows.Forms.Appearance.Button;
            this.delay1.AutoSize = true;
            this.delay1.Location = new System.Drawing.Point(406, 57);
            this.delay1.Name = "delay1";
            this.delay1.Size = new System.Drawing.Size(23, 23);
            this.delay1.TabIndex = 17;
            this.delay1.Text = "<";
            this.delay1.UseVisualStyleBackColor = true;
            this.delay1.CheckedChanged += new System.EventHandler(this.delay1_CheckedChanged);
            // 
            // stopTrack1
            // 
            this.stopTrack1.Location = new System.Drawing.Point(168, 18);
            this.stopTrack1.Name = "stopTrack1";
            this.stopTrack1.Size = new System.Drawing.Size(50, 23);
            this.stopTrack1.TabIndex = 7;
            this.stopTrack1.Text = "Stop";
            this.stopTrack1.UseVisualStyleBackColor = true;
            this.stopTrack1.Click += new System.EventHandler(this.stopTrack1_Click);
            // 
            // volumeTrack1
            // 
            this.volumeTrack1.BackColor = System.Drawing.Color.White;
            this.volumeTrack1.Location = new System.Drawing.Point(385, 17);
            this.volumeTrack1.Name = "volumeTrack1";
            this.volumeTrack1.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.volumeTrack1.Size = new System.Drawing.Size(45, 61);
            this.volumeTrack1.TabIndex = 10;
            this.volumeTrack1.Value = 10;
            this.volumeTrack1.Scroll += new System.EventHandler(this.volumeTrack1_Scroll);
            // 
            // playTrack1
            // 
            this.playTrack1.Location = new System.Drawing.Point(87, 18);
            this.playTrack1.Name = "playTrack1";
            this.playTrack1.Size = new System.Drawing.Size(75, 23);
            this.playTrack1.TabIndex = 6;
            this.playTrack1.Text = "Start";
            this.playTrack1.UseVisualStyleBackColor = true;
            this.playTrack1.Click += new System.EventHandler(this.playTrack1_Click);
            // 
            // loadTrack1
            // 
            this.loadTrack1.Location = new System.Drawing.Point(6, 19);
            this.loadTrack1.Name = "loadTrack1";
            this.loadTrack1.Size = new System.Drawing.Size(75, 23);
            this.loadTrack1.TabIndex = 5;
            this.loadTrack1.Text = "Select Song";
            this.loadTrack1.UseVisualStyleBackColor = true;
            this.loadTrack1.Click += new System.EventHandler(this.loadTrack1_Click);
            // 
            // pitchUp
            // 
            this.pitchUp.Location = new System.Drawing.Point(244, 8);
            this.pitchUp.Name = "pitchUp";
            this.pitchUp.Size = new System.Drawing.Size(75, 23);
            this.pitchUp.TabIndex = 3;
            this.pitchUp.Text = "Pitch Up";
            this.pitchUp.UseVisualStyleBackColor = true;
            this.pitchUp.Visible = false;
            // 
            // pitchNormal
            // 
            this.pitchNormal.Location = new System.Drawing.Point(244, 31);
            this.pitchNormal.Name = "pitchNormal";
            this.pitchNormal.Size = new System.Drawing.Size(75, 23);
            this.pitchNormal.TabIndex = 4;
            this.pitchNormal.Text = "Normal";
            this.pitchNormal.UseVisualStyleBackColor = true;
            this.pitchNormal.Visible = false;
            // 
            // pitchDown
            // 
            this.pitchDown.Location = new System.Drawing.Point(244, 54);
            this.pitchDown.Name = "pitchDown";
            this.pitchDown.Size = new System.Drawing.Size(75, 23);
            this.pitchDown.TabIndex = 2;
            this.pitchDown.Text = "Pitch Down";
            this.pitchDown.UseVisualStyleBackColor = true;
            this.pitchDown.Visible = false;
            // 
            // songLabel
            // 
            this.songLabel.AutoSize = true;
            this.songLabel.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.songLabel.Location = new System.Drawing.Point(6, 45);
            this.songLabel.MinimumSize = new System.Drawing.Size(239, 30);
            this.songLabel.Name = "songLabel";
            this.songLabel.Size = new System.Drawing.Size(239, 30);
            this.songLabel.TabIndex = 4;
            this.songLabel.Text = "            ";
            this.songLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.songLabel.Visible = false;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.room1);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox6.Location = new System.Drawing.Point(0, 0);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(668, 329);
            this.groupBox6.TabIndex = 0;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Lounge";
            // 
            // room1
            // 
            this.room1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.room1.Location = new System.Drawing.Point(3, 16);
            this.room1.Name = "room1";
            this.room1.Size = new System.Drawing.Size(662, 310);
            this.room1.TabIndex = 0;
            // 
            // network1
            // 
            this.network1.MsgReceived += new Karaoke_Monsutaa.Network.MsgReceiveHandler(this.network1_MsgReceived);
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(919, 415);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Karaoke Monsutaa";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            this.splitContainer3.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.volumeBarTrack2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.volumeTrack1)).EndInit();
            this.groupBox6.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox6;
        private Playlist playlist1;
        private Network network1;
        private Room room1;
        private Avatar avatar1;
        private System.Windows.Forms.Label voiceInputLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar volumeBar2;
        private System.Windows.Forms.ProgressBar volumeBar1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox delay2;
        private System.Windows.Forms.CheckBox delay1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TrackBar volumeBarTrack2;
        private System.Windows.Forms.CheckBox playNewCheckBox;
        private System.Windows.Forms.ProgressBar progressBarLoading;
        private System.Windows.Forms.Label timeLabel;
        private System.Windows.Forms.Label songLabel;
        private System.Windows.Forms.CheckBox reverbToggle1;
        private System.Windows.Forms.TrackBar volumeTrack1;
        private System.Windows.Forms.Button stopTrack1;
        private System.Windows.Forms.Button playTrack1;
        private System.Windows.Forms.Button loadTrack1;
        private System.Windows.Forms.Button pitchUp;
        private System.Windows.Forms.Button pitchNormal;
        private System.Windows.Forms.Button pitchDown;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label noteLabel;
        private System.Windows.Forms.CheckBox alertCheckBox;
    }
}

