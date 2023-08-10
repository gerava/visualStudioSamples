using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestAesTool
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonEncrypt_Click(object sender, EventArgs e)
        {
            string ecrypted_data = AesOperation.EncryptString(textBoxAesKey.Text, textBoxAesIv.Text, textBoxPlanText.Text);
            textBoxEncrypted.Text = ecrypted_data;
        }

        private void buttonDecrypt_Click(object sender, EventArgs e)
        {
            string plain_data = AesOperation.DecryptString(textBoxAesKey.Text, textBoxAesIv.Text, textBoxEncrypted.Text);
            textBoxPlanText.Text = plain_data;
        }
    }
}
