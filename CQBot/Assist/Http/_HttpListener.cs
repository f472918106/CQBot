using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using CQBot.Assist.Logger;

namespace CQBot.Assist.Http
{
    /// <summary>
    /// HttpListener类
    /// </summary>
    public class _HttpListener
    {
        public string ApiUrl = @"http://localhost:30000/";
        public HttpListener listener = null;
        public HttpListenerContext context = null;
        public HttpListenerRequest request = null;
        public HttpListenerResponse response = null;
        public _HttpListener()
        {
            listener = new HttpListener();
            listener.Prefixes.Add(ApiUrl);
            if (!listener.IsListening)
            {
                listener.Start();
            }
            _Logger.PrimaryLine("HttpListener监听中...");
        }

        /// <summary>
        /// 接受请求
        /// </summary>
        /// <param name="listener">当前监听器</param>
        /// <returns>接受请求的json字符串</returns>
        public string GetRequest(HttpListener listener)
        { 
            context = listener.GetContext();
            request = context.Request;
            Stream stream = request.InputStream;
            string json = string.Empty;
            StreamReader reader = new StreamReader(stream);
            json = reader.ReadToEnd();
            return json;
        }

        /// <summary>
        /// 关闭listener
        /// </summary>
        public void ShutDown()
        {
            if (listener.IsListening)
            {
                listener.Close();
            }
        }
    }
}
