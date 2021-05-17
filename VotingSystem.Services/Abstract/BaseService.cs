using System.Collections.Generic;
using System.Threading.Tasks;
using VotingSystem.Infrastructure.Entity;
using VotingSystem.Infrastructure.Repository;
using VotingSystem.Infrastructure.Service;

namespace VotingSystem.Service.Abstract
{
    public abstract class BaseService<T, TEr> : IBaseService<T>
        where T : BaseEntity
        where TEr : IBaseRepository<T>
    {
        protected readonly TEr _repository;
        protected BaseService(TEr repository)
        {
            _repository = repository;
        }

        public virtual T Get(int id) => _repository.Get(id);
        public virtual IEnumerable<T> GetAll() => _repository.GetAll();
        public virtual PaginatedList<T> GetAll(int page, int pageSize) => _repository.GetAll(page, pageSize);
        public virtual T Insert(T entity) => _repository.Insert(entity);
        public virtual T Update(T entity) => _repository.Update(entity);
        public virtual T Delete(T entity) => _repository.Delete(entity);
        public virtual T[] Delete(T[] entity) => _repository.Delete(entity);
        public virtual T Remove(T entity) => _repository.Remove(entity);
        public virtual void SaveChanges() => _repository.SaveChanges();

        public virtual async Task<T> GetAsync(int id) => await _repository.GetAsync(id);
        public virtual IAsyncEnumerable<T> GetAllAsync() => _repository.GetAllAsync();
        public virtual async Task<T> SaveAsync(T entity) => await _repository.SaveAsync(entity);
        public void Dispose() { }
    }
}
