using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Net;
using System.Net.Cache;
using System.IO;

using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Net.Security;
using System.Security;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace Demo_Csharp2WebAPI
{
    public partial class Csharp2WebAPI : Form
    {
        public Csharp2WebAPI()
        {
            InitializeComponent();
            InitFingerList();
        }

        private void InitFingerList()
        {
            List<FgDataList> lis_DataList = new List<FgDataList>()
            {
                new FgDataList
                {
                    fg_Name = " 1  Right Thumb",
                    fg_Value = "1"
                },
                new FgDataList
                {
                    fg_Name = " 2  Right Index",
                    fg_Value = "2"
                },
                new FgDataList
                {
                    fg_Name = " 3  Right Middle",
                    fg_Value = "3"
                },
                new FgDataList
                {
                    fg_Name = " 4  Right Ring",
                    fg_Value = "4"
                },
                new FgDataList
                {
                    fg_Name = " 5  Right Little",
                    fg_Value = "5"
                },
                new FgDataList
                {
                    fg_Name = " 6  Left Thumb",
                    fg_Value = "6"
                },
                new FgDataList
                {
                    fg_Name = " 7  Left Index",
                    fg_Value = "7"
                },
                new FgDataList
                {
                    fg_Name = " 8  Left Middle",
                    fg_Value = "8"
                },
                new FgDataList
                {
                    fg_Name = " 9  Left Ring",
                    fg_Value = "9"
                },
                new FgDataList
                {
                    fg_Name = "10  Left Little",
                    fg_Value = "10"
                }
            };

            comboBox_finger.DataSource = lis_DataList;
            comboBox_finger.DisplayMember = "fg_Name";
            comboBox_finger.ValueMember = "fg_Value";
            comboBox_finger.SelectedIndex = 0;
        }
        private void button_enroll_Click(object sender, EventArgs e)
        {
            richTextBox_log.Clear();

            string webapi_str = WebAPI_get_enroll_minutiae();
            richTextBox_log.AppendText("Web API return :\r\n" + webapi_str +"\r\n");

            string str_to_srv = ReComposeJson_Enroll(webapi_str);
            richTextBox_log.AppendText("Send Server :\r\n" + str_to_srv + "\r\n");

            string results = Srv_Enroll(str_to_srv);
            richTextBox_log.AppendText("Server return :\r\n" + results + "\r\n");
        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            richTextBox_log.Clear();

            string webapi_str = WebAPI_get_delete_data();
            richTextBox_log.AppendText("Web API return :\r\n" + webapi_str + "\r\n");

   
            string str_to_srv = ReComposeJson_Delete(webapi_str);
            richTextBox_log.AppendText("Send Server :\r\n" + str_to_srv + "\r\n");

            string results = Srv_Delete(str_to_srv);
            richTextBox_log.AppendText("Server return :\r\n" + results + "\r\n");

        }

        private void button_verify_Click(object sender, EventArgs e)
        {
            richTextBox_log.Clear();

            string webapi_str = WebAPI_get_minutiae();
            richTextBox_log.AppendText("Web API return :\r\n" + webapi_str + "\r\n");

            string str_to_srv = ReComposeJson_Enroll(webapi_str);
            richTextBox_log.AppendText("Send Server :\r\n" + str_to_srv + "\r\n");

            string results = Srv_Verify(str_to_srv);
            richTextBox_log.AppendText("Server return :\r\n" + results + "\r\n");
        }

        private void button_identify_Click(object sender, EventArgs e)
        {
            richTextBox_log.Clear();

            string webapi_str = WebAPI_get_minutiae();
            richTextBox_log.AppendText("Web API return :\r\n" + webapi_str + "\r\n");

            string str_to_srv = ReComposeJson_Identify(webapi_str);
            richTextBox_log.AppendText("Send Server :\r\n" + str_to_srv + "\r\n");

            string results = Srv_Identify(str_to_srv);
            richTextBox_log.AppendText("Server return :\r\n" + results + "\r\n");
        }



        //this function is only for first time load fpservice.exe take more time, so we launch it at very beggining
        private void WebAPI_load_fp_srv()
        {
            bool https_en = checkBox_https.Enabled;
            string route = "/api/load_fp_srv";

            string json_out = PostJson2WebAPI(https_en, route, "");
        }

        private string WebAPI_get_minutiae()
        {
            bool https_en = checkBox_https.Enabled;
            string route = "/api/get_minutiae";

            string ret = PostJson2WebAPI(https_en, route, "");

            return ret;
        }

        //this function is specified session key for Startek format "2018-08-20-14-50-00           "
        private string WebAPI_set_session_key()
        {
            bool https_en = checkBox_https.Enabled;
            string route = "/api/set_session_key ";

            //modify key as you need
            string startek_sessionkey = StartekSessionKey();

            string json_str = "{sessionkey:\""+ startek_sessionkey  + "\"}";

            string ret = PostJson2WebAPI(https_en, route, json_str);

            return ret;
        }

        private string WebAPI_get_enroll_minutiae()
        {
            bool https_en = checkBox_https.Enabled;
            string route = "/api/get_enroll_minutiae";

            string ret = PostJson2WebAPI(https_en, route, "");

            return ret;
        }
        
        private string WebAPI_get_delete_data()
        {
            bool https_en = checkBox_https.Enabled;
            string id = richTextBox_id.Text;

            int fp_idx;
            int.TryParse(comboBox_finger.SelectedValue.ToString(), out fp_idx);

            string route = "/api/get_delete_data";

            string json_str = "{clientUserId:\"" + id + "\", fpIndex:" + fp_idx.ToString()+ "}";
            string ret = PostJson2WebAPI(https_en, route, json_str);

            return ret;
        }

        private string PostJson2WebAPI(bool https_en, string route ,string json_string)
        {
            string protocol = "";

            if (https_en)
            {
                protocol = "https://localhost:5888";

                //ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Ssl3|SecurityProtocolType.Tls12;

                //must support tls 1.2 for WebAPI use, thus .netframe work 4.6 or higher is necessary
                //also must ignore self signed certification for localhost can only get self signed CA.
                ServicePointManager.ServerCertificateValidationCallback = 
                delegate { return true; };
            }
            else
            {
                protocol = "http://localhost:5887";
            }

            //var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://localhost:5887/api/load_fp_srv");
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(protocol + route );
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";
            httpWebRequest.Accept = "application/json";
            httpWebRequest.CachePolicy = new RequestCachePolicy(RequestCacheLevel.NoCacheNoStore);
            httpWebRequest.UserAgent = "myapp";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = json_string;

                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                string result_ = result.ToString();
                return result;
            }
            
        }

        private string StartekSessionKey()
        {
            string str_utc = TimeZoneInfo.ConvertTimeToUtc(DateTime.Now).ToString("yyyy-MM-dd-hh-mm-ss");// use UTC time as session key
            string str_pad_blank = str_utc.PadRight( 32, ' ');

            char[] charValues = str_pad_blank.ToCharArray();
            string hexOutput = "";
            foreach (char _eachChar in charValues)
            {
                // Get the integral value of the character.
                int value = Convert.ToInt32(_eachChar);
                // Convert the decimal value to a hexadecimal value in string form.
                hexOutput += String.Format("{0:X}", value);
            }

            return hexOutput;
        }

        string ReComposeJson_Enroll(string json_in)
        {
            json_get_minutiae json_from_WebAPI;
            //de-serialize json string from web api.
            using (var ms = new MemoryStream(Encoding.Unicode.GetBytes(json_in)))
            {
                DataContractJsonSerializer deseralizer = new DataContractJsonSerializer(typeof(json_get_minutiae));
                json_from_WebAPI = (json_get_minutiae)deseralizer.ReadObject(ms);// //反序列化ReadObject
            }

            //put together as new serialize json string as server need
            json_srv_enroll json_to_srv = new json_srv_enroll();
            string ret_str;
            using (var ms = new MemoryStream())
            {
                DataContractJsonSerializer seralizer = new DataContractJsonSerializer(typeof(json_srv_enroll));

                //assign one json to another json 
                json_to_srv.encMinutiae = json_from_WebAPI.data.encMinutiae;
                json_to_srv.eSkey       = json_from_WebAPI.data.eSkey;
                json_to_srv.iv          = json_from_WebAPI.data.iv;
                json_to_srv.clientUserId = richTextBox_id.Text;

                int fp_idx;
                int.TryParse(comboBox_finger.SelectedValue.ToString(), out fp_idx);
                json_to_srv.fpIndex = fp_idx;

                int privilege;
                int.TryParse(richTextBox_privilege.Text, out privilege);
                json_to_srv.privilege = privilege;

                //write to stream
                seralizer.WriteObject(ms, json_to_srv);
                ms.Position = 0;
                StreamReader sr = new StreamReader(ms, Encoding.UTF8);
                ret_str = sr.ReadToEnd();
                sr.Close();
            }
            return ret_str;
        }

        string ReComposeJson_Identify(string json_in)
        {
            json_get_minutiae json_from_WebAPI;
            //de-serialize json string from web api.
            using (var ms = new MemoryStream(Encoding.Unicode.GetBytes(json_in)))
            {
                DataContractJsonSerializer deseralizer = new DataContractJsonSerializer(typeof(json_get_minutiae));
                json_from_WebAPI = (json_get_minutiae)deseralizer.ReadObject(ms);// //反序列化ReadObject
            }

            //put together as new serialize json string as server need
            json_srv_indetify json_to_srv = new json_srv_indetify();
            string ret_str;
            using (var ms = new MemoryStream())
            {
                DataContractJsonSerializer seralizer = new DataContractJsonSerializer(typeof(json_srv_indetify));

                //assign one json to another json 
                json_to_srv.encMinutiae = json_from_WebAPI.data.encMinutiae;
                json_to_srv.eSkey = json_from_WebAPI.data.eSkey;
                json_to_srv.iv = json_from_WebAPI.data.iv;

                //write to stream
                seralizer.WriteObject(ms, json_to_srv);
                ms.Position = 0;
                StreamReader sr = new StreamReader(ms, Encoding.UTF8);
                ret_str = sr.ReadToEnd();
                sr.Close();
            }
            return ret_str;
        }

        string ReComposeJson_Delete(string json_in)
        {
            json_get_delete_data json_from_WebAPI;
            //de-serialize json string from web api.
            using (var ms = new MemoryStream(Encoding.Unicode.GetBytes(json_in)))
            {
                DataContractJsonSerializer deseralizer = new DataContractJsonSerializer(typeof(json_get_delete_data));
                json_from_WebAPI = (json_get_delete_data)deseralizer.ReadObject(ms);// //反序列化ReadObject
            }

            //put together as new serialize json string as server need
            json_srv_delete json_to_srv = new json_srv_delete();
            string ret_str;
            using (var ms = new MemoryStream())
            {
                DataContractJsonSerializer seralizer = new DataContractJsonSerializer(typeof(json_srv_delete));

                //assign one json to another json 
                json_to_srv.clientUserId = json_from_WebAPI.data.clientUserId;
                json_to_srv.deleteData = json_from_WebAPI.data.deleteData;

                //write to stream
                seralizer.WriteObject(ms, json_to_srv);
                ms.Position = 0;
                StreamReader sr = new StreamReader(ms, Encoding.UTF8);
                ret_str = sr.ReadToEnd();
                sr.Close();
            }
            return ret_str;
        }

        public static string ReadComboBox(ComboBox cb)
        {
            string str = "";

            if (cb.InvokeRequired)
            {
                cb.Invoke((MethodInvoker)delegate
                {
                    try
                    {
                        str = cb.SelectedValue.ToString();

                    }
                    catch (Exception ex)
                    {
                        string log = ex.Message;
                        MessageBox.Show(log);
                    }

                });
                return str;
            }
            else
            {
                return cb.SelectedValue.ToString();
            }
        }

        private string Srv_Enroll(string json_string)
        {
            bool https_en = checkBox_https.Enabled;
            string ip = richTextBox_serverip.Text;
            string port = richTextBox_port.Text;
            string route = "/redirect/enroll";

            string ret_str = PostJson2RedirectServer(https_en, ip, port, route, json_string);

            return ret_str;
        }

        private string Srv_Verify(string json_string)
        {
            bool https_en = checkBox_https.Enabled;
            string ip = richTextBox_serverip.Text;
            string port = richTextBox_port.Text;
            string route = "/redirect/verify";

            string ret_str = PostJson2RedirectServer(https_en, ip, port, route, json_string);

            return ret_str;
        }

        private string Srv_Identify(string json_string)
        {
            bool https_en = checkBox_https.Enabled;
            string ip = richTextBox_serverip.Text;
            string port = richTextBox_port.Text;
            string route = "/redirect/identify";

            string ret_str = PostJson2RedirectServer(https_en, ip, port, route, json_string);

            return ret_str;
        }

        private string Srv_Delete(string json_string)
        {
            bool https_en = checkBox_https.Enabled;
            string ip = richTextBox_serverip.Text;
            string port = richTextBox_port.Text;
            string route = "/redirect/delete";

            string ret_str = PostJson2RedirectServer(https_en, ip, port, route, json_string);

            return ret_str;
        }

        private string PostJson2RedirectServer(bool https_en,string SrvIp, string port, string route, string json_string)
        {
            string protocol = "";

            if (https_en)
            {
                protocol = "https://" + SrvIp + ":" + port;

                ServicePointManager.ServerCertificateValidationCallback =
                delegate { return true; };
            }
            else
            {
                protocol = "http://" + SrvIp + ":" + port;
            }

            var httpWebRequest = (HttpWebRequest)WebRequest.Create(protocol + route);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";
            httpWebRequest.Accept = "application/json";
            httpWebRequest.CachePolicy = new RequestCachePolicy(RequestCacheLevel.NoCacheNoStore);
            httpWebRequest.UserAgent = "myapp";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = json_string;

                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();
            }

            string ret_str = "";
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                ret_str = result.ToString();
            }

            return ret_str;

        }

        public class FgDataList
        {
            public string fg_Name { get; set; }
            public string fg_Value { get; set; }
        }
    }

    [DataContract]
    public class json_data_get_minutiae
    {
        [DataMember(Name = "encMinutiae")]
        public string encMinutiae { get; set; }

        [DataMember(Name = "eSkey")]
        public string eSkey { get; set; }

        [DataMember(Name = "iv")]
        public string iv { get; set; }
    }

    [DataContract]
    public class json_get_minutiae
    {
        [DataMember(Name = "code")]
        public string code { get; set; }

        [DataMember(Name = "message")]
        public string message { get; set; }

        [DataMember(Name = "data")]
        public json_data_get_minutiae data { get; set; }

    }

    [DataContract]
    public class json_set_session_key
    {
        [DataMember(Name = "code")]
        public string code { get; set; }

        [DataMember(Name = "message")]
        public string message { get; set; }
    }

    [DataContract]
    public class json_data_get_delete_data
    {
        [DataMember(Name = "clientUserId")]
        public string clientUserId { get; set; }

        [DataMember(Name = "deleteData")]
        public string deleteData { get; set; }
    }

    [DataContract]
    public class json_get_delete_data
    {
        [DataMember(Name = "code")]
        public string code { get; set; }

        [DataMember(Name = "message")]
        public string message { get; set; }

        [DataMember(Name = "data")]
        public json_data_get_delete_data data { get; set; }

    }

    [DataContract]
    public class json_srv_enroll
    {
        [DataMember(Name = "encMinutiae")]
        public string encMinutiae { get; set; }

        [DataMember(Name = "eSkey")]
        public string eSkey { get; set; }

        [DataMember(Name = "iv")]
        public string iv { get; set; }

        [DataMember(Name = "clientUserId")]
        public string clientUserId { get; set; }

        [DataMember(Name = "fpIndex")]
        public int fpIndex { get; set; }

        [DataMember(Name = "privilege")]
        public int privilege { get; set; }
    }

    [DataContract]
    public class json_srv_indetify
    {
        [DataMember(Name = "encMinutiae")]
        public string encMinutiae { get; set; }

        [DataMember(Name = "eSkey")]
        public string eSkey { get; set; }

        [DataMember(Name = "iv")]
        public string iv { get; set; }
    }

    [DataContract]
    public class json_srv_delete
    {
        [DataMember(Name = "clientUserId")]
        public string clientUserId { get; set; }

        [DataMember(Name = "deleteData")]
        public string deleteData { get; set; }
    }

}
