namespace Karaoke_Monsutaa
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.usernameBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.loginButton = new System.Windows.Forms.Button();
            this.quitButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.passwordBox = new System.Windows.Forms.TextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.comboBoxPlayback = new System.Windows.Forms.ComboBox();
            this.comboBoxRecord = new System.Windows.Forms.ComboBox();
            this.comboBoxOutput = new System.Windows.Forms.ComboBox();
            this.audioSettings = new System.Windows.Forms.Button();
            this.getUpdate = new System.Windows.Forms.Button();
            this.comboBoxServer = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // usernameBox
            // 
            this.usernameBox.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.usernameBox.Location = new System.Drawing.Point(44, 284);
            this.usernameBox.Name = "usernameBox";
            this.usernameBox.Size = new System.Drawing.Size(100, 20);
            this.usernameBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 287);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nick";
            // 
            // loginButton
            // 
            this.loginButton.Location = new System.Drawing.Point(365, 283);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(75, 23);
            this.loginButton.TabIndex = 2;
            this.loginButton.Text = "Login";
            this.loginButton.UseCompatibleTextRendering = true;
            this.loginButton.UseVisualStyleBackColor = true;
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // quitButton
            // 
            this.quitButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.quitButton.Location = new System.Drawing.Point(446, 283);
            this.quitButton.Name = "quitButton";
            this.quitButton.Size = new System.Drawing.Size(39, 23);
            this.quitButton.TabIndex = 3;
            this.quitButton.Text = "Quit";
            this.quitButton.UseCompatibleTextRendering = true;
            this.quitButton.UseVisualStyleBackColor = true;
            this.quitButton.Click += new System.EventHandler(this.quitButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(208, 287);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Pass";
            this.label2.Visible = false;
            // 
            // passwordBox
            // 
            this.passwordBox.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.passwordBox.Location = new System.Drawing.Point(247, 284);
            this.passwordBox.Name = "passwordBox";
            this.passwordBox.Size = new System.Drawing.Size(100, 20);
            this.passwordBox.TabIndex = 1;
            this.passwordBox.UseSystemPasswordChar = true;
            this.passwordBox.Visible = false;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(-4, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(501, 280);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // comboBoxPlayback
            // 
            this.comboBoxPlayback.BackColor = System.Drawing.Color.White;
            this.comboBoxPlayback.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPlayback.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxPlayback.FormattingEnabled = true;
            this.comboBoxPlayback.Location = new System.Drawing.Point(17, 230);
            this.comboBoxPlayback.Name = "comboBoxPlayback";
            this.comboBoxPlayback.Size = new System.Drawing.Size(200, 21);
            this.comboBoxPlayback.TabIndex = 7;
            this.comboBoxPlayback.Visible = false;
            this.comboBoxPlayback.SelectedIndexChanged += new System.EventHandler(this.comboBoxPlayback_SelectedIndexChanged);
            // 
            // comboBoxRecord
            // 
            this.comboBoxRecord.BackColor = System.Drawing.Color.White;
            this.comboBoxRecord.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxRecord.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxRecord.FormattingEnabled = true;
            this.comboBoxRecord.Location = new System.Drawing.Point(17, 254);
            this.comboBoxRecord.Name = "comboBoxRecord";
            this.comboBoxRecord.Size = new System.Drawing.Size(200, 21);
            this.comboBoxRecord.TabIndex = 8;
            this.comboBoxRecord.Visible = false;
            this.comboBoxRecord.SelectedIndexChanged += new System.EventHandler(this.comboBoxRecord_SelectedIndexChanged);
            // 
            // comboBoxOutput
            // 
            this.comboBoxOutput.BackColor = System.Drawing.Color.White;
            this.comboBoxOutput.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxOutput.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxOutput.FormattingEnabled = true;
            this.comboBoxOutput.Items.AddRange(new object[] {
            "Select Audio System"});
            this.comboBoxOutput.Location = new System.Drawing.Point(17, 253);
            this.comboBoxOutput.Name = "comboBoxOutput";
            this.comboBoxOutput.Size = new System.Drawing.Size(200, 21);
            this.comboBoxOutput.TabIndex = 9;
            this.comboBoxOutput.Visible = false;
            this.comboBoxOutput.SelectedIndexChanged += new System.EventHandler(this.comboBoxOutput_SelectedIndexChanged);
            // 
            // audioSettings
            // 
            this.audioSettings.BackColor = System.Drawing.Color.Black;
            this.audioSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.audioSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.audioSettings.ForeColor = System.Drawing.Color.White;
            this.audioSettings.Location = new System.Drawing.Point(44, 245);
            this.audioSettings.Name = "audioSettings";
            this.audioSettings.Size = new System.Drawing.Size(132, 26);
            this.audioSettings.TabIndex = 10;
            this.audioSettings.Text = "Change Audio Settings";
            this.audioSettings.UseVisualStyleBackColor = false;
            this.audioSettings.Click += new System.EventHandler(this.button1_Click);
            // 
            // getUpdate
            // 
            this.getUpdate.BackColor = System.Drawing.Color.DarkRed;
            this.getUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.getUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.getUpdate.ForeColor = System.Drawing.Color.White;
            this.getUpdate.Location = new System.Drawing.Point(336, 245);
            this.getUpdate.Name = "getUpdate";
            this.getUpdate.Size = new System.Drawing.Size(107, 26);
            this.getUpdate.TabIndex = 11;
            this.getUpdate.Text = "Update Available";
            this.getUpdate.UseVisualStyleBackColor = false;
            this.getUpdate.Visible = false;
            this.getUpdate.Click += new System.EventHandler(this.getUpdate_Click);
            // 
            // comboBoxServer
            // 
            this.comboBoxServer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxServer.FormattingEnabled = true;
            this.comboBoxServer.Items.AddRange(new object[] {
            "US 1",
            "Dev Only"});
            this.comboBoxServer.Location = new System.Drawing.Point(275, 282);
            this.comboBoxServer.Name = "comboBoxServer";
            this.comboBoxServer.Size = new System.Drawing.Size(84, 21);
            this.comboBoxServer.TabIndex = 1;
            this.comboBoxServer.SelectedIndexChanged += new System.EventHandler(this.comboBoxServer_SelectedIndexChanged);
            // 
            // Login
            // 
            this.AcceptButton = this.loginButton;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.CancelButton = this.quitButton;
            this.ClientSize = new System.Drawing.Size(493, 305);
            this.ControlBox = false;
            this.Controls.Add(this.comboBoxServer);
            this.Controls.Add(this.getUpdate);
            this.Controls.Add(this.audioSettings);
            this.Controls.Add(this.comboBoxOutput);
            this.Controls.Add(this.comboBoxRecord);
            this.Controls.Add(this.comboBoxPlayback);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.passwordBox);
            this.Controls.Add(this.quitButton);
            this.Controls.Add(this.loginButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.usernameBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Login";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login to Karaoke MONSTER";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox usernameBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button loginButton;
        private System.Windows.Forms.Button quitButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox passwordBox;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox comboBoxPlayback;
        private System.Windows.Forms.ComboBox comboBoxRecord;
        private System.Windows.Forms.ComboBox comboBoxOutput;
        private System.Windows.Forms.Button audioSettings;
        private System.Windows.Forms.Button getUpdate;
        private System.Windows.Forms.ComboBox comboBoxServer;
    }
}