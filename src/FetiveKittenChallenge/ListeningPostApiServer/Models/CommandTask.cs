namespace ListeningPostApiServer.Models
{
    public class CommandTask : TaskBase
    {
        public CommandTask()
        {
            this.TaskType = TaskType.Command;
        }
    }
}