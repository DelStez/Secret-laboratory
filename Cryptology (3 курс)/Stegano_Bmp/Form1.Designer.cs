namespace Stegano_Bmp
{
    partial class mainWindow
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
            this.pathFile = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.getImage = new System.Windows.Forms.Button();
            this.pathImage = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureShow = new System.Windows.Forms.PictureBox();
            this.messageShow = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.Coder = new System.Windows.Forms.Button();
            this.Decoder = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureShow)).BeginInit();
            this.SuspendLayout();
            // 
            // pathFile
            // 
            this.pathFile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(177)))), ((int)(((byte)(157)))));
            this.pathFile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pathFile.Location = new System.Drawing.Point(87, 38);
            this.pathFile.Name = "pathFile";
            this.pathFile.ReadOnly = true;
            this.pathFile.Size = new System.Drawing.Size(209, 20);
            this.pathFile.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Сообщение";
            // 
            // getImage
            // 
            this.getImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(249)))));
            this.getImage.Location = new System.Drawing.Point(302, 11);
            this.getImage.Name = "getImage";
            this.getImage.Size = new System.Drawing.Size(75, 20);
            this.getImage.TabIndex = 9;
            this.getImage.Text = "...";
            this.getImage.UseVisualStyleBackColor = false;
            this.getImage.Click += new System.EventHandler(this.GetImage_Click);
            // 
            // pathImage
            // 
            this.pathImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(177)))), ((int)(((byte)(157)))));
            this.pathImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pathImage.Location = new System.Drawing.Point(87, 12);
            this.pathImage.Name = "pathImage";
            this.pathImage.ReadOnly = true;
            this.pathImage.Size = new System.Drawing.Size(209, 20);
            this.pathImage.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Изображение";
            // 
            // pictureShow
            // 
            this.pictureShow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(177)))), ((int)(((byte)(157)))));
            this.pictureShow.Location = new System.Drawing.Point(7, 108);
            this.pictureShow.Name = "pictureShow";
            this.pictureShow.Size = new System.Drawing.Size(328, 364);
            this.pictureShow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureShow.TabIndex = 13;
            this.pictureShow.TabStop = false;
            // 
            // messageShow
            // 
            this.messageShow.Location = new System.Drawing.Point(341, 108);
            this.messageShow.Multiline = true;
            this.messageShow.Name = "messageShow";
            this.messageShow.ReadOnly = true;
            this.messageShow.Size = new System.Drawing.Size(243, 364);
            this.messageShow.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Изображение";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(341, 92);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(117, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Сообщение (only read)";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(249)))));
            this.button2.Location = new System.Drawing.Point(302, 38);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 20);
            this.button2.TabIndex = 12;
            this.button2.Text = "...";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.GetTXT_Click);
            // 
            // Coder
            // 
            this.Coder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(249)))));
            this.Coder.Location = new System.Drawing.Point(422, 12);
            this.Coder.Name = "Coder";
            this.Coder.Size = new System.Drawing.Size(162, 19);
            this.Coder.TabIndex = 19;
            this.Coder.Text = "Закодировать";
            this.Coder.UseVisualStyleBackColor = false;
            this.Coder.Click += new System.EventHandler(this.Coder_Click);
            // 
            // Decoder
            // 
            this.Decoder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(249)))));
            this.Decoder.Location = new System.Drawing.Point(422, 37);
            this.Decoder.Name = "Decoder";
            this.Decoder.Size = new System.Drawing.Size(162, 20);
            this.Decoder.TabIndex = 20;
            this.Decoder.Text = "Декодировать";
            this.Decoder.UseVisualStyleBackColor = false;
            this.Decoder.Click += new System.EventHandler(this.Decoder_Click);
            // 
            // mainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(218)))), ((int)(((byte)(207)))));
            this.ClientSize = new System.Drawing.Size(589, 481);
            this.Controls.Add(this.Decoder);
            this.Controls.Add(this.Coder);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.messageShow);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureShow);
            this.Controls.Add(this.pathImage);
            this.Controls.Add(this.getImage);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pathFile);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "mainWindow";
            this.Text = "LSB";
            ((System.ComponentModel.ISupportInitialize)(this.pictureShow)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox pathFile;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button getImage;
        private System.Windows.Forms.TextBox pathImage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureShow;
        private System.Windows.Forms.TextBox messageShow;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button Coder;
        private System.Windows.Forms.Button Decoder;
    }
}

