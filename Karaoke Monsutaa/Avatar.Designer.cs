namespace Karaoke_Monsutaa
{
    partial class Avatar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Avatar));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.idleMiku = new System.Windows.Forms.PictureBox();
            this.dancingMiku = new System.Windows.Forms.PictureBox();
            this.singingMiku = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.idleMiku)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dancingMiku)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.singingMiku)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(247, 246);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // idleMiku
            // 
            this.idleMiku.Image = ((System.Drawing.Image)(resources.GetObject("idleMiku.Image")));
            this.idleMiku.Location = new System.Drawing.Point(12, 83);
            this.idleMiku.Name = "idleMiku";
            this.idleMiku.Size = new System.Drawing.Size(100, 50);
            this.idleMiku.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.idleMiku.TabIndex = 7;
            this.idleMiku.TabStop = false;
            this.idleMiku.Visible = false;
            // 
            // dancingMiku
            // 
            this.dancingMiku.Image = ((System.Drawing.Image)(resources.GetObject("dancingMiku.Image")));
            this.dancingMiku.Location = new System.Drawing.Point(118, 24);
            this.dancingMiku.Name = "dancingMiku";
            this.dancingMiku.Size = new System.Drawing.Size(100, 50);
            this.dancingMiku.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.dancingMiku.TabIndex = 9;
            this.dancingMiku.TabStop = false;
            this.dancingMiku.Visible = false;
            // 
            // singingMiku
            // 
            this.singingMiku.Image = ((System.Drawing.Image)(resources.GetObject("singingMiku.Image")));
            this.singingMiku.Location = new System.Drawing.Point(-188, -28);
            this.singingMiku.Name = "singingMiku";
            this.singingMiku.Size = new System.Drawing.Size(467, 278);
            this.singingMiku.TabIndex = 8;
            this.singingMiku.TabStop = false;
            this.singingMiku.Visible = false;
            // 
            // Avatar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.idleMiku);
            this.Controls.Add(this.dancingMiku);
            this.Controls.Add(this.singingMiku);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Avatar";
            this.Size = new System.Drawing.Size(247, 246);
            this.Load += new System.EventHandler(this.Avatar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.idleMiku)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dancingMiku)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.singingMiku)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox idleMiku;
        private System.Windows.Forms.PictureBox dancingMiku;
        private System.Windows.Forms.PictureBox singingMiku;

    }
}
