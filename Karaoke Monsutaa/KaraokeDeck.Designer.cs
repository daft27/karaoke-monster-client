namespace Karaoke_Monsutaa
{
    partial class KaraokeDeck
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.voiceInputLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.volumeBar2 = new System.Windows.Forms.ProgressBar();
            this.volumeBar1 = new System.Windows.Forms.ProgressBar();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.volumeMic1 = new System.Windows.Forms.TrackBar();
            this.recordTrack2 = new System.Windows.Forms.Button();
            this.monitorTrack2 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.timeLabel = new System.Windows.Forms.Label();
            this.songLabel = new System.Windows.Forms.Label();
            this.reverbToggle1 = new System.Windows.Forms.CheckBox();
            this.volumeTrack1 = new System.Windows.Forms.TrackBar();
            this.stopTrack1 = new System.Windows.Forms.Button();
            this.playTrack1 = new System.Windows.Forms.Button();
            this.loadTrack1 = new System.Windows.Forms.Button();
            this.pitchUp = new System.Windows.Forms.Button();
            this.pitchNormal = new System.Windows.Forms.Button();
            this.pitchDown = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.playRemote1 = new System.Windows.Forms.Button();
            this.loadRemote1 = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.micTrack2Source = new System.Windows.Forms.TextBox();
            this.volumeMic2 = new System.Windows.Forms.TrackBar();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.musicTrack2Source = new System.Windows.Forms.TextBox();
            this.volumeTrack2 = new System.Windows.Forms.TrackBar();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.volumeMic1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.volumeTrack1)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.volumeMic2)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.volumeTrack2)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.ItemSize = new System.Drawing.Size(67, 18);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(688, 106);
            this.tabControl1.TabIndex = 11;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.voiceInputLabel);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.volumeBar2);
            this.tabPage1.Controls.Add(this.volumeBar1);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(680, 80);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "My Controls";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // voiceInputLabel
            // 
            this.voiceInputLabel.AutoSize = true;
            this.voiceInputLabel.Location = new System.Drawing.Point(497, 40);
            this.voiceInputLabel.Name = "voiceInputLabel";
            this.voiceInputLabel.Size = new System.Drawing.Size(61, 13);
            this.voiceInputLabel.TabIndex = 13;
            this.voiceInputLabel.Text = "Voice Input";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(497, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Music Output";
            // 
            // volumeBar2
            // 
            this.volumeBar2.Location = new System.Drawing.Point(499, 53);
            this.volumeBar2.Maximum = 60;
            this.volumeBar2.Name = "volumeBar2";
            this.volumeBar2.Size = new System.Drawing.Size(150, 15);
            this.volumeBar2.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.volumeBar2.TabIndex = 11;
            // 
            // volumeBar1
            // 
            this.volumeBar1.Location = new System.Drawing.Point(499, 22);
            this.volumeBar1.Maximum = 60;
            this.volumeBar1.Name = "volumeBar1";
            this.volumeBar1.Size = new System.Drawing.Size(150, 15);
            this.volumeBar1.TabIndex = 10;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.volumeMic1);
            this.groupBox2.Controls.Add(this.recordTrack2);
            this.groupBox2.Controls.Add(this.monitorTrack2);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox2.Location = new System.Drawing.Point(543, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(137, 80);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Mic Input";
            this.groupBox2.Visible = false;
            // 
            // volumeMic1
            // 
            this.volumeMic1.BackColor = System.Drawing.Color.White;
            this.volumeMic1.Location = new System.Drawing.Point(88, 9);
            this.volumeMic1.Name = "volumeMic1";
            this.volumeMic1.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.volumeMic1.Size = new System.Drawing.Size(45, 61);
            this.volumeMic1.TabIndex = 8;
            this.volumeMic1.Value = 10;
            // 
            // recordTrack2
            // 
            this.recordTrack2.Location = new System.Drawing.Point(7, 19);
            this.recordTrack2.Name = "recordTrack2";
            this.recordTrack2.Size = new System.Drawing.Size(75, 23);
            this.recordTrack2.TabIndex = 6;
            this.recordTrack2.Text = "Record";
            this.recordTrack2.UseVisualStyleBackColor = true;
            // 
            // monitorTrack2
            // 
            this.monitorTrack2.Location = new System.Drawing.Point(6, 47);
            this.monitorTrack2.Name = "monitorTrack2";
            this.monitorTrack2.Size = new System.Drawing.Size(75, 23);
            this.monitorTrack2.TabIndex = 7;
            this.monitorTrack2.Text = "Monitor";
            this.monitorTrack2.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.timeLabel);
            this.groupBox1.Controls.Add(this.songLabel);
            this.groupBox1.Controls.Add(this.reverbToggle1);
            this.groupBox1.Controls.Add(this.volumeTrack1);
            this.groupBox1.Controls.Add(this.stopTrack1);
            this.groupBox1.Controls.Add(this.playTrack1);
            this.groupBox1.Controls.Add(this.loadTrack1);
            this.groupBox1.Controls.Add(this.pitchUp);
            this.groupBox1.Controls.Add(this.pitchNormal);
            this.groupBox1.Controls.Add(this.pitchDown);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(481, 80);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Music Track";
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
            // reverbToggle1
            // 
            this.reverbToggle1.AutoSize = true;
            this.reverbToggle1.Checked = true;
            this.reverbToggle1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.reverbToggle1.Location = new System.Drawing.Point(284, 12);
            this.reverbToggle1.Name = "reverbToggle1";
            this.reverbToggle1.Size = new System.Drawing.Size(61, 17);
            this.reverbToggle1.TabIndex = 11;
            this.reverbToggle1.Text = "Reverb";
            this.reverbToggle1.UseVisualStyleBackColor = true;
            this.reverbToggle1.CheckedChanged += new System.EventHandler(this.reverbToggle1_CheckedChanged);
            // 
            // volumeTrack1
            // 
            this.volumeTrack1.BackColor = System.Drawing.Color.White;
            this.volumeTrack1.Location = new System.Drawing.Point(429, 9);
            this.volumeTrack1.Name = "volumeTrack1";
            this.volumeTrack1.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.volumeTrack1.Size = new System.Drawing.Size(45, 61);
            this.volumeTrack1.TabIndex = 10;
            this.volumeTrack1.Value = 10;
            this.volumeTrack1.Scroll += new System.EventHandler(this.volumeTrack1_Scroll);
            // 
            // stopTrack1
            // 
            this.stopTrack1.Location = new System.Drawing.Point(168, 18);
            this.stopTrack1.Name = "stopTrack1";
            this.stopTrack1.Size = new System.Drawing.Size(75, 23);
            this.stopTrack1.TabIndex = 7;
            this.stopTrack1.Text = "End Turn";
            this.stopTrack1.UseVisualStyleBackColor = true;
            this.stopTrack1.Click += new System.EventHandler(this.stopTrack1_Click);
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
            this.pitchUp.Location = new System.Drawing.Point(348, 8);
            this.pitchUp.Name = "pitchUp";
            this.pitchUp.Size = new System.Drawing.Size(75, 23);
            this.pitchUp.TabIndex = 3;
            this.pitchUp.Text = "Pitch Up";
            this.pitchUp.UseVisualStyleBackColor = true;
            this.pitchUp.Click += new System.EventHandler(this.pitchUp_Click);
            // 
            // pitchNormal
            // 
            this.pitchNormal.Location = new System.Drawing.Point(348, 31);
            this.pitchNormal.Name = "pitchNormal";
            this.pitchNormal.Size = new System.Drawing.Size(75, 23);
            this.pitchNormal.TabIndex = 4;
            this.pitchNormal.Text = "Normal";
            this.pitchNormal.UseVisualStyleBackColor = true;
            this.pitchNormal.Click += new System.EventHandler(this.pitchNormal_Click);
            // 
            // pitchDown
            // 
            this.pitchDown.Location = new System.Drawing.Point(348, 54);
            this.pitchDown.Name = "pitchDown";
            this.pitchDown.Size = new System.Drawing.Size(75, 23);
            this.pitchDown.TabIndex = 2;
            this.pitchDown.Text = "Pitch Down";
            this.pitchDown.UseVisualStyleBackColor = true;
            this.pitchDown.Click += new System.EventHandler(this.pitchDown_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.playRemote1);
            this.tabPage2.Controls.Add(this.loadRemote1);
            this.tabPage2.Controls.Add(this.groupBox4);
            this.tabPage2.Controls.Add(this.groupBox3);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(660, 80);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Test Playback";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // playRemote1
            // 
            this.playRemote1.Location = new System.Drawing.Point(524, 48);
            this.playRemote1.Name = "playRemote1";
            this.playRemote1.Size = new System.Drawing.Size(116, 23);
            this.playRemote1.TabIndex = 2;
            this.playRemote1.Text = "Play Remotes";
            this.playRemote1.UseVisualStyleBackColor = true;
            // 
            // loadRemote1
            // 
            this.loadRemote1.Location = new System.Drawing.Point(524, 21);
            this.loadRemote1.Name = "loadRemote1";
            this.loadRemote1.Size = new System.Drawing.Size(116, 23);
            this.loadRemote1.TabIndex = 1;
            this.loadRemote1.Text = "Load Remotes";
            this.loadRemote1.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.button2);
            this.groupBox4.Controls.Add(this.micTrack2Source);
            this.groupBox4.Controls.Add(this.volumeMic2);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox4.Location = new System.Drawing.Point(256, 0);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(253, 80);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Mic Input";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(114, 27);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Browse2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // micTrack2Source
            // 
            this.micTrack2Source.Location = new System.Drawing.Point(7, 31);
            this.micTrack2Source.Name = "micTrack2Source";
            this.micTrack2Source.Size = new System.Drawing.Size(100, 20);
            this.micTrack2Source.TabIndex = 1;
            this.micTrack2Source.Text = "out.mp3";
            // 
            // volumeMic2
            // 
            this.volumeMic2.BackColor = System.Drawing.Color.White;
            this.volumeMic2.Location = new System.Drawing.Point(201, 7);
            this.volumeMic2.Name = "volumeMic2";
            this.volumeMic2.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.volumeMic2.Size = new System.Drawing.Size(45, 65);
            this.volumeMic2.TabIndex = 0;
            this.volumeMic2.Value = 10;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Controls.Add(this.musicTrack2Source);
            this.groupBox3.Controls.Add(this.volumeTrack2);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(256, 80);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Music Track";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(114, 27);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Browse1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // musicTrack2Source
            // 
            this.musicTrack2Source.Location = new System.Drawing.Point(7, 31);
            this.musicTrack2Source.Name = "musicTrack2Source";
            this.musicTrack2Source.Size = new System.Drawing.Size(100, 20);
            this.musicTrack2Source.TabIndex = 1;
            this.musicTrack2Source.Text = "out2.mp3";
            // 
            // volumeTrack2
            // 
            this.volumeTrack2.BackColor = System.Drawing.Color.White;
            this.volumeTrack2.Location = new System.Drawing.Point(203, 7);
            this.volumeTrack2.Name = "volumeTrack2";
            this.volumeTrack2.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.volumeTrack2.Size = new System.Drawing.Size(45, 65);
            this.volumeTrack2.TabIndex = 0;
            this.volumeTrack2.Value = 10;
            // 
            // KaraokeDeck
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Name = "KaraokeDeck";
            this.Size = new System.Drawing.Size(688, 106);
            this.Load += new System.EventHandler(this.KaraokeDeck_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.volumeMic1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.volumeTrack1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.volumeMic2)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.volumeTrack2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label voiceInputLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar volumeBar2;
        private System.Windows.Forms.ProgressBar volumeBar1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TrackBar volumeMic1;
        private System.Windows.Forms.Button recordTrack2;
        private System.Windows.Forms.Button monitorTrack2;
        private System.Windows.Forms.GroupBox groupBox1;
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
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button playRemote1;
        private System.Windows.Forms.Button loadRemote1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox micTrack2Source;
        private System.Windows.Forms.TrackBar volumeMic2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox musicTrack2Source;
        private System.Windows.Forms.TrackBar volumeTrack2;

    }
}
