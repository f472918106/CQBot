using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CQBot.Assist.Http;
using CQBot.Assist.Logger;
using CQBot.Models.CQResponse;
using CQBot.Assist.Json;
using CQBot.Models;

namespace CQBot
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    _HttpListener handler = new _HttpListener();
                    HttpApi api = new HttpApi();
                    _Logger.PrimaryLine(handler.GetRequest(handler.listener));
                    handler.ShutDown();
                    /*
                    if(cm.MessageType==MessageType.Private)
                    {
                        api.SendPrivateMessage(cm.UserId, "信息已接收");
                        handler.ShutDown();
                    }
                    else
                    {
                        api.SendGroupMessage(cm.GroupId, "信息已接收");
                        handler.ShutDown();
                    }
                    */
                    
                }
                catch(Exception e)
                {
                    throw e;
                }
            }
        }
    }
}
