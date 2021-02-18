namespace Admin
{
    partial class About
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(About));
            this.NameApp = new System.Windows.Forms.Label();
            this.WhoCreate = new System.Windows.Forms.Label();
            this.IconBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.IconBox)).BeginInit();
            this.SuspendLayout();
            // 
            // NameApp
            // 
            this.NameApp.AutoSize = true;
            this.NameApp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NameApp.Location = new System.Drawing.Point(114, 19);
            this.NameApp.Name = "NameApp";
            this.NameApp.Size = new System.Drawing.Size(89, 15);
            this.NameApp.TabIndex = 0;
            this.NameApp.Text = "Admin-Client";
            // 
            // WhoCreate
            // 
            this.WhoCreate.AutoSize = true;
            this.WhoCreate.Location = new System.Drawing.Point(114, 64);
            this.WhoCreate.Name = "WhoCreate";
            this.WhoCreate.Size = new System.Drawing.Size(136, 13);
            this.WhoCreate.TabIndex = 1;
            this.WhoCreate.Text = "© Кандакова А.Н ,2020 г.";
            // 
            // IconBox
            // 
            this.IconBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.IconBox.Image = ((System.Drawing.Image)(resources.GetObject("IconBox.Image")));
            this.IconBox.Location = new System.Drawing.Point(43, 19);
            this.IconBox.Name = "IconBox";
            this.IconBox.Size = new System.Drawing.Size(65, 58);
            this.IconBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.IconBox.TabIndex = 2;
            this.IconBox.TabStop = false;
            // 
            // About
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(23)))), ((int)(((byte)(23)))));
            this.ClientSize = new System.Drawing.Size(313, 92);
            this.Controls.Add(this.IconBox);
            this.Controls.Add(this.WhoCreate);
            this.Controls.Add(this.NameApp);
            this.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "About";
            this.Text = "About";
            ((System.ComponentModel.ISupportInitialize)(this.IconBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label NameApp;
        private System.Windows.Forms.Label WhoCreate;
        protected System.Windows.Forms.PictureBox IconBox;
    }
}