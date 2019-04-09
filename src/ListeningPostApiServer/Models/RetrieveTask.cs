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