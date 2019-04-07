using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ListeningPostApiServer.Models
{
    public class PayloadFile : FileBase
    {
        public int Version { get; set; }
        public PayloadFile()
        {
            this.FileType = FileType.Payload;
            this.Version = 1;
        }

        public virtual IEnumerable<Implant> AssignedImplants { get; set; } = new HashSet<Implant>();
        public virtual IEnumerable<DeployTask> AssignedToTasks { get; set; }=new HashSet<DeployTask>();
    }
}
