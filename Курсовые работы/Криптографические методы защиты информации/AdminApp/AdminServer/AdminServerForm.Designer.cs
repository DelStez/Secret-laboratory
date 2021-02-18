namespace AdminServer
{
    partial class AdminServerForm
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminServerForm));
            this.TrayModeMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.AboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.оПрограммеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.regedit = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.disks = new System.Windows.Forms.CheckBox();
            this.files = new System.Windows.Forms.CheckBox();
            this.statusBox = new System.Windows.Forms.TextBox();
            this.clientsDataGridView = new System.Windows.Forms.DataGridView();
            this.IDuser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DC = new System.Windows.Forms.DataGridViewButtonColumn();
            this.GetInfo = new System.Windows.Forms.DataGridViewButtonColumn();
            this.logTextBox = new System.Windows.Forms.TextBox();
            this.sendTextBox = new System.Windows.Forms.TextBox();
            this.clearButton = new System.Windows.Forms.Button();
            this.startButton = new System.Windows.Forms.Button();
            this.addrTextBox = new System.Windows.Forms.TextBox();
            this.keyTextBox = new System.Windows.Forms.TextBox();
            this.keyLabel = new System.Windows.Forms.Label();
            this.usernameTextBox = new System.Windows.Forms.TextBox();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.portLabel = new System.Windows.Forms.Label();
            this.localaddrLabel = new System.Windows.Forms.Label();
            this.portTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.TrayModeMenuStrip.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.clientsDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
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
            this.TrayModeMenuStrip.Size = new System.Drawing.Size(134, 48);
            // 
            // AboutToolStripMenuItem
            // 
            this.AboutToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.AboutToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem";
            this.AboutToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.AboutToolStripMenuItem.Text = "О программе...";
            this.AboutToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.AboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItem_Click);
            // 
            // ExitToolStripMenuItem
            // 
            this.ExitToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ExitToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            this.ExitToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.ExitToolStripMenuItem.Text = "Выход";
            this.ExitToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.ExitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
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
            this.menuStrip1.Size = new System.Drawing.Size(832, 24);
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
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.groupBox1.Controls.Add(this.regedit);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.disks);
            this.groupBox1.Controls.Add(this.files);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.groupBox1.Location = new System.Drawing.Point(386, 58);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(439, 91);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            // 
            // regedit
            // 
            this.regedit.AutoSize = true;
            this.regedit.Location = new System.Drawing.Point(9, 66);
            this.regedit.Name = "regedit";
            this.regedit.Size = new System.Drawing.Size(62, 17);
            this.regedit.TabIndex = 21;
            this.regedit.Text = "Реестр";
            this.regedit.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(145, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Информационные ресурсы";
            // 
            // disks
            // 
            this.disks.AutoSize = true;
            this.disks.Location = new System.Drawing.Point(9, 32);
            this.disks.Name = "disks";
            this.disks.Size = new System.Drawing.Size(59, 17);
            this.disks.TabIndex = 19;
            this.disks.Text = "Диски";
            this.disks.UseVisualStyleBackColor = true;
            // 
            // files
            // 
            this.files.AutoSize = true;
            this.files.Location = new System.Drawing.Point(9, 48);
            this.files.Name = "files";
            this.files.Size = new System.Drawing.Size(63, 17);
            this.files.TabIndex = 20;
            this.files.Text = "Файлы";
            this.files.UseVisualStyleBackColor = true;
            // 
            // statusBox
            // 
            this.statusBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.statusBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.statusBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.statusBox.Location = new System.Drawing.Point(386, 29);
            this.statusBox.Multiline = true;
            this.statusBox.Name = "statusBox";
            this.statusBox.ReadOnly = true;
            this.statusBox.Size = new System.Drawing.Size(439, 23);
            this.statusBox.TabIndex = 23;
            this.statusBox.Text = "----------------------------------------------";
            this.statusBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // clientsDataGridView
            // 
            this.clientsDataGridView.AllowUserToAddRows = false;
            this.clientsDataGridView.AllowUserToDeleteRows = false;
            this.clientsDataGridView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.clientsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.clientsDataGridView.ColumnHeadersVisible = false;
            this.clientsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDuser,
            this.IP,
            this.DC,
            this.GetInfo});
            this.clientsDataGridView.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(105)))), ((int)(((byte)(0)))));
            this.clientsDataGridView.Location = new System.Drawing.Point(386, 155);
            this.clientsDataGridView.Name = "clientsDataGridView";
            this.clientsDataGridView.ReadOnly = true;
            this.clientsDataGridView.RowHeadersVisible = false;
            this.clientsDataGridView.Size = new System.Drawing.Size(439, 308);
            this.clientsDataGridView.TabIndex = 26;
            this.clientsDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ClientsDataGridView_CellClick);
            // 
            // IDuser
            // 
            this.IDuser.Frozen = true;
            this.IDuser.HeaderText = "ID";
            this.IDuser.Name = "IDuser";
            this.IDuser.ReadOnly = true;
            // 
            // IP
            // 
            this.IP.Frozen = true;
            this.IP.HeaderText = "Name";
            this.IP.Name = "IP";
            this.IP.ReadOnly = true;
            // 
            // DC
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(118)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.DC.DefaultCellStyle = dataGridViewCellStyle1;
            this.DC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DC.HeaderText = "Удалить из сессии";
            this.DC.Name = "DC";
            this.DC.ReadOnly = true;
            this.DC.Text = "Удалить из сессии";
            this.DC.UseColumnTextForButtonValue = true;
            // 
            // GetInfo
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(108)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            this.GetInfo.DefaultCellStyle = dataGridViewCellStyle2;
            this.GetInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GetInfo.HeaderText = "Получить информацию";
            this.GetInfo.Name = "GetInfo";
            this.GetInfo.ReadOnly = true;
            this.GetInfo.Text = "Получить данные";
            this.GetInfo.UseColumnTextForButtonValue = true;
            // 
            // logTextBox
            // 
            this.logTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.logTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.logTextBox.ForeColor = System.Drawing.SystemColors.Info;
            this.logTextBox.Location = new System.Drawing.Point(7, 311);
            this.logTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.logTextBox.Multiline = true;
            this.logTextBox.Name = "logTextBox";
            this.logTextBox.ReadOnly = true;
            this.logTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.logTextBox.Size = new System.Drawing.Size(372, 124);
            this.logTextBox.TabIndex = 28;
            this.logTextBox.TabStop = false;
            // 
            // sendTextBox
            // 
            this.sendTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.sendTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sendTextBox.ForeColor = System.Drawing.SystemColors.Info;
            this.sendTextBox.Location = new System.Drawing.Point(7, 443);
            this.sendTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.sendTextBox.Name = "sendTextBox";
            this.sendTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.sendTextBox.Size = new System.Drawing.Size(372, 20);
            this.sendTextBox.TabIndex = 29;
            this.sendTextBox.TabStop = false;
            this.sendTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SendTextBox_KeyDown);
            // 
            // clearButton
            // 
            this.clearButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.clearButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clearButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.clearButton.Location = new System.Drawing.Point(247, 280);
            this.clearButton.Margin = new System.Windows.Forms.Padding(4);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(132, 23);
            this.clearButton.TabIndex = 31;
            this.clearButton.TabStop = false;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = false;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // startButton
            // 
            this.startButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.startButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.startButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.startButton.Location = new System.Drawing.Point(247, 157);
            this.startButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 10);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(132, 23);
            this.startButton.TabIndex = 30;
            this.startButton.TabStop = false;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = false;
            this.startButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // addrTextBox
            // 
            this.addrTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.addrTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.addrTextBox.ForeColor = System.Drawing.SystemColors.Info;
            this.addrTextBox.Location = new System.Drawing.Point(69, 104);
            this.addrTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.addrTextBox.MaxLength = 200;
            this.addrTextBox.Name = "addrTextBox";
            this.addrTextBox.Size = new System.Drawing.Size(132, 20);
            this.addrTextBox.TabIndex = 45;
            this.addrTextBox.TabStop = false;
            this.addrTextBox.Text = "127.0.0.1";
            this.addrTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // keyTextBox
            // 
            this.keyTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.keyTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.keyTextBox.ForeColor = System.Drawing.SystemColors.Info;
            this.keyTextBox.Location = new System.Drawing.Point(247, 129);
            this.keyTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.keyTextBox.MaxLength = 200;
            this.keyTextBox.Name = "keyTextBox";
            this.keyTextBox.Size = new System.Drawing.Size(132, 20);
            this.keyTextBox.TabIndex = 44;
            this.keyTextBox.TabStop = false;
            this.keyTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // keyLabel
            // 
            this.keyLabel.AutoSize = true;
            this.keyLabel.Location = new System.Drawing.Point(213, 132);
            this.keyLabel.Margin = new System.Windows.Forms.Padding(8, 0, 1, 0);
            this.keyLabel.Name = "keyLabel";
            this.keyLabel.Size = new System.Drawing.Size(28, 13);
            this.keyLabel.TabIndex = 43;
            this.keyLabel.Text = "Key:";
            // 
            // usernameTextBox
            // 
            this.usernameTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.usernameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.usernameTextBox.ForeColor = System.Drawing.SystemColors.Info;
            this.usernameTextBox.Location = new System.Drawing.Point(69, 129);
            this.usernameTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.usernameTextBox.MaxLength = 50;
            this.usernameTextBox.Name = "usernameTextBox";
            this.usernameTextBox.Size = new System.Drawing.Size(132, 20);
            this.usernameTextBox.TabIndex = 42;
            this.usernameTextBox.TabStop = false;
            this.usernameTextBox.Text = "Server";
            this.usernameTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Location = new System.Drawing.Point(12, 132);
            this.usernameLabel.Margin = new System.Windows.Forms.Padding(8, 0, 1, 0);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(52, 13);
            this.usernameLabel.TabIndex = 41;
            this.usernameLabel.Text = "Userame:";
            // 
            // portLabel
            // 
            this.portLabel.AutoSize = true;
            this.portLabel.Location = new System.Drawing.Point(213, 107);
            this.portLabel.Margin = new System.Windows.Forms.Padding(8, 0, 1, 0);
            this.portLabel.Name = "portLabel";
            this.portLabel.Size = new System.Drawing.Size(29, 13);
            this.portLabel.TabIndex = 40;
            this.portLabel.Text = "Port:";
            // 
            // localaddrLabel
            // 
            this.localaddrLabel.AutoSize = true;
            this.localaddrLabel.Location = new System.Drawing.Point(16, 107);
            this.localaddrLabel.Margin = new System.Windows.Forms.Padding(8, 0, 1, 0);
            this.localaddrLabel.Name = "localaddrLabel";
            this.localaddrLabel.Size = new System.Drawing.Size(48, 13);
            this.localaddrLabel.TabIndex = 39;
            this.localaddrLabel.Text = "Address:";
            // 
            // portTextBox
            // 
            this.portTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.portTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.portTextBox.ForeColor = System.Drawing.SystemColors.Info;
            this.portTextBox.Location = new System.Drawing.Point(247, 104);
            this.portTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.portTextBox.MaxLength = 10;
            this.portTextBox.Name = "portTextBox";
            this.portTextBox.Size = new System.Drawing.Size(132, 20);
            this.portTextBox.TabIndex = 38;
            this.portTextBox.TabStop = false;
            this.portTextBox.Text = "9000";
            this.portTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(73, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 18);
            this.label1.TabIndex = 47;
            this.label1.Text = "Сервер";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(7, 37);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(60, 60);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 46;
            this.pictureBox1.TabStop = false;
            // 
            // AdminServerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.ClientSize = new System.Drawing.Size(832, 469);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.addrTextBox);
            this.Controls.Add(this.keyTextBox);
            this.Controls.Add(this.keyLabel);
            this.Controls.Add(this.usernameTextBox);
            this.Controls.Add(this.usernameLabel);
            this.Controls.Add(this.portLabel);
            this.Controls.Add(this.localaddrLabel);
            this.Controls.Add(this.portTextBox);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.sendTextBox);
            this.Controls.Add(this.logTextBox);
            this.Controls.Add(this.clientsDataGridView);
            this.Controls.Add(this.statusBox);
            this.Controls.Add(this.menuStrip1);
            this.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "AdminServerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Admin-Server";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AdminServerForm_FormClosing);
            this.Load += new System.EventHandler(this.AdminServerForm_Load);
            this.TrayModeMenuStrip.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.clientsDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip TrayModeMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem AboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ExitToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem оПрограммеToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox statusBox;
        private System.Windows.Forms.DataGridView clientsDataGridView;
        private System.Windows.Forms.CheckBox regedit;
        private System.Windows.Forms.CheckBox files;
        private System.Windows.Forms.CheckBox disks;
        private System.Windows.Forms.TextBox logTextBox;
        private System.Windows.Forms.TextBox sendTextBox;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.TextBox addrTextBox;
        private System.Windows.Forms.TextBox keyTextBox;
        private System.Windows.Forms.Label keyLabel;
        private System.Windows.Forms.TextBox usernameTextBox;
        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.Label portLabel;
        private System.Windows.Forms.Label localaddrLabel;
        private System.Windows.Forms.TextBox portTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDuser;
        private System.Windows.Forms.DataGridViewTextBoxColumn IP;
        private System.Windows.Forms.DataGridViewButtonColumn DC;
        private System.Windows.Forms.DataGridViewButtonColumn GetInfo;
    }
}

