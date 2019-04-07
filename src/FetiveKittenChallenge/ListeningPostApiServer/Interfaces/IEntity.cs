using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ListeningPostApiServer.Interfaces
{
    public interface IEntity
    {
        Guid Guid { get; set; }
        int Id { get; set; }
    }
}
