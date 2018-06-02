using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Net;
using System.IO;

namespace CQBot.Assist.Http
{
    /// <summary>
    /// 初步HttpApi设计
    /// 已通过测试
    /// 利用IO流对请求进行读写
    /// </summary>
    class _HttpApi
    {
        public string ApiUrl = @"http://localhost:5700/";
        public void SendPrivateMessage(string id,string message)
        {
            try
            {
                IDictionary<string, string> parameters = new Dictionary<string, string>();
                parameters.Add("user_id", HttpUtility.UrlEncode(id));
                parameters.Add("message", HttpUtility.UrlEncode(message)); //编码问题待解决
                parameters.Add("auto_escape", HttpUtility.UrlEncode("false"));
                StringBuilder buffer = new StringBuilder();
                int i = 0;
                if (parameters != null)
                {
                    foreach (var key in parameters.Keys)
                    {
                        buffer.AppendFormat(i > 0 ? "&{0}={1}" : "{0}={1}", key, parameters[key]);
                        i++;
                    }
                }
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(ApiUrl + "send_private_msg?" + buffer);
                byte[] data = Encoding.ASCII.GetBytes(buffer.ToString());
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = data.Length;
                Stream requestStream = request.GetRequestStream();
                requestStream.Write(data, 0, data.Length);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
