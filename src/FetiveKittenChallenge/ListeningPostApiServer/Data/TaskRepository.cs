using ListeningPostApiServer.Models;
using Microsoft.EntityFrameworkCore;

namespace ListeningPostApiServer.Data
{
    public class TaskRepository : RepositoryBase<TaskBase>
    {
        public DbContext Context;

        public TaskRepository(DbContext dbContext) : base(dbContext)
        {
            Context = dbContext;
        }
    }
}