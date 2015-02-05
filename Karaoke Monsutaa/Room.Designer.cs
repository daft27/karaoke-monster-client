namespace Karaoke_Monsutaa
{
    partial class Room
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
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.textLog1 = new System.Windows.Forms.RichTextBox();
            this.textEntry = new System.Windows.Forms.TextBox();
            this.memberList = new System.Windows.Forms.ListBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.messageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.profileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.duetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ignoreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Name = "splitContainer4";
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.textLog1);
            this.splitContainer4.Panel1.Controls.Add(this.textEntry);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.memberList);
            this.splitContainer4.Size = new System.Drawing.Size(240, 204);
            this.splitContainer4.SplitterDistance = 200;
            this.splitContainer4.TabIndex = 2;
            // 
            // textLog1
            // 
            this.textLog1.BackColor = System.Drawing.Color.White;
            this.textLog1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textLog1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textLog1.HideSelection = false;
            this.textLog1.Location = new System.Drawing.Point(0, 0);
            this.textLog1.Name = "textLog1";
            this.textLog1.ReadOnly = true;
            this.textLog1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.textLog1.Size = new System.Drawing.Size(200, 184);
            this.textLog1.TabIndex = 2;
            this.textLog1.Text = "Karaoke MONSTER\n--------------\n";
            this.textLog1.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.textLog1_LinkClicked);
            // 
            // textEntry
            // 
            this.textEntry.AcceptsReturn = true;
            this.textEntry.BackColor = System.Drawing.SystemColors.ControlLight;
            this.textEntry.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textEntry.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.textEntry.ImeMode = System.Windows.Forms.ImeMode.On;
            this.textEntry.Location = new System.Drawing.Point(0, 184);
            this.textEntry.Multiline = true;
            this.textEntry.Name = "textEntry";
            this.textEntry.Size = new System.Drawing.Size(200, 20);
            this.textEntry.TabIndex = 0;
            this.textEntry.WordWrap = false;
            this.textEntry.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textEntry_KeyDown);
            // 
            // memberList
            // 
            this.memberList.BackColor = System.Drawing.SystemColors.Control;
            this.memberList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.memberList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.memberList.FormattingEnabled = true;
            this.memberList.IntegralHeight = false;
            this.memberList.Location = new System.Drawing.Point(0, 0);
            this.memberList.Name = "memberList";
            this.memberList.Size = new System.Drawing.Size(36, 204);
            this.memberList.Sorted = true;
            this.memberList.TabIndex = 0;
            this.memberList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.memberList_MouseDown);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.messageToolStripMenuItem,
            this.profileToolStripMenuItem,
            this.duetToolStripMenuItem,
            this.ignoreToolStripMenuItem,
            this.stageToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(127, 114);
            // 
            // messageToolStripMenuItem
            // 
            this.messageToolStripMenuItem.Enabled = false;
            this.messageToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.messageToolStripMenuItem.Name = "messageToolStripMenuItem";
            this.messageToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.messageToolStripMenuItem.Text = "Message";
            // 
            // profileToolStripMenuItem
            // 
            this.profileToolStripMenuItem.Enabled = false;
            this.profileToolStripMenuItem.Name = "profileToolStripMenuItem";
            this.profileToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.profileToolStripMenuItem.Text = "Profile";
            // 
            // duetToolStripMenuItem
            // 
            this.duetToolStripMenuItem.Enabled = false;
            this.duetToolStripMenuItem.Name = "duetToolStripMenuItem";
            this.duetToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.duetToolStripMenuItem.Text = "Start Duet";
            // 
            // ignoreToolStripMenuItem
            // 
            this.ignoreToolStripMenuItem.Name = "ignoreToolStripMenuItem";
            this.ignoreToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.ignoreToolStripMenuItem.Text = "Ignore";
            this.ignoreToolStripMenuItem.Click += new System.EventHandler(this.ignoreToolStripMenuItem_Click);
            // 
            // stageToolStripMenuItem
            // 
            this.stageToolStripMenuItem.Name = "stageToolStripMenuItem";
            this.stageToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.stageToolStripMenuItem.Text = "Stage";
            this.stageToolStripMenuItem.Visible = false;
            this.stageToolStripMenuItem.Click += new System.EventHandler(this.stageToolStripMenuItem_Click);
            // 
            // Room
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer4);
            this.Name = "Room";
            this.Size = new System.Drawing.Size(240, 204);
            this.Load += new System.EventHandler(this.Room_Load);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel1.PerformLayout();
            this.splitContainer4.Panel2.ResumeLayout(false);
            this.splitContainer4.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.TextBox textEntry;
        private System.Windows.Forms.ListBox memberList;
        private System.Windows.Forms.RichTextBox textLog1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem messageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem profileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem duetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ignoreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stageToolStripMenuItem;

    }
}
