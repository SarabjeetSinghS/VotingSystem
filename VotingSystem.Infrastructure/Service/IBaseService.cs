using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VotingSystem.Infrastructure.Entity;

namespace VotingSystem.Infrastructure.Service
{
    public interface IBaseService<T> : IDisposable where T : BaseEntity
    {
        T Get(int id);
        IEnumerable<T> GetAll();
        PaginatedList<T> GetAll(int page, int pageSize);
        T Insert(T entity);
        T Update(T entity);
        T Delete(T entity);
        T[] Delete(T[] entity);
        T Remove(T entity);
        void SaveChanges();
        Task<T> GetAsync(int id);
        IAsyncEnumerable<T> GetAllAsync();
        Task<T> SaveAsync(T entity);
    }
}
