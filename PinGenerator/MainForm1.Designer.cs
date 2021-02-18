
namespace PinGenerator
{
    partial class MainForm
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
            this.comboBoxLen = new System.Windows.Forms.ComboBox();
            this.lengthPin = new System.Windows.Forms.Label();
            this.NumberLabel = new System.Windows.Forms.Label();
            this.numberClient = new System.Windows.Forms.TextBox();
            this.PinBox = new System.Windows.Forms.TextBox();
            this.CodeLabel = new System.Windows.Forms.Label();
            this.GenButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBoxLen
            // 
            this.comboBoxLen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxLen.Items.AddRange(new object[] {
            "4",
            "8",
            "12"});
            this.comboBoxLen.Location = new System.Drawing.Point(108, 55);
            this.comboBoxLen.Name = "comboBoxLen";
            this.comboBoxLen.Size = new System.Drawing.Size(110, 21);
            this.comboBoxLen.TabIndex = 0;
            // 
            // lengthPin
            // 
            this.lengthPin.AutoSize = true;
            this.lengthPin.Location = new System.Drawing.Point(11, 58);
            this.lengthPin.Name = "lengthPin";
            this.lengthPin.Size = new System.Drawing.Size(91, 13);
            this.lengthPin.TabIndex = 1;
            this.lengthPin.Text = "Длина PIN-кода:";
            // 
            // NumberLabel
            // 
            this.NumberLabel.AutoSize = true;
            this.NumberLabel.Location = new System.Drawing.Point(70, 24);
            this.NumberLabel.Name = "NumberLabel";
            this.NumberLabel.Size = new System.Drawing.Size(32, 13);
            this.NumberLabel.TabIndex = 2;
            this.NumberLabel.Text = "PAN:";
            // 
            // numberClient
            // 
            this.numberClient.Location = new System.Drawing.Point(108, 21);
            this.numberClient.MaxLength = 16;
            this.numberClient.Name = "numberClient";
            this.numberClient.Size = new System.Drawing.Size(144, 20);
            this.numberClient.TabIndex = 3;
            this.numberClient.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numberClient_KeyPress);
            // 
            // PinBox
            // 
            this.PinBox.Location = new System.Drawing.Point(108, 85);
            this.PinBox.Name = "PinBox";
            this.PinBox.ReadOnly = true;
            this.PinBox.Size = new System.Drawing.Size(144, 20);
            this.PinBox.TabIndex = 4;
            // 
            // CodeLabel
            // 
            this.CodeLabel.AutoSize = true;
            this.CodeLabel.Location = new System.Drawing.Point(74, 88);
            this.CodeLabel.Name = "CodeLabel";
            this.CodeLabel.Size = new System.Drawing.Size(28, 13);
            this.CodeLabel.TabIndex = 5;
            this.CodeLabel.Text = "PIN:";
            // 
            // GenButton
            // 
            this.GenButton.Location = new System.Drawing.Point(108, 115);
            this.GenButton.Name = "GenButton";
            this.GenButton.Size = new System.Drawing.Size(110, 23);
            this.GenButton.TabIndex = 7;
            this.GenButton.Text = "Генерация";
            this.GenButton.UseVisualStyleBackColor = true;
            this.GenButton.Click += new System.EventHandler(this.GenButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(264, 146);
            this.Controls.Add(this.GenButton);
            this.Controls.Add(this.CodeLabel);
            this.Controls.Add(this.PinBox);
            this.Controls.Add(this.numberClient);
            this.Controls.Add(this.NumberLabel);
            this.Controls.Add(this.lengthPin);
            this.Controls.Add(this.comboBoxLen);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "PinGenerator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxLen;
        private System.Windows.Forms.Label lengthPin;
        private System.Windows.Forms.Label NumberLabel;
        private System.Windows.Forms.TextBox numberClient;
        private System.Windows.Forms.TextBox PinBox;
        private System.Windows.Forms.Label CodeLabel;
        private System.Windows.Forms.Button GenButton;
    }
}

