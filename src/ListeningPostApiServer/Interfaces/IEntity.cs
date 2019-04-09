using System;

namespace ListeningPostApiServer.Interfaces
{
    public interface IEntity
    {
        Guid Guid { get; set; }
        int Id { get; set; }
    }
}