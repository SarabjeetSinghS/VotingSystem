using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VotingSystem.Infrastructure.Entity;
using VotingSystem.Infrastructure.Repository;

namespace VotingSystem.Repository.Repositories.Abstract
{
    public abstract class BaseRepository<T> : IBaseRepository<T>
         where T : BaseEntity
    {
        protected readonly DbContext _context;
        private DbSet<T> entities;
        string errorMessage = string.Empty;
        protected BaseRepository(DbContext context)
        {
            this._context = context;
            entities = context.Set<T>();
        }
        public virtual T Get(int id) => entities.SingleOrDefault(s => s.Id == id);
        public virtual IEnumerable<T> GetAll() => entities.AsEnumerable();
        public virtual PaginatedList<T> GetAll(int page, int pageSize) => new PaginatedList<T>(entities.AsQueryable(), page, pageSize);
        public virtual T Insert(T entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            entities.Add(entity);
            _context.SaveChanges();
            return entity;
        }
        public virtual T Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _context.Update(entity);
            _context.SaveChanges();
            return entity;
        }
        public virtual T Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
            _context.SaveChanges();
            return entity;
        }

        public virtual T[] Delete(T[] entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.RemoveRange(entity);
            _context.SaveChanges();
            return entity;
        }
        public virtual T Remove(T entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            entities.Remove(entity);
            return entity;
        }
        public virtual void SaveChanges() => _context.SaveChanges();

        public virtual async Task<T> GetAsync(int id) => await entities.SingleOrDefaultAsync(s => s.Id == id);
        public virtual IAsyncEnumerable<T> GetAllAsync() => entities.AsAsyncEnumerable();
        public virtual async Task<T> SaveAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            if (entity.Id == 0)
                entities.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public IEnumerable<TSource> DistinctBy<TSource, TKey>
      (IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            HashSet<TKey> seenKeys = new HashSet<TKey>();
            foreach (TSource element in source)
            {
                if (seenKeys.Add(keySelector(element)))
                {
                    yield return element;
                }
            }
        }
        public void Dispose() { }
    }
}
