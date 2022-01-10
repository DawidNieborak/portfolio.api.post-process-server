using System.Net.Http;
using System.Threading.Tasks;

namespace portfolio.api.core.Repository
{
    public interface IGitHubRepository
    {
        public Task FetchData();
    }
}