using ListeningPostApiServer.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ListeningPostApiServer.Models
{
    public class EntityBase : IEntity
    {
        public Guid Guid { get; set; }

        [Key]
        public int Id { get; set; }

        public EntityBase()
        {
            Guid = Guid.NewGuid();
        }
    }
}
