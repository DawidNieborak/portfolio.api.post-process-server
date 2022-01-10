using System;
using System.ComponentModel.DataAnnotations;

namespace portfolio.api.core
{
    public record GitHubRepositoryItemDto(Guid Id, string Name, string Readme);
    public record CreateGitHubRepositoryItemDto([Required] string Name, [Required] string Readme);
    public record UpdateGitHubRepositoryItemDto([Required] string Name, string Readme);
}