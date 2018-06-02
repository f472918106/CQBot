﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CQBot.Models.CQRequest.Api
{
    public class SendGroupMsg
    {
        [JsonProperty(PropertyName = "group_id")]
        public long GroupId { get; set; }
        [JsonProperty(PropertyName = "message")]
        public string Message { get; set; }
        [JsonProperty(PropertyName = "auto_escape")]
        public bool AutoEscape { get; set; }

        public SendGroupMsg(string groupId,string message,bool autoEscape = false)
        {
            GroupId = long.Parse(groupId);
            Message = message;
            AutoEscape = autoEscape;
        }
    }
}
