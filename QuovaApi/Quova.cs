using System;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace QuovaApi
{
    public class Quova
    {
        private string apikey_;
        private string secret_;
        public Quova(string apikey, string secret)
        {
            this.apikey_ = apikey;
            this.secret_ = secret;
        }

        public IpInfo LookUp(string ip)
        {
            string sig = MD5GenerateHash(apikey_ + secret_ + (Int32)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds);
            string url = string.Format("http://api.quova.com/v1/ipinfo/{0}?apikey={1}&sig={2}&format=xml", ip, apikey_, sig);
            try
            {
                HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;

                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                using (StreamReader responseReader = new StreamReader(response.GetResponseStream()))
                {
                    string xml_contents = responseReader.ReadToEnd();

                    IpInfo ipInfo = null;

                    XmlSerializer serializer = new XmlSerializer(typeof(IpInfo));
                    using (XmlReader xmlReader = XmlReader.Create(new StringReader(xml_contents)))
                    {
                        ipInfo = (IpInfo)serializer.Deserialize(xmlReader);
                    }

                    return ipInfo;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private string MD5GenerateHash(string strInput)
        {
            MD5 md5Hasher = MD5.Create();

            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(strInput));

            StringBuilder sBuilder = new StringBuilder();

            for (int nIndex = 0; nIndex < data.Length; ++nIndex)
            {
                sBuilder.Append(data[nIndex].ToString("x2"));
            }

            return sBuilder.ToString();
        }
    }
}
