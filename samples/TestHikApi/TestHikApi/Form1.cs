using Hik.Api;

namespace TestHikApi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            HikApi.Initialize();
            var hikApi = HikApi.Login("192.168.100.201", 8000, "admin", "Okutic314090*#");
        }
    }
}
