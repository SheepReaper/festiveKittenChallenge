using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ListeningPostApiServer.Models
{
    public class DeployTask : TaskBase
    {
        public DeployTask()
        {
            this.TaskType = TaskType.Deploy;
        }
    }
}
