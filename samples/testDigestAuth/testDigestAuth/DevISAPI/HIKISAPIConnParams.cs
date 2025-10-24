using Newtonsoft.Json;
using System;

namespace OkuControlCore.Devices.DevISAPI
{
    public class HIKISAPIConnParams
    {
        public string Ip { get; set; } = "";
        public string Username { get; set; } = "";
        public string Password { get; set; } = "";
        public int Timeout { get; set; } = 5;

        public void LoadFromJsonString(string json)
        {
            if (string.IsNullOrEmpty(json))
            {
                return;
            }
            try
            {
                var jsonObject = JsonConvert.DeserializeObject<HIKISAPIConnParams>(json);
                if (jsonObject != null)
                {
                    Ip = jsonObject.Ip;
                    Username = jsonObject.Username;
                    Password = jsonObject.Password;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading HIK_ISAPI connection parameters: {ex.Message}");
            }
        }

        public string ToJsonString()
        {
            try
            {
                return JsonConvert.SerializeObject(this);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error serializing HIK_ISAPI connection parameters: {ex.Message}");
                return "";
            }
        }
        public override string ToString()
        {
            return $"IP={Ip}, USERNAME={Username}, PASSWORD={new('*', Password.Length)}";
        }
    }
}
