using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ListeningPostApiServer.Interfaces;
using ListeningPostApiServer.Models;
using Microsoft.EntityFrameworkCore;

namespace ListeningPostApiServer.Data
{
    public class ResultRepository : RepositoryBase<Result>
    {
        public TaskRepository TaskRepository;
        public DbContext Context;
        public ResultRepository(DbContext dbContext, IRepository<TaskBase> implantRepository) : base(dbContext)
        {
            TaskRepository = (TaskRepository)implantRepository;
            Context = dbContext;
        }

        //public async Task<Implant> GetImplantByNodeId(int id)
        //{
        //    return await TaskRepository
        //}
    }
}
