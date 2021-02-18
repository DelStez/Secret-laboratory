namespace Admin
{
    partial class AdminClientForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminClientForm));
            this.TrayModeMenuStrip = new System.Windows.Forms.ContextMenuStrip();
            this.AboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sendTextBox = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.оПрограммеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addrTextBox = new System.Windows.Forms.TextBox();
            this.keyLabel = new System.Windows.Forms.Label();
            this.keyTextBox = new System.Windows.Forms.TextBox();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.usernameTextBox = new System.Windows.Forms.TextBox();
            this.portLabel = new System.Windows.Forms.Label();
            this.localaddrLabel = new System.Windows.Forms.Label();
            this.portTextBox = new System.Windows.Forms.TextBox();
            this.logTextBox = new System.Windows.Forms.TextBox();
            this.clearButton = new System.Windows.Forms.Button();
            this.connectButton = new System.Windows.Forms.Button();
            this.statuslabel = new System.Windows.Forms.Label();
            this.TrayModeMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TrayModeMenuStrip
            // 
            this.TrayModeMenuStrip.AccessibleRole = System.Windows.Forms.AccessibleRole.Client;
            this.TrayModeMenuStrip.AllowMerge = false;
            this.TrayModeMenuStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(23)))), ((int)(((byte)(23)))));
            this.TrayModeMenuStrip.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TrayModeMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AboutToolStripMenuItem,
            this.ExitToolStripMenuItem});
            this.TrayModeMenuStrip.Name = "TrayModeMenuStrip";
            this.TrayModeMenuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.TrayModeMenuStrip.ShowImageMargin = false;
            this.TrayModeMenuStrip.ShowItemToolTips = false;
            this.TrayModeMenuStrip.Size = new System.Drawing.Size(156, 70);
            // 
            // AboutToolStripMenuItem
            // 
            this.AboutToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.AboutToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem";
            this.AboutToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.AboutToolStripMenuItem.Text = "О программе...";
            this.AboutToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.AboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItem_Click);
            // 
            // ExitToolStripMenuItem
            // 
            this.ExitToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ExitToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            this.ExitToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.ExitToolStripMenuItem.Text = "Выход";
            this.ExitToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.ExitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // sendTextBox
            // 
            this.sendTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.sendTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sendTextBox.Location = new System.Drawing.Point(205, 409);
            this.sendTextBox.Name = "sendTextBox";
            this.sendTextBox.Size = new System.Drawing.Size(504, 20);
            this.sendTextBox.TabIndex = 2;
            this.sendTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SendTextBox_KeyDown);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(3, 31);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(60, 60);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(69, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 18);
            this.label1.TabIndex = 4;
            this.label1.Text = "Клиент";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.menuStrip1.ImeMode = System.Windows.Forms.ImeMode.On;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.оПрограммеToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip1.Size = new System.Drawing.Size(716, 24);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // оПрограммеToolStripMenuItem
            // 
            this.оПрограммеToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.оПрограммеToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            this.оПрограммеToolStripMenuItem.Size = new System.Drawing.Size(103, 20);
            this.оПрограммеToolStripMenuItem.Text = "О программе...";
            this.оПрограммеToolStripMenuItem.Click += new System.EventHandler(this.оПрограммеToolStripMenuItem_Click);
            // 
            // addrTextBox
            // 
            this.addrTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.addrTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.addrTextBox.ForeColor = System.Drawing.SystemColors.Menu;
            this.addrTextBox.Location = new System.Drawing.Point(65, 98);
            this.addrTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.addrTextBox.MaxLength = 200;
            this.addrTextBox.Name = "addrTextBox";
            this.addrTextBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.addrTextBox.Size = new System.Drawing.Size(132, 20);
            this.addrTextBox.TabIndex = 47;
            this.addrTextBox.TabStop = false;
            this.addrTextBox.Text = "127.0.0.1";
            this.addrTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // keyLabel
            // 
            this.keyLabel.AutoSize = true;
            this.keyLabel.Location = new System.Drawing.Point(32, 157);
            this.keyLabel.Margin = new System.Windows.Forms.Padding(8, 0, 1, 0);
            this.keyLabel.Name = "keyLabel";
            this.keyLabel.Size = new System.Drawing.Size(28, 13);
            this.keyLabel.TabIndex = 46;
            this.keyLabel.Text = "Key:";
            // 
            // keyTextBox
            // 
            this.keyTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.keyTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.keyTextBox.ForeColor = System.Drawing.SystemColors.Menu;
            this.keyTextBox.Location = new System.Drawing.Point(65, 154);
            this.keyTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.keyTextBox.MaxLength = 200;
            this.keyTextBox.Name = "keyTextBox";
            this.keyTextBox.Size = new System.Drawing.Size(132, 20);
            this.keyTextBox.TabIndex = 45;
            this.keyTextBox.TabStop = false;
            this.keyTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Location = new System.Drawing.Point(0, 217);
            this.usernameLabel.Margin = new System.Windows.Forms.Padding(8, 0, 1, 0);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(58, 13);
            this.usernameLabel.TabIndex = 44;
            this.usernameLabel.Text = "Username:";
            // 
            // usernameTextBox
            // 
            this.usernameTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.usernameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.usernameTextBox.ForeColor = System.Drawing.SystemColors.Menu;
            this.usernameTextBox.Location = new System.Drawing.Point(65, 214);
            this.usernameTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.usernameTextBox.MaxLength = 50;
            this.usernameTextBox.Name = "usernameTextBox";
            this.usernameTextBox.ReadOnly = true;
            this.usernameTextBox.Size = new System.Drawing.Size(132, 20);
            this.usernameTextBox.TabIndex = 43;
            this.usernameTextBox.TabStop = false;
            this.usernameTextBox.Text = "Client";
            this.usernameTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // portLabel
            // 
            this.portLabel.AutoSize = true;
            this.portLabel.Location = new System.Drawing.Point(31, 133);
            this.portLabel.Margin = new System.Windows.Forms.Padding(8, 0, 1, 0);
            this.portLabel.Name = "portLabel";
            this.portLabel.Size = new System.Drawing.Size(29, 13);
            this.portLabel.TabIndex = 42;
            this.portLabel.Text = "Port:";
            // 
            // localaddrLabel
            // 
            this.localaddrLabel.AutoSize = true;
            this.localaddrLabel.Location = new System.Drawing.Point(12, 101);
            this.localaddrLabel.Margin = new System.Windows.Forms.Padding(8, 0, 1, 0);
            this.localaddrLabel.Name = "localaddrLabel";
            this.localaddrLabel.Size = new System.Drawing.Size(48, 13);
            this.localaddrLabel.TabIndex = 41;
            this.localaddrLabel.Text = "Address:";
            // 
            // portTextBox
            // 
            this.portTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.portTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.portTextBox.ForeColor = System.Drawing.SystemColors.Menu;
            this.portTextBox.Location = new System.Drawing.Point(65, 126);
            this.portTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.portTextBox.MaxLength = 10;
            this.portTextBox.Name = "portTextBox";
            this.portTextBox.Size = new System.Drawing.Size(132, 20);
            this.portTextBox.TabIndex = 40;
            this.portTextBox.TabStop = false;
            this.portTextBox.Text = "9000";
            this.portTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // logTextBox
            // 
            this.logTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.logTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.logTextBox.ForeColor = System.Drawing.SystemColors.Menu;
            this.logTextBox.Location = new System.Drawing.Point(205, 58);
            this.logTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.logTextBox.Multiline = true;
            this.logTextBox.Name = "logTextBox";
            this.logTextBox.ReadOnly = true;
            this.logTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.logTextBox.Size = new System.Drawing.Size(504, 344);
            this.logTextBox.TabIndex = 48;
            this.logTextBox.TabStop = false;
            // 
            // clearButton
            // 
            this.clearButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(105)))), ((int)(((byte)(0)))));
            this.clearButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clearButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.clearButton.Location = new System.Drawing.Point(593, 28);
            this.clearButton.Margin = new System.Windows.Forms.Padding(4);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(116, 28);
            this.clearButton.TabIndex = 50;
            this.clearButton.TabStop = false;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = false;
            this.clearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // connectButton
            // 
            this.connectButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(105)))), ((int)(((byte)(0)))));
            this.connectButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.connectButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.connectButton.Location = new System.Drawing.Point(65, 252);
            this.connectButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 10);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(116, 28);
            this.connectButton.TabIndex = 49;
            this.connectButton.TabStop = false;
            this.connectButton.Text = "Connect";
            this.connectButton.UseVisualStyleBackColor = false;
            this.connectButton.Click += new System.EventHandler(this.ConnectButton_Click);
            // 
            // statuslabel
            // 
            this.statuslabel.AutoSize = true;
            this.statuslabel.Location = new System.Drawing.Point(202, 36);
            this.statuslabel.Name = "statuslabel";
            this.statuslabel.Size = new System.Drawing.Size(0, 13);
            this.statuslabel.TabIndex = 51;
            // 
            // AdminClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(23)))), ((int)(((byte)(23)))));
            this.ClientSize = new System.Drawing.Size(716, 439);
            this.Controls.Add(this.statuslabel);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.connectButton);
            this.Controls.Add(this.logTextBox);
            this.Controls.Add(this.addrTextBox);
            this.Controls.Add(this.keyLabel);
            this.Controls.Add(this.keyTextBox);
            this.Controls.Add(this.usernameLabel);
            this.Controls.Add(this.usernameTextBox);
            this.Controls.Add(this.portLabel);
            this.Controls.Add(this.localaddrLabel);
            this.Controls.Add(this.portTextBox);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.sendTextBox);
            this.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "AdminClientForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Admin-Client";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AdminClientForm_FormClosing);
            this.Load += new System.EventHandler(this.AdminClientForm_Load);
            this.TrayModeMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip TrayModeMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem AboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ExitToolStripMenuItem;
        private System.Windows.Forms.TextBox sendTextBox;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem оПрограммеToolStripMenuItem;
        private System.Windows.Forms.TextBox addrTextBox;
        private System.Windows.Forms.Label keyLabel;
        private System.Windows.Forms.TextBox keyTextBox;
        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.TextBox usernameTextBox;
        private System.Windows.Forms.Label portLabel;
        private System.Windows.Forms.Label localaddrLabel;
        private System.Windows.Forms.TextBox portTextBox;
        private System.Windows.Forms.TextBox logTextBox;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.Label statuslabel;
    }
}

