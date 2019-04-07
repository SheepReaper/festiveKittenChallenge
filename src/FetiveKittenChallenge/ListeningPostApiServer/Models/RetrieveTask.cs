using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ListeningPostApiServer.Models
{
    public class RetrieveTask : TaskBase
    {
        public RetrieveTask()
        {
            this.TaskType = TaskType.Retrieve;
        }
    }
}
