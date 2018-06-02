using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CQBot.Models.CQResponse.Api
{
    public class GroupListInfo
    {
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }
        [JsonProperty(PropertyName = "retcode")]
        public int Retcode { get; set; }
        [JsonProperty(PropertyName = "data")]
        public List<GroupInfo> Data { get; set; }

    }
    public class GroupInfo
    {
        [JsonProperty(PropertyName = "group_id")]
        public long GroupId { get; set; }
        [JsonProperty(PropertyName = "group_name")]
        public string GroupName { get; set; }
    }
}
