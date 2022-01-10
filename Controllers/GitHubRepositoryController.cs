using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using portfolio.api.core.Entities;
using portfolio.api.core.Repository;

namespace portfolio.api.core.Controllers
{
    [ApiController]
    [Route("repositories")]
    [EnableCors("_myAllowSpecificOrigins")]
    public class GitHubRepositoryController : ControllerBase
    {
        private readonly IDataRepository repository;

        public GitHubRepositoryController(IDataRepository repository)
        {
            this.repository = repository;
        }
        
        // GET /repositories
        [HttpGet]
        public async Task<IEnumerable<GitHubRepositoryItem>> GetItemsAsync(string name = null)
        {
            var items = (await repository.GetItemsAsync());
            return items;
        }
        
    }
}