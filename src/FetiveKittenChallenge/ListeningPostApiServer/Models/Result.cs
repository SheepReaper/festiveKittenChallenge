using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ListeningPostApiServer.Models
{
    public class Result : EntityBase
    {
        [JsonProperty("results")]
        public string Results { get; set; }
        [JsonProperty("error")]
        public string Error { get; set; }
        [JsonProperty("task_id")]
        public int TaskId { get; set; }

        public virtual Implant Implant { get; set; }
        public virtual TaskBase TaskBase { get; set; }
    }
}