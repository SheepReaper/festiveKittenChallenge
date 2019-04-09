using ListeningPostApiServer.Models;
using Microsoft.EntityFrameworkCore;

namespace ListeningPostApiServer.Data
{
    public class FileRepository : RepositoryBase<FileBase>
    {
        public DbContext Context;

        public FileRepository(DbContext dbContext) : base(dbContext)
        {
            Context = dbContext;
        }
    }
}