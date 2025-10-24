using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace testDigestAuth
{
    public class Serializer
    {
        public static T Deserialize<T>(string input) where T : class
        {
            XmlSerializer ser = new(typeof(T));

            using StringReader sr = new(input);
            return (T)ser.Deserialize(sr);
        }

        public static string Serialize<T>(T ObjectToSerialize)
        {
            XmlSerializer xmlSerializer = new(ObjectToSerialize.GetType());

            using (StringWriter textWriter = new())
            {
                xmlSerializer.Serialize(textWriter, ObjectToSerialize);
                return textWriter.ToString();
            }
        }
    }
}
