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