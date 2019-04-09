using ListeningPostApiServer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ListeningPostApiServer.Data
{
    public class RepositoryBase<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {
        protected readonly DbContext _dbContext;

        public RepositoryBase(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<TEntity> CreateAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            await _dbContext.Set<TEntity>().AddAsync(entity, cancellationToken);
            return entity;
        }

        public async Task DeleteAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            await Task.CompletedTask;
            _dbContext.Set<TEntity>().Remove(entity);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            await Task.CompletedTask;
            var resultSet = _dbContext.Set<TEntity>().AsEnumerable();
            return resultSet;
        }

        public async Task<IEnumerable<TEntity>> GetSomeAsync(Func<TEntity, bool> predicate,
            CancellationToken cancellationToken = default)
        {
            await Task.CompletedTask;
            var resultSet = _dbContext.Set<TEntity>().Where(predicate);
            return resultSet;
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        //public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        //{
        //    var existing = await _dbContext.Set<TEntity>().FindAsync(id);
        //    _dbContext.Set<TEntity>().Remove(existing);
        //}

        public async Task<TEntity> EditAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            var editedEntity = await _dbContext.Set<TEntity>().FindAsync(entity, cancellationToken);
            editedEntity = entity;
            await _dbContext.SaveChangesAsync(cancellationToken);
            return entity;
        }

        public async Task<TEntity> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var found = await _dbContext.Set<TEntity>().FindAsync(id, cancellationToken);
            return found;
        }

        public async Task<TEntity> GetByGuidAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _dbContext.Set<TEntity>().FirstOrDefaultAsync(e => e.Guid == id, cancellationToken);
        }
    }
}