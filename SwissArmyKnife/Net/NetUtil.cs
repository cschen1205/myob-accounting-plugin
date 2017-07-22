using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Web;
using System.Xml;


namespace SwissArmyKnife.Net
{
    public class NetUtil
    {
         private static object mLocker = new object();
        private static NetUtil mInstance =null;

        public static NetUtil Instance
        {
            get
            {
                if (mInstance == null)
                {
                    lock (mLocker)
                    {
                        mInstance = new NetUtil();
                    }
                }
                return mInstance;
            }
        }
		private string _baseUrl="";
		private CookieContainer _cookieContainer = new CookieContainer();
 
		private NetUtil()
        {
            _baseUrl = "";
        }

        public string BaseUrl
		{
            get{
                return _baseUrl;
            }
            set
            {
                _baseUrl = value;
            }
		}
 
		public string HttpStringGet(string relativeUrl)
		{
			HttpWebRequest req = (HttpWebRequest)WebRequest.Create(_baseUrl + relativeUrl);
			req.CookieContainer = _cookieContainer;
 
			return ReadBasicResponse(req.GetResponse());
		}
 
		public byte[] HttpBinaryGet(string relativeUrl)
		{
			HttpWebRequest req = (HttpWebRequest)WebRequest.Create(_baseUrl + relativeUrl);
			req.CookieContainer = _cookieContainer;
 
			byte[] result = null;
			byte[] buffer = new byte[4096];
 
			using (WebResponse resp = req.GetResponse())
			using (Stream responseStream = resp.GetResponseStream())
			using (MemoryStream memoryStream = new MemoryStream())
			{
				int count = 0;
				do
				{
					count = responseStream.Read(buffer, 0, buffer.Length);
					memoryStream.Write(buffer, 0, count);
 
				} while (count != 0);
 
				result = memoryStream.ToArray();
			}
 
			return result;
		}
 
		private string ReadBasicResponse(WebResponse response)
		{
			using (WebResponse resp = response)
			using (StreamReader sr = new StreamReader(resp.GetResponseStream()))
				return sr.ReadToEnd().Trim();
		}

        public static string UrlEncode(DateTime? dt)
        {
            if (dt == null) return "NA";
            return HttpUtility.UrlEncode(dt.Value.ToString());
        }

        public static string UrlEncode(double val)
        {
            return HttpUtility.UrlEncode(Convert.ToString(val));
        }

        public static string UrlEncode(int val)
        {
            return HttpUtility.UrlEncode(Convert.ToString(val));
        }

        public static string UrlEncode(int? val)
        {
            if (val == null) return "null";
            return UrlEncode(val.Value);
        }

        public static string UrlEncode(bool val)
        {
            return HttpUtility.UrlEncode(Convert.ToString(val));
        }

        public string HttpPost(string uri, Dictionary<string, string> parameters)
        {
            bool httppostbank_empty = true;
            StringBuilder sb = new StringBuilder();
            foreach (string key in parameters.Keys)
            {
                string value = HttpUtility.UrlEncode(parameters[key]);

                if (httppostbank_empty == false)
                {
                    sb.Append("&");
                }
                else
                {
                    httppostbank_empty = false;
                }
                sb.AppendFormat("{0}={1}", key, value);
            }
            return HttpPost(uri, sb.ToString());
        }

        public string HttpPost(string uri, string parameters)
        {
            // parameters: name1=value1&name2=value2	
            WebRequest webRequest = WebRequest.Create(uri);
            //string ProxyString = 
            //   System.Configuration.ConfigurationManager.AppSettings
            //   [GetConfigKey("proxy")];
            //webRequest.Proxy = new WebProxy (ProxyString, true);
            //Commenting out above required change to App.Config
            webRequest.ContentType = "application/x-www-form-urlencoded";
            webRequest.Method = "POST";
            byte[] bytes = Encoding.ASCII.GetBytes(parameters);
            Stream os = null;
            try
            { // send the Post
                webRequest.ContentLength = bytes.Length;   //Count bytes to send
                os = webRequest.GetRequestStream();
                os.Write(bytes, 0, bytes.Length);         //Send it
            }
            catch (WebException ex)
            {
                //MessageBox.Show(ex.Message, "HttpPost: Request error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (os != null)
                {
                    os.Close();
                }
            }

            try
            { // get the response
                WebResponse webResponse = webRequest.GetResponse();
                if (webResponse == null)
                { return null; }
                StreamReader sr = new StreamReader(webResponse.GetResponseStream());
                return sr.ReadToEnd().Trim();
            }
            catch (WebException ex)
            {
                //MessageBox.Show(ex.Message, "HttpPost: Response error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return null;
        } // end HttpPost 

        public bool QueryWeb()
        {
            string url = string.Format("http://www.viaidea.com/sms/smsys/nextsms.php?currtime={0}", DateTime.Now.ToString("yyyyMMdd HHmm"));

            string data = GetHttpData(url);
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(data);

            XmlElement root = doc.DocumentElement;
            if (root.Attributes["found"].Value == "true")
            {
                string alert_id = root.Attributes["alert_id"].Value;
                string body = "";
                string contact_id = "";
                string number = "";

                foreach (XmlElement level1 in root.ChildNodes)
                {
                    if (level1.Name == "message")
                    {
                        body = level1.Attributes["body"].Value;
                        //subject = level1.Attributes["subject"].Value;
                    }
                    else if (level1.Name == "contact")
                    {
                        number = level1.Attributes["phone"].Value;
                        contact_id = level1.Attributes["contact_id"].Value;

                    }
                }
                

                url = string.Format("http://www.viaidea.com/sms/smsys/closesms.php?alert_id={0}&contact_id={1}", alert_id, contact_id);
                data = GetHttpData(url);
                
            }
            

            return true;
        }

        public static string UrlEncode(string raw_text)
        {
            string text = raw_text.Replace("'", "");
            return HttpUtility.UrlEncode(text);
        }

        private string GetHttpData(string url)
        {
            // used to build entire input
            StringBuilder sb = new StringBuilder();

            // used on each read operation
            byte[] buf = new byte[8192];

            // prepare the web page we will be asking for
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

            // execute the request
            HttpWebResponse response = (HttpWebResponse)
                request.GetResponse();

            // we will read data via the response stream
            Stream resStream = response.GetResponseStream();

            string tempString = null;
            int count = 0;

            do
            {
                // fill the buffer with data
                count = resStream.Read(buf, 0, buf.Length);

                // make sure we read some data
                if (count != 0)
                {
                    // translate from bytes to ASCII text
                    tempString = Encoding.ASCII.GetString(buf, 0, count);

                    // continue building the string
                    sb.Append(tempString);
                }
            }
            while (count > 0); // any more data to read?

            return sb.ToString();
        }
    }
}
