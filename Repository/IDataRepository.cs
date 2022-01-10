using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using portfolio.api.core.Entities;

namespace portfolio.api.core.Repository
{
    public interface IDataRepository
    {
        Task CreateItemAsync(GitHubRepositoryItem item);
        Task<GitHubRepositoryItem> GetItemAsync(Guid id);
        Task DeleteItemsAsync();
        Task<IEnumerable<GitHubRepositoryItem>> GetItemsAsync();
        Task UpdateItemAsync(GitHubRepositoryItem item);
        Task CreateItemsAsync(List<GitHubRepositoryItem> items);
    }
}