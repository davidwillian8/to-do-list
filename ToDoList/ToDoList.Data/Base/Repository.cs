using Microsoft.Azure.Cosmos.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoList.Api.Interfaces;
using ToDoList.Entities.Base;

namespace ToDoList.Data.Base
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        private readonly IContext _context;

        protected Repository(IContext context)
        {
            context.SetupCollection<TEntity>();

            _context = context;
        }

        public async Task Delete(Guid id)
        {
            await _context.Delete<TEntity>(id);
        }

        public async Task<TEntity> Get(Guid id)
        {
            return await _context.Get<TEntity>(id);
        }

        public async Task<List<TEntity>> GetAll()
        {
            return (await _context.GetQuery<TEntity>().ToFeedIterator().ReadNextAsync()).ToList();
        }

        public async Task<TEntity> Insert(TEntity entity)
        {
            return await _context.Insert(entity);
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            return await _context.Update(entity);
        }
    }
}