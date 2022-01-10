using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using portfolio.api.core.Entities;

namespace portfolio.api.core.Repository
{
    
    public class GitHubRepository : IGitHubRepository
    {
        #region Private Var
        
        private readonly IHttpClientFactory _clientFactory;
        private readonly IDataRepository _mongo;
        private List<GitHubRepositoryItem> _projects;
        

        #endregion

        #region Default Constructor 

        public GitHubRepository(IHttpClientFactory clientFactory, IDataRepository mongo)
        {
            _clientFactory = clientFactory;
            _mongo = mongo;
        }

        #endregion
        
        #region Root

        public async Task FetchData()
        {
            await this.GitHubDataBaseDelete();
            await this.GitHubPull();
            await this.GitHubPullReadmes();
            await this.GitHubDataBaseSave();
        }

        #endregion

        #region Private GitHub Pull Functions Root/Content-Readme
        
        // Save to projects varibles root of github response 
        private async Task GitHubPull()
        {
            var client = _clientFactory.CreateClient("github");
            var response = await client.GetAsync("users/DawidNieborak/repos");
            if (response.IsSuccessStatusCode)
            {
                _projects = await response.Content.ReadAsAsync<List<GitHubRepositoryItem>>();
            }
        }

        // Pull from github readmes and add it to the GitHubRepositoryItem Schema as Contenet.
        private async Task GitHubPullReadmes()
        {
            if (_projects != null)
            {
                var client = _clientFactory.CreateClient("github");
                var tempList = _projects;
                for(int i = 0; i < tempList.Count; i++)
                {
                    var responseReadme = await client.GetAsync($"repos/DawidNieborak/{tempList[i].Name}/contents/README.md");
                    
                    if (responseReadme.IsSuccessStatusCode)
                    {
                        var temp = await responseReadme.Content.ReadAsAsync<GitHubRepositoryItem>();
                        _projects[i].Content = temp.Content;
                    }
                }
            }
        }

        #endregion

        #region Private Database operations
        
        private async Task GitHubDataBaseDelete()
        {
            await _mongo.DeleteItemsAsync();
        }
        
        private async Task GitHubDataBaseSave()
        {
            await _mongo.CreateItemsAsync(_projects);
        }
        
        #endregion
        
    }
}