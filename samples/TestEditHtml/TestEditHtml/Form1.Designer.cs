namespace TestEditHtml
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            richTextBox1 = new RichTextBox();
            buttonLoad = new Button();
            buttonSave = new Button();
            buttonBold = new Button();
            buttonItalic = new Button();
            buttonUnderline = new Button();
            buttonCenter = new Button();
            buttonLeft = new Button();
            buttonAddBullet = new Button();
            SuspendLayout();
            // 
            // richTextBox1
            // 
            richTextBox1.AcceptsTab = true;
            richTextBox1.Location = new Point(12, 41);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(776, 397);
            richTextBox1.TabIndex = 0;
            richTextBox1.Text = "";
            // 
            // buttonLoad
            // 
            buttonLoad.Location = new Point(12, 12);
            buttonLoad.Name = "buttonLoad";
            buttonLoad.Size = new Size(75, 23);
            buttonLoad.TabIndex = 1;
            buttonLoad.Text = "Cargar";
            buttonLoad.UseVisualStyleBackColor = true;
            buttonLoad.Click += buttonLoad_Click;
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(912, 688);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(110, 23);
            buttonSave.TabIndex = 2;
            buttonSave.Text = "Guardar";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // buttonBold
            // 
            buttonBold.Location = new Point(145, 12);
            buttonBold.Name = "buttonBold";
            buttonBold.Size = new Size(75, 23);
            buttonBold.TabIndex = 3;
            buttonBold.Text = "Negritas";
            buttonBold.UseVisualStyleBackColor = true;
            buttonBold.Click += buttonBold_Click;
            // 
            // buttonItalic
            // 
            buttonItalic.Location = new Point(226, 12);
            buttonItalic.Name = "buttonItalic";
            buttonItalic.Size = new Size(75, 23);
            buttonItalic.TabIndex = 4;
            buttonItalic.Text = "Cursiva";
            buttonItalic.UseVisualStyleBackColor = true;
            buttonItalic.Click += buttonItalic_Click;
            // 
            // buttonUnderline
            // 
            buttonUnderline.Location = new Point(307, 12);
            buttonUnderline.Name = "buttonUnderline";
            buttonUnderline.Size = new Size(75, 23);
            buttonUnderline.TabIndex = 5;
            buttonUnderline.Text = "Subrayado";
            buttonUnderline.UseVisualStyleBackColor = true;
            buttonUnderline.Click += buttonUnderline_Click;
            // 
            // buttonCenter
            // 
            buttonCenter.Location = new Point(504, 12);
            buttonCenter.Name = "buttonCenter";
            buttonCenter.Size = new Size(75, 23);
            buttonCenter.TabIndex = 6;
            buttonCenter.Text = "Centrar";
            buttonCenter.UseVisualStyleBackColor = true;
            buttonCenter.Click += buttonCenter_Click;
            // 
            // buttonLeft
            // 
            buttonLeft.Location = new Point(423, 12);
            buttonLeft.Name = "buttonLeft";
            buttonLeft.Size = new Size(75, 23);
            buttonLeft.TabIndex = 7;
            buttonLeft.Text = "Izquierda";
            buttonLeft.UseVisualStyleBackColor = true;
            buttonLeft.Click += buttonLeft_Click;
            // 
            // buttonAddBullet
            // 
            buttonAddBullet.Location = new Point(666, 12);
            buttonAddBullet.Name = "buttonAddBullet";
            buttonAddBullet.Size = new Size(75, 23);
            buttonAddBullet.TabIndex = 8;
            buttonAddBullet.Text = "Lista";
            buttonAddBullet.UseVisualStyleBackColor = true;
            buttonAddBullet.Click += buttonAddBullet_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1034, 723);
            Controls.Add(buttonAddBullet);
            Controls.Add(buttonLeft);
            Controls.Add(buttonCenter);
            Controls.Add(buttonUnderline);
            Controls.Add(buttonItalic);
            Controls.Add(buttonBold);
            Controls.Add(buttonSave);
            Controls.Add(buttonLoad);
            Controls.Add(richTextBox1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
        }

        #endregion

        private RichTextBox richTextBox1;
        private Button buttonLoad;
        private Button buttonSave;
        private Button buttonBold;
        private Button buttonItalic;
        private Button buttonUnderline;
        private Button buttonCenter;
        private Button buttonLeft;
        private Button buttonAddBullet;
    }
}
