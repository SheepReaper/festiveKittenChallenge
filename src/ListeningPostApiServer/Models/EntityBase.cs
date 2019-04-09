using ListeningPostApiServer.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.ComponentModel.DataAnnotations;

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