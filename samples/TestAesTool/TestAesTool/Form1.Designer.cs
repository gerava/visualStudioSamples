namespace TestAesTool
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxAesKey = new System.Windows.Forms.TextBox();
            this.textBoxAesIv = new System.Windows.Forms.TextBox();
            this.textBoxPlanText = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxEncrypted = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonEncrypt = new System.Windows.Forms.Button();
            this.buttonDecrypt = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "AES_IV:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "AES_KEY:";
            // 
            // textBoxAesKey
            // 
            this.textBoxAesKey.Location = new System.Drawing.Point(87, 43);
            this.textBoxAesKey.Name = "textBoxAesKey";
            this.textBoxAesKey.Size = new System.Drawing.Size(334, 20);
            this.textBoxAesKey.TabIndex = 2;
            this.textBoxAesKey.Text = "1F46AD5D8E1493BCF8BA11DDA75D8941";
            // 
            // textBoxAesIv
            // 
            this.textBoxAesIv.Location = new System.Drawing.Point(87, 74);
            this.textBoxAesIv.Name = "textBoxAesIv";
            this.textBoxAesIv.Size = new System.Drawing.Size(334, 20);
            this.textBoxAesIv.TabIndex = 3;
            this.textBoxAesIv.Text = "D3277F1DB331D0DBF0A587FD1CF37502";
            // 
            // textBoxPlanText
            // 
            this.textBoxPlanText.Location = new System.Drawing.Point(87, 147);
            this.textBoxPlanText.Name = "textBoxPlanText";
            this.textBoxPlanText.Size = new System.Drawing.Size(334, 20);
            this.textBoxPlanText.TabIndex = 5;
            this.textBoxPlanText.Text = "LasCrucesAmaril|1691576156||";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(40, 150);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "PLAIN:";
            // 
            // textBoxEncrypted
            // 
            this.textBoxEncrypted.Location = new System.Drawing.Point(87, 184);
            this.textBoxEncrypted.Name = "textBoxEncrypted";
            this.textBoxEncrypted.Size = new System.Drawing.Size(334, 20);
            this.textBoxEncrypted.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 187);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "ENCRYTED:";
            // 
            // buttonEncrypt
            // 
            this.buttonEncrypt.Location = new System.Drawing.Point(87, 100);
            this.buttonEncrypt.Name = "buttonEncrypt";
            this.buttonEncrypt.Size = new System.Drawing.Size(157, 41);
            this.buttonEncrypt.TabIndex = 8;
            this.buttonEncrypt.Text = "Encrypt";
            this.buttonEncrypt.UseVisualStyleBackColor = true;
            this.buttonEncrypt.Click += new System.EventHandler(this.buttonEncrypt_Click);
            // 
            // buttonDecrypt
            // 
            this.buttonDecrypt.Location = new System.Drawing.Point(264, 100);
            this.buttonDecrypt.Name = "buttonDecrypt";
            this.buttonDecrypt.Size = new System.Drawing.Size(157, 41);
            this.buttonDecrypt.TabIndex = 9;
            this.buttonDecrypt.Text = "Decrypt";
            this.buttonDecrypt.UseVisualStyleBackColor = true;
            this.buttonDecrypt.Click += new System.EventHandler(this.buttonDecrypt_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(453, 250);
            this.Controls.Add(this.buttonDecrypt);
            this.Controls.Add(this.buttonEncrypt);
            this.Controls.Add(this.textBoxEncrypted);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxPlanText);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxAesIv);
            this.Controls.Add(this.textBoxAesKey);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(469, 289);
            this.MinimumSize = new System.Drawing.Size(469, 289);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Test AES tool";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxAesKey;
        private System.Windows.Forms.TextBox textBoxAesIv;
        private System.Windows.Forms.TextBox textBoxPlanText;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxEncrypted;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonEncrypt;
        private System.Windows.Forms.Button buttonDecrypt;
    }
}

