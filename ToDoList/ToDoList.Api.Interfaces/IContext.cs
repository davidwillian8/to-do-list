using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Entities.Base;

namespace ToDoList.Api.Interfaces
{
    public interface IContext
    {
        void SetupCollection<TEntity>() where TEntity : Entity;

        IOrderedQueryable<TEntity> GetQuery<TEntity>() where TEntity : Entity;

        Task<TEntity> Get<TEntity>(Guid id) where TEntity : Entity;

        Task<TEntity> Insert<TEntity>(TEntity entity) where TEntity : Entity;

        Task<TEntity> Update<TEntity>(TEntity entity) where TEntity : Entity;

        Task Delete<TEntity>(Guid id) where TEntity : Entity;
    }
}
