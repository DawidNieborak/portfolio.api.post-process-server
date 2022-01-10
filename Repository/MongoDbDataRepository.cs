using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using portfolio.api.core.Entities;

namespace portfolio.api.core.Repository
{
    public class MongoDbDataRepository : IDataRepository
    {
        private const string _databaseName = "portfolio";
        private const string _collectionName = "repositories";
        private readonly IMongoCollection<GitHubRepositoryItem> _repositoryCollection;
        private readonly FilterDefinitionBuilder<GitHubRepositoryItem> filterBuilder = Builders<GitHubRepositoryItem>.Filter;
        
        public MongoDbDataRepository(IMongoClient mongoClient)
        {
            IMongoDatabase database = mongoClient.GetDatabase(_databaseName);
            _repositoryCollection = database.GetCollection<GitHubRepositoryItem>(_collectionName);
        }

        public async Task DeleteItemsAsync()
        {
            await _repositoryCollection.DeleteManyAsync(new BsonDocument());
        }
        
        public async Task CreateItemAsync(GitHubRepositoryItem item)
        {
            await _repositoryCollection.InsertOneAsync(item);
        }

        public async Task CreateItemsAsync(List<GitHubRepositoryItem> items)
        {
            await _repositoryCollection.InsertManyAsync(items);
        }

        public Task<GitHubRepositoryItem> GetItemAsync(Guid id)
        {
            return null;
        }

        public async Task<IEnumerable<GitHubRepositoryItem>> GetItemsAsync()
        {
            return await _repositoryCollection.Find(new BsonDocument()).ToListAsync();
        }
        
        public async Task UpdateItemAsync(GitHubRepositoryItem item)
        {
            var filter = filterBuilder.Eq(existingItem => existingItem.Id, item.Id);
            await _repositoryCollection.ReplaceOneAsync(filter, item);
        }
    }
}