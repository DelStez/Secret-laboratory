namespace Rijndael
{
    partial class Form1
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
            this.tbKey = new System.Windows.Forms.TextBox();
            this.tbPlain = new System.Windows.Forms.TextBox();
            this.CipherButon = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.DecipherButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tbCipher = new System.Windows.Forms.TextBox();
            this.DownlodKey = new System.Windows.Forms.Button();
            this.DownloadFile = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbKey
            // 
            this.tbKey.Location = new System.Drawing.Point(54, 42);
            this.tbKey.Name = "tbKey";
            this.tbKey.Size = new System.Drawing.Size(328, 20);
            this.tbKey.TabIndex = 3;
            this.tbKey.TextChanged += new System.EventHandler(this.TextChanged);
            this.tbKey.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.HexKeyPress);
            // 
            // tbPlain
            // 
            this.tbPlain.Location = new System.Drawing.Point(9, 163);
            this.tbPlain.Multiline = true;
            this.tbPlain.Name = "tbPlain";
            this.tbPlain.Size = new System.Drawing.Size(511, 115);
            this.tbPlain.TabIndex = 4;
            this.tbPlain.TextChanged += new System.EventHandler(this.TextChanged);
            this.tbPlain.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.HexKeyPress);
            // 
            // CipherButon
            // 
            this.CipherButon.Enabled = false;
            this.CipherButon.Location = new System.Drawing.Point(9, 418);
            this.CipherButon.Name = "CipherButon";
            this.CipherButon.Size = new System.Drawing.Size(132, 20);
            this.CipherButon.TabIndex = 6;
            this.CipherButon.Text = "Шифровать";
            this.CipherButon.UseVisualStyleBackColor = true;
            this.CipherButon.Click += new System.EventHandler(this.cipher_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Ключ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 143);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Открытый";
            // 
            // DecipherButton
            // 
            this.DecipherButton.Enabled = false;
            this.DecipherButton.Location = new System.Drawing.Point(388, 418);
            this.DecipherButton.Name = "DecipherButton";
            this.DecipherButton.Size = new System.Drawing.Size(132, 20);
            this.DecipherButton.TabIndex = 18;
            this.DecipherButton.Text = "Дешифровать";
            this.DecipherButton.UseVisualStyleBackColor = true;
            this.DecipherButton.Click += new System.EventHandler(this.DecipherButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 281);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Шифр";
            // 
            // tbCipher
            // 
            this.tbCipher.Location = new System.Drawing.Point(9, 297);
            this.tbCipher.Multiline = true;
            this.tbCipher.Name = "tbCipher";
            this.tbCipher.Size = new System.Drawing.Size(511, 115);
            this.tbCipher.TabIndex = 21;
            this.tbCipher.TextChanged += new System.EventHandler(this.TextChanged);
            this.tbCipher.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.HexKeyPress);
            // 
            // DownlodKey
            // 
            this.DownlodKey.Location = new System.Drawing.Point(388, 42);
            this.DownlodKey.Name = "DownlodKey";
            this.DownlodKey.Size = new System.Drawing.Size(132, 20);
            this.DownlodKey.TabIndex = 16;
            this.DownlodKey.Text = "Загрузить";
            this.DownlodKey.UseVisualStyleBackColor = true;
            this.DownlodKey.Click += new System.EventHandler(this.DownlodKey_Click);
            // 
            // DownloadFile
            // 
            this.DownloadFile.Location = new System.Drawing.Point(112, 139);
            this.DownloadFile.Name = "DownloadFile";
            this.DownloadFile.Size = new System.Drawing.Size(132, 20);
            this.DownloadFile.TabIndex = 17;
            this.DownloadFile.Text = "Загрузить файл";
            this.DownloadFile.UseVisualStyleBackColor = true;
            this.DownloadFile.Click += new System.EventHandler(this.DownloadFile_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(388, 139);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(132, 20);
            this.button1.TabIndex = 22;
            this.button1.Text = "Сохранить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(250, 139);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(132, 20);
            this.button2.TabIndex = 23;
            this.button2.Text = "Swap";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 13);
            this.label1.TabIndex = 24;
            this.label1.Text = "IV";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(54, 85);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(273, 20);
            this.textBox1.TabIndex = 25;
            this.textBox1.TextChanged += new System.EventHandler(this.TextChanged);
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.HexKeyPress);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(333, 84);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(95, 21);
            this.button3.TabIndex = 26;
            this.button3.Text = "Генерация";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.comboBox1.Items.AddRange(new object[] {
            "ECB",
            "CBC",
            "CFB",
            "OFB"});
            this.comboBox1.Location = new System.Drawing.Point(54, 12);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 27;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 13);
            this.label5.TabIndex = 28;
            this.label5.Text = "Режим";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(434, 85);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(86, 21);
            this.button4.TabIndex = 29;
            this.button4.Text = "Применить";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(529, 442);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tbCipher);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.DecipherButton);
            this.Controls.Add(this.DownloadFile);
            this.Controls.Add(this.DownlodKey);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.CipherButon);
            this.Controls.Add(this.tbPlain);
            this.Controls.Add(this.tbKey);
            this.Name = "Form1";
            this.Text = "AES(Rijndael)";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox tbKey;
        private System.Windows.Forms.TextBox tbPlain;
        private System.Windows.Forms.Button CipherButon;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button DecipherButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbCipher;
        private System.Windows.Forms.Button DownlodKey;
        private System.Windows.Forms.Button DownloadFile;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button4;
    }
}

