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