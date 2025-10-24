using Newtonsoft.Json;
using OkuControlCore.Devices.DevISAPI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace testDigestAuth.DevISAPI.Commands
{
    public class SystemCapabilities
    {
        string uri = "/ISAPI/System/capabilities";
        HIKISAPIConnParams ConnectionParams;
        HttpClient client;
        public SystemCapabilities(HIKISAPIConnParams connectionParams)
        {
            ConnectionParams = connectionParams;
            client = new()
            {
                Timeout = TimeSpan.FromSeconds(ConnectionParams.Timeout)
            };
            client.DefaultRequestHeaders.Add("User-Agent", "OkuControCore");
            client.DefaultRequestHeaders.Add("Host", ConnectionParams.Ip);
        }

        public DeviceCap? Get()
        {
            HttpMethod method = HttpMethod.Get;

            var response = client.Send(
                new HttpRequestMessage(method, new Uri($"http://{ConnectionParams.Ip}{uri}")),
                HttpCompletionOption.ResponseHeadersRead);

            if (response.IsSuccessStatusCode)
            {
                var content = response.Content.ReadAsStringAsync().Result;
                Debug.WriteLine("Response: " + content);
                return null;
            }

            Debug.WriteLine("------------------------------------------------------------------------");
            Debug.WriteLine($"Error: {response.StatusCode}");
            Debug.WriteLine("Headers:\n" + response.Headers.ToString());
            Debug.WriteLine("Content:\n" + response.Content.ReadAsStringAsync().Result);
            Debug.WriteLine("------------------------------------------------------------------------");

            // Get the WWW-Authenticate header
            var wwwAuthHeader = response.Headers.WwwAuthenticate.FirstOrDefault();
            if (wwwAuthHeader == null)
            {
                Debug.WriteLine("No WWW-Authenticate header found.");
                return null;
            }
            /*
            WWW-Authenticate:
                Digest qop="auth", realm="DS-595F1BA8", nonce="N2U2ZmNmMTU1ZTgxOGQ4ZDQxNjlmZDg2ZGQ2YTkxZGI=", stale="false", opaque="", domain="::"
                Scheme:
                    Digest
                Parameter:
                    qop="auth", realm="DS-595F1BA8", nonce="N2U2ZmNmMTU1ZTgxOGQ4ZDQxNjlmZDg2ZGQ2YTkxZGI=", stale="false", opaque="", domain="::"
            */
            Debug.WriteLine("Scheme: " + wwwAuthHeader.Scheme);
            Debug.WriteLine("Parameter: " + wwwAuthHeader.Parameter);

            if (wwwAuthHeader.Scheme != "Digest" || wwwAuthHeader.Parameter == null)
            {
                Debug.WriteLine("Unsupported authentication scheme: " + wwwAuthHeader.Scheme);
                return null;
            }
            List<string> pairs = [];
            foreach (string keyValue in wwwAuthHeader.Parameter.Split(", "))
            {
                string[] pair = keyValue.Split('=', 2);
                if (pair.Length < 2)
                {
                    continue;
                }
                pairs.Add($"{pair[0]}:{pair[1]}");
            }
            string jsonString = "{ " + string.Join(", ", pairs) + " }";
            DigestAuthenticate? authenticate = JsonConvert.DeserializeObject<DigestAuthenticate>(jsonString);

            if (authenticate == null)
            {
                Debug.WriteLine("Failed to deserialize DigestAuthenticate object.");
                return null;
            }
            Debug.WriteLine("qop: " + authenticate.qop); // auth
            Debug.WriteLine("realm: " + authenticate.realm); // DS-595F1BA8
            Debug.WriteLine("nonce: " + authenticate.nonce); // N2U2ZmNmMTU1ZTgxOGQ4ZDQxNjlmZDg2ZGQ2YTkxZGI=
            Debug.WriteLine("stale: " + authenticate.stale); // False
            /*
                A1: Data block about security, which contains user name, password, security domain, random number, and so on. 
                    If the digest calculation algorithm is MD5, A1=<user>:<realm>:<password>;
                    if the algorithm is MD5-sess, A1=MD5(<user>:<realm>:<password>):<nonce>:<cnonce>.
            */
            string A1 = $"{ConnectionParams.Username}:{authenticate.realm}:{ConnectionParams.Password}";
            byte[] ha1Bytes = MD5.HashData(Encoding.UTF8.GetBytes(A1));
            string ha1 = BitConverter.ToString(ha1Bytes).Replace("-", "").ToLowerInvariant(); // MD5 hash of A1
            /*
                A2: Data block about message, such as URL, repeated requests, message body, and so on, it helps to prevent repeated, 
                    and realize the resource/message tamper-proof. 
                    If the qop is not defined or it is "auth:", A2=<request-method>:<uri-directive-value>;
                    if the qop is "auth-int:", A2=<request-method>:<uri-directive-value>:MD5(<request-entity-body>).
            */
            string A2 = $"{method.Method}:{uri}";
            byte[] ha2Bytes = MD5.HashData(Encoding.UTF8.GetBytes(A2));
            string ha2 = BitConverter.ToString(ha2Bytes).Replace("-", "").ToLowerInvariant(); // MD5 hash of A2

            /*
                The nonce is the random number generated by service, the following generation formula is suggested: 
                    nonce = base64(time-stamp MD5(time-stamp ":" ETag ":" private-key)). 
                The time-stamp in the formula is the time stamp generated by service or the unique serial No.; 
                the ETag is the value of HTTP ETag header in the request message; 
                the priviate-key is the data that only known by service
            */
            string client_nonce = Convert.ToBase64String(MD5.HashData(Encoding.UTF8.GetBytes($"{DateTime.UtcNow.Ticks}")));
            string nonce_count = "00000001"; // This should be incremented for each request

            /*
                The message digest, which contains user name, password, specific nonce value, HTTP or RTSP
                operation methods, and request URL, is generated by the MD5 algorithm, see the calculation rules
                below.
                qop=Undefined
                    Digest=MD5(MD5(A1):<nonce>:MD5(A2))
                qop="auth:"
                    Digest=MD5(MD5(A1):<nonce>:<nc>:<cnonce>:<qop>:MD5(A2))
                qop="auth-int:"
                    Digest=MD5(MD5(A1):<nonce>:<nc>:<cnonce>:<qop>:MD5(A2))
             */
            byte[] respBytes = MD5.HashData(Encoding.UTF8.GetBytes(
                $"{ha1}:{authenticate.nonce}:{nonce_count}:{client_nonce}:{authenticate.qop}:{ha2}"
                ));
            string resp = BitConverter.ToString(respBytes).Replace("-", "").ToLowerInvariant(); // MD5 hash of the response

            string digest = $"Digest" +
                $" username=\"{ConnectionParams.Username}\"" + // "admin"
                $", realm=\"{authenticate.realm}\"" + // "DS-595F1BA8"
                $", nonce=\"{authenticate.nonce}\"" + // "N2U2ZmNmMTU1ZTgxOGQ4ZDQxNjlmZDg2ZGQ2YTkxZGI="
                $", uri=\"{uri}\"" + // "/ISAPI/System/capabilities"
                $", cnonce=\"{client_nonce}\"" + // "afd1849fada145b2921551a6dab46db3"
                $", algorithm=\"MD5\"" + // "MD5"
                $", nc=\"{nonce_count}\"" + // "00000001"
                $", qop=\"{authenticate.qop}\"" + // "auth"
                $", response=\"{resp}\""; // "Uag9D51vljFBX6vxT09hMA=="


            Debug.WriteLine("Calculated Authorization: " + digest);

            //client = new()
            //{
            //    Timeout = TimeSpan.FromSeconds(5)
            //};
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Add("User-Agent", "OkuControCore");
            client.DefaultRequestHeaders.Add("Host", ConnectionParams.Ip);
            client.DefaultRequestHeaders.Add("Authorization", digest);

            response = client.Send(
                new HttpRequestMessage(method, new Uri($"http://{ConnectionParams.Ip}{uri}")),
                HttpCompletionOption.ResponseHeadersRead);

            if (!response.IsSuccessStatusCode)
            {
                Debug.WriteLine("------------------------------------------------------------------------");
                Debug.WriteLine($"Error: {response.StatusCode}");
                Debug.WriteLine("Headers:\n" + response.Headers.ToString());
                Debug.WriteLine("Content:\n" + response.Content.ReadAsStringAsync().Result);
                Debug.WriteLine("------------------------------------------------------------------------");
                return null;
            }
            var content1 = response.Content.ReadAsStringAsync().Result;
            Debug.WriteLine("Authenticated Response: " + content1);
            
            DeviceCap DeviceCap = Serializer.Deserialize<DeviceCap>(content1);
            return DeviceCap;
        }
    }
}
