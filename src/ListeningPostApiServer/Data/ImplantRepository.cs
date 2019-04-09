using ListeningPostApiServer.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace ListeningPostApiServer.Data
{
    public class ImplantRepository : RepositoryBase<Implant>
    {
        public DbContext Context;
        public ImplantRepository(DbContext dbContext) : base(dbContext)
        {
            Context = dbContext;
        }

        public async Task<Implant> GetById(int id, CancellationToken cancellationToken = default)
        {
            var foundImplant = await _dbContext.Set<Implant>().FindAsync(id);
            return foundImplant;
        }
    }
}