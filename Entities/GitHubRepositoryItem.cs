using System.Reflection;
using Newtonsoft.Json;

namespace portfolio.api.core.Entities
{
    public class GitHubRepositoryItem
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("language")]
        public string Language { get; set; }
        [JsonProperty("created_at")]
        public string CreatedAt { get; set; }
        [JsonProperty("updated_at")]
        public string UpdatedAt { get; set; }
        [JsonProperty("watchers")] 
        public string Watchers { get; set; }
        [JsonProperty("forks")]
        public string Forks { get; set; }
        [JsonProperty("open_issues")] 
        public string OpenIssues { get; set; }
        [JsonProperty("stargazers_count")] 
        public string StarsCount { get; set; }
        [JsonProperty("html_url")]
        public string HtmlUrl { get; set; }
        [JsonProperty("content")]
        public string Content { get; set; }
        public override string ToString()
        {
            string str = "";
            PropertyInfo[] properties = typeof(GitHubRepositoryItem).GetProperties();
            foreach (PropertyInfo property in properties)
            {
                str += property.Name + " = " + property.GetValue(this, null) + '\n';
            }

            return str;
        }
    }
}