using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ListeningPostApiServer.Models
{
    public class ExfiltratedFile : FileBase
    {
        public virtual Implant FromImplant { get; set; }


        public ExfiltratedFile()
        {
            this.FileType = FileType.Exfiltrated;
        }
    }
}
