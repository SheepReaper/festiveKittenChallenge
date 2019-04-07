using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ListeningPostApiServer.Models
{
    public class Implant : EntityBase
    {
        public Implant()
        {
        }

        public virtual IEnumerable<ExfiltratedFile> ExfiltratedFiles { get; set; } = new HashSet<ExfiltratedFile>();
        public virtual PayloadFile PayloadFile { get; set; }
        //public IEnumerable<Result> Results => Tasks.Select(t => t.Result);
        public virtual IEnumerable<TaskBase> Tasks { get; set; } = new HashSet<TaskBase>();

        public async Task<TaskBase> AssignNewTask(string command)
        {
            await Task.CompletedTask;

            var newTask = new TaskBase()
            {
                Command = command
            };

            this.Tasks.Append(newTask);

            return newTask;
        }
    }
}