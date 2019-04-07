namespace ListeningPostApiServer.Models
{
    public enum TaskType
    {
        Command,
        Deploy,
        Retrieve
    }

    public class TaskBase : EntityBase
    {
        public string Command { get; set; }

        public virtual Implant Implant { get; set; }
        public bool IsPickedUp { get; set; }
        public bool IsReturned { get; set; }

        public virtual Result Result { get; set; }
        public TaskType TaskType { get; set; }
    }
}