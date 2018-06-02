﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CQBot.Models.CQResponse;

namespace CQBot.Models
{
    public class CommonMessage
    {
        public string Message { get; }

        public string FullCommand { get; set; }
        public string Command { get; set; }
        public string Parameter { get; set; }

        public MessageType MessageType { get;}
        public PermissionLevel PermissionLevel { get; set; }

        public string UserId { get; }
        public string DiscussId { get; }
        public string GroupId { get; }
        public long MessageId { get; }

        public PrivateMsg Private { get; }
        public DiscussMsg Discuss { get; }
        public GroupMsg Group { get; }

        public CommonMessage(PrivateMsg privateMsg,PermissionLevel level = PermissionLevel.Public)
        {
            Message = privateMsg.Message;
            UserId = privateMsg.UserId.ToString();
            MessageId = privateMsg.MessageId;

            MessageType = MessageType.Private;
            PermissionLevel = level;

            Private = privateMsg;
        }

        public CommonMessage(DiscussMsg discussMsg,PermissionLevel level = PermissionLevel.Public)
        {
            Message = discussMsg.Message;
            UserId = discussMsg.DiscussId.ToString();
            DiscussId = discussMsg.DiscussId.ToString();
            MessageId = discussMsg.MessageId;

            MessageType = MessageType.Discuss;
            PermissionLevel = level;

            Discuss = discussMsg;
        }

        public CommonMessage(GroupMsg groupMsg,PermissionLevel level = PermissionLevel.Public)
        {
            Message = groupMsg.Message;
            UserId = groupMsg.UserId.ToString();
            GroupId = groupMsg.GroupId.ToString();
            MessageId = groupMsg.MessageId;

            MessageType = MessageType.Group;
            PermissionLevel = level;

            Group = groupMsg;
        }
    }
}
