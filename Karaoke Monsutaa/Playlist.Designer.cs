namespace Karaoke_Monsutaa
{
    partial class Playlist
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
            this.components = new System.ComponentModel.Container();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.stageButton = new System.Windows.Forms.Button();
            this.delistSong = new System.Windows.Forms.Button();
            this.queueSong = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.playbackMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rerecordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.coverToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stageSongToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.d0ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.AllowDrop = true;
            this.listBox1.BackColor = System.Drawing.SystemColors.Info;
            this.listBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.IntegralHeight = false;
            this.listBox1.Location = new System.Drawing.Point(0, 0);
            this.listBox1.Name = "listBox1";
            this.listBox1.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBox1.Size = new System.Drawing.Size(206, 180);
            this.listBox1.TabIndex = 1;
            this.listBox1.DragDrop += new System.Windows.Forms.DragEventHandler(this.listBox1_DragDrop);
            this.listBox1.DoubleClick += new System.EventHandler(this.listBox1_DoubleClick);
            this.listBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listBox1_MouseDown);
            this.listBox1.DragEnter += new System.Windows.Forms.DragEventHandler(this.listBox1_DragEnter);
            this.listBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listBox1_KeyDown);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.listBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.White;
            this.splitContainer1.Panel2.Controls.Add(this.stageButton);
            this.splitContainer1.Panel2.Controls.Add(this.delistSong);
            this.splitContainer1.Panel2.Controls.Add(this.queueSong);
            this.splitContainer1.Panel2MinSize = 17;
            this.splitContainer1.Size = new System.Drawing.Size(206, 198);
            this.splitContainer1.SplitterDistance = 180;
            this.splitContainer1.SplitterWidth = 1;
            this.splitContainer1.TabIndex = 2;
            // 
            // stageButton
            // 
            this.stageButton.BackColor = System.Drawing.SystemColors.Control;
            this.stageButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.stageButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stageButton.ForeColor = System.Drawing.Color.Black;
            this.stageButton.Location = new System.Drawing.Point(80, 0);
            this.stageButton.Name = "stageButton";
            this.stageButton.Size = new System.Drawing.Size(42, 17);
            this.stageButton.TabIndex = 2;
            this.stageButton.Text = "Stage";
            this.stageButton.UseVisualStyleBackColor = false;
            this.stageButton.Visible = false;
            this.stageButton.Click += new System.EventHandler(this.stageButton_Click);
            // 
            // delistSong
            // 
            this.delistSong.BackColor = System.Drawing.SystemColors.Control;
            this.delistSong.Dock = System.Windows.Forms.DockStyle.Right;
            this.delistSong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.delistSong.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.delistSong.ForeColor = System.Drawing.Color.Black;
            this.delistSong.Location = new System.Drawing.Point(182, 0);
            this.delistSong.Name = "delistSong";
            this.delistSong.Size = new System.Drawing.Size(24, 17);
            this.delistSong.TabIndex = 1;
            this.delistSong.Text = "-";
            this.delistSong.UseVisualStyleBackColor = false;
            this.delistSong.Click += new System.EventHandler(this.delistSong_Click);
            // 
            // queueSong
            // 
            this.queueSong.BackColor = System.Drawing.SystemColors.Control;
            this.queueSong.Dock = System.Windows.Forms.DockStyle.Left;
            this.queueSong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.queueSong.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.queueSong.ForeColor = System.Drawing.Color.Black;
            this.queueSong.Location = new System.Drawing.Point(0, 0);
            this.queueSong.Name = "queueSong";
            this.queueSong.Size = new System.Drawing.Size(22, 17);
            this.queueSong.TabIndex = 0;
            this.queueSong.Text = "+";
            this.queueSong.UseVisualStyleBackColor = false;
            this.queueSong.Click += new System.EventHandler(this.queueSong_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "Music Files | *.aiff;*.asf;*.dls;*.flac;*.fsb;*.it;*.mid;*.mod;*.mp2;*.mp3;*.ogg;" +
                "*.s3m;*.vag;*.wav;*.wma;*.xm";
            this.openFileDialog1.Multiselect = true;
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.playbackMenuItem,
            this.rerecordToolStripMenuItem,
            this.recordToolStripMenuItem,
            this.listenToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.rateToolStripMenuItem,
            this.coverToolStripMenuItem,
            this.removeToolStripMenuItem,
            this.stageSongToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.ShowImageMargin = false;
            this.contextMenuStrip1.Size = new System.Drawing.Size(128, 224);
            // 
            // playbackMenuItem
            // 
            this.playbackMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.playbackMenuItem.Name = "playbackMenuItem";
            this.playbackMenuItem.Size = new System.Drawing.Size(127, 22);
            this.playbackMenuItem.Text = "Playback";
            this.playbackMenuItem.Click += new System.EventHandler(this.playbackMenuItem_Click);
            // 
            // rerecordToolStripMenuItem
            // 
            this.rerecordToolStripMenuItem.Name = "rerecordToolStripMenuItem";
            this.rerecordToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.rerecordToolStripMenuItem.Text = "Re-record";
            this.rerecordToolStripMenuItem.Click += new System.EventHandler(this.rerecordToolStripMenuItem_Click);
            // 
            // recordToolStripMenuItem
            // 
            this.recordToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.recordToolStripMenuItem.Name = "recordToolStripMenuItem";
            this.recordToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.recordToolStripMenuItem.Text = "Record";
            this.recordToolStripMenuItem.Click += new System.EventHandler(this.recordToolStripMenuItem_Click);
            // 
            // listenToolStripMenuItem
            // 
            this.listenToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.listenToolStripMenuItem.Name = "listenToolStripMenuItem";
            this.listenToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.listenToolStripMenuItem.Text = "Listen";
            this.listenToolStripMenuItem.Click += new System.EventHandler(this.listenToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Enabled = false;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.saveToolStripMenuItem.Text = "Save";
            // 
            // rateToolStripMenuItem
            // 
            this.rateToolStripMenuItem.Enabled = false;
            this.rateToolStripMenuItem.Name = "rateToolStripMenuItem";
            this.rateToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.rateToolStripMenuItem.Text = "Rate";
            // 
            // coverToolStripMenuItem
            // 
            this.coverToolStripMenuItem.Name = "coverToolStripMenuItem";
            this.coverToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.coverToolStripMenuItem.Text = "Cover This";
            this.coverToolStripMenuItem.Click += new System.EventHandler(this.coverToolStripMenuItem_Click);
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            this.removeToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.removeToolStripMenuItem.Text = "Remove";
            this.removeToolStripMenuItem.Click += new System.EventHandler(this.removeToolStripMenuItem_Click);
            // 
            // stageSongToolStripMenuItem
            // 
            this.stageSongToolStripMenuItem.Name = "stageSongToolStripMenuItem";
            this.stageSongToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.stageSongToolStripMenuItem.Text = "Stage Song";
            this.stageSongToolStripMenuItem.Click += new System.EventHandler(this.stageSongToolStripMenuItem_Click);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.d0ToolStripMenuItem});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(88, 26);
            // 
            // d0ToolStripMenuItem
            // 
            this.d0ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeToolStripMenuItem1});
            this.d0ToolStripMenuItem.Name = "d0ToolStripMenuItem";
            this.d0ToolStripMenuItem.Size = new System.Drawing.Size(87, 22);
            this.d0ToolStripMenuItem.Text = "d0";
            // 
            // removeToolStripMenuItem1
            // 
            this.removeToolStripMenuItem1.Name = "removeToolStripMenuItem1";
            this.removeToolStripMenuItem1.Size = new System.Drawing.Size(117, 22);
            this.removeToolStripMenuItem1.Text = "Remove";
            // 
            // Playlist
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "Playlist";
            this.Size = new System.Drawing.Size(206, 198);
            this.Load += new System.EventHandler(this.Playlist_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.contextMenuStrip2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button delistSong;
        private System.Windows.Forms.Button queueSong;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem listenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem recordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem playbackMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem coverToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stageSongToolStripMenuItem;
        private System.Windows.Forms.Button stageButton;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem d0ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem rerecordToolStripMenuItem;
    }
}
