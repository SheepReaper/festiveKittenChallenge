using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ListeningPostApiServer.Models
{
    public abstract class FileBase : EntityBase
    {
        public string FilePath { get; set; }

        public FileType FileType { get; set; }

        public DateTime Updated { get; set; }

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
