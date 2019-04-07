using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ListeningPostApiServer.Interfaces;
using ListeningPostApiServer.Models;
using Microsoft.EntityFrameworkCore;

namespace ListeningPostApiServer.Data
{
    public class ImplantRepository : RepositoryBase<Implant>
    {
        public ImplantRepository(DbContext dbContext) : base(dbContext) { }

        public async Task<Implant> GetById(int id, CancellationToken cancellationToken = default)
        {
            var foundImplant = await _dbContext.Set<Implant>().FindAsync(id);
            return foundImplant;
        }
    }
}
