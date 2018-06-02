﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CQBot.Models.CQResponse.Api
{
    public class SendGroupMsgResponse
    {
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }
        [JsonProperty(PropertyName = "retcode")]
        public int Retcode { get; set; }
        [JsonProperty(PropertyName = "data")]
        public _SendGroupMsgResponse Data { get; set; }
    }
    public class _SendGroupMsgResponse
    {
        [JsonProperty(PropertyName = "message_id")]
        public long MessageId { get; set; }
    }
}
