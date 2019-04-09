using System;
using Newtonsoft.Json;

namespace ListeningPostApiServer.Models
{
    public abstract class FileBase : EntityBase
    {
        public string TempFilePath { get; set; }

        public FileType FileType { get; set; }

        public DateTime Updated { get; set; }

        [JsonProperty("filename")]
        public string ActualFileName { get; set; }

        public FileBase()
        {
            Updated = DateTime.UtcNow;
        }
    }

    public enum FileType
    {
        Exfiltrated,
        Payload,
    }
}