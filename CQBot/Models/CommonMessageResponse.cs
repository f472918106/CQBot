using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CQBot.Models.CQRequest.Api;

namespace CQBot.Models
{
    class CommonMessageResponse
    {
        public bool EnableAt { get; }
        public string Message { get; }
        public MessageType MessageType { get; }

        public string UserId { get; }
        public string DiscussId { get; }
        public string GroupId { get; }

        public SendPrivateMsg Private { get; }
        public SendDiscussMsg Discuss { get; }
        public SendGroupMsg Group { get; }

        /// <summary>
        /// 指定一个特定的群时再使用
        /// </summary>
        /// <param name="message"></param>
        /// <param name="userId"></param>
        /// <param name="enableAt"></param>
        public CommonMessageResponse(string message,string userId=null,bool enableAt = false)
        {
            UserId = userId;
            Message = message;
            EnableAt = enableAt;
        }

        public CommonMessageResponse(string message,CommonMessage commonMessage,bool enableAt = false)
        {
            Message = message;
            UserId = commonMessage.UserId;
            MessageType = commonMessage.MessageType;
            EnableAt = enableAt;
            switch (commonMessage.MessageType)
            {
                case MessageType.Private:
                    Private = new SendPrivateMsg(commonMessage.Private.UserId.ToString(), commonMessage.Private.Message);
                    break;
                case MessageType.Discuss:
                    Discuss = new SendDiscussMsg(commonMessage.Discuss.UserId.ToString(), commonMessage.Discuss.Message);
                    break;
                case MessageType.Group:
                    Group = new SendGroupMsg(commonMessage.Group.UserId.ToString(), commonMessage.Group.Message);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
