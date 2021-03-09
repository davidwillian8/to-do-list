using System;
using System.Threading.Tasks;
using ToDoList.Entities.Base;

namespace ToDoList.Api.Interfaces
{
    public interface IRepository<TEntity> where TEntity : Entity
    {
        Task<TEntity> Get(Guid id);

        Task<TEntity> Insert(TEntity entity);

        Task<TEntity> Update(TEntity entity);

        Task Delete(Guid id);
    }
}
