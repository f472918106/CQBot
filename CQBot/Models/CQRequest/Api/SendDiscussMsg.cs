using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CQBot.Models.CQRequest.Api
{
    public class SendDiscussMsg
    {
        [JsonProperty(PropertyName = "discuss_id")]
        public long DiscussId { get; set; }
        [JsonProperty(PropertyName = "message")]
        public string Message { get; set; }
        [JsonProperty(PropertyName = "auto_escape")]
        public bool AutoEscape { get; set; }

        public SendDiscussMsg(string discussId,string message,bool autoEscape = false)
        {
            DiscussId = long.Parse(discussId);
            Message = message;
            AutoEscape = autoEscape;
        }
    }
}
