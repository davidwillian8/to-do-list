using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Api.Interfaces;
using ToDoList.Entities.Base;

namespace ToDoList.Data.Base
{
    public class ToDoListContext : IContext
    {
        private readonly string _partitionKey = "TST";
        private readonly CosmosClient _cosmosClient;
        private readonly Database _database;
        private readonly string _databaseName;
        private readonly string _connString;
        private Container _container;

        public ToDoListContext(IConfiguration configuration)
        {
            _databaseName = configuration["Database:Name"];
            _connString = configuration["Database:ConnString"];

            _cosmosClient = new CosmosClient(_connString);

            _cosmosClient.CreateDatabaseIfNotExistsAsync(_databaseName).Wait();
            _database = _cosmosClient.GetDatabase(_databaseName);
        }

        public void SetupCollection<TEntity>() where TEntity : Entity
        {
            _database.CreateContainerIfNotExistsAsync(typeof(TEntity).Name.ToLower(), "/partition").Wait();
            _container = _database.GetContainer(typeof(TEntity).Name.ToLower());
        }

        public async Task Delete<TEntity>(Guid id) where TEntity : Entity
        {
            await _container.DeleteItemAsync<TEntity>(id.ToString(), new PartitionKey(_partitionKey));
        }

        public async Task<TEntity> Get<TEntity>(Guid id) where TEntity : Entity
        {
            try
            {
                return await _container.ReadItemAsync<TEntity>(id.ToString(),
                new PartitionKey(_partitionKey));
            }
            catch (CosmosException ce)
            {
                if (ce.StatusCode == HttpStatusCode.NotFound)
                    return null;

                throw;
            }
        }

        public IOrderedQueryable<TEntity> GetQuery<TEntity>() where TEntity : Entity
        {
            return _container.GetItemLinqQueryable<TEntity>();
        }

        public async Task<TEntity> Insert<TEntity>(TEntity entity) where TEntity : Entity
        {
            return await _container.CreateItemAsync<TEntity>(entity,
                new PartitionKey(_partitionKey));
        }

        public async Task<TEntity> Update<TEntity>(TEntity entity) where TEntity : Entity
        {
            return await _container.UpsertItemAsync<TEntity>(entity,
                new PartitionKey(_partitionKey));
        }
    }
}
