using Newtonsoft.Json;
using System.Diagnostics;
using System.Reflection.Metadata;
using System.Text;
using System.Security.Cryptography;
using OkuControlCore.Devices.DevISAPI;
using testDigestAuth.DevISAPI.Commands;
using System.IO;

namespace testDigestAuth
{
    public partial class Form1 : Form
    {
        public HIKISAPIConnParams ConnectionParams { get; set; } = new()
        {
            Ip = "192.168.100.22",
            Username = "admin",
            Password = "z@y$R5k6MgK",
            Timeout = 5 // Default timeout in seconds
        };
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            /*Serializer ser = new Serializer();
            string path = string.Empty;
            string xmlInputData = string.Empty;
            string xmlOutputData = string.Empty;

            //EXAMPLE 1
            path = Directory.GetCurrentDirectory() + @"\DeviceCap.xml";
            xmlInputData = File.ReadAllText(path);

            Debug.WriteLine("Input XML Data: " + xmlInputData);

            DeviceCap DeviceCap = ser.Deserialize<DeviceCap>(xmlInputData);

            */
            SystemCapabilities systemCapabilities = new(ConnectionParams);
            DeviceCap DeviceCap = systemCapabilities.Get();
            Debug.WriteLine("Deserialized DeviceCap: " + DeviceCap.ToString());
            Debug.WriteLine("isSupportReboot: " + DeviceCap.isSupportReboot);
            Debug.WriteLine("isSupportFactoryReset: " + DeviceCap.isSupportFactoryReset);



        }
    }
}
