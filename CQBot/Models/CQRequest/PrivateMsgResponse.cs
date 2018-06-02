using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CQBot.Models.CQRequest
{
    public class PrivateMsgResponse
    {
        [JsonProperty(PropertyName = "reply")]
        public string Reply { get; set; }
        [JsonProperty(PropertyName = "auto_escape")]
        public bool AutoEscape { get; set; }
    }
}
