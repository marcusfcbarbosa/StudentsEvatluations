using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Studentes.Evaluation.Shared.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : IEntity
    {
        void Create(TEntity entity);
        bool Delete(TEntity entity);
        void Delete(Guid id);
        void Edit(TEntity entity);
        TEntity GetById(Guid id);
        IEnumerable<TEntity> Filter();
        IEnumerable<TEntity> Filter(Func<TEntity, bool> predicate);
        void SaveChanges();
        Task CreateAsync(TEntity entity);
        Task SaveChangesAsync();
    }
}
