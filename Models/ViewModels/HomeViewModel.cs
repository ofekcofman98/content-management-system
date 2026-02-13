using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace ContentManagementSystem.Models.ViewModels
{
  public class HomeViewModel : BaseViewModel
  {
    /// <summary>
    /// ViewModel for the Home Page.
    /// Encapsulates site metadata and search results for a clean, type-safe view implementation.
    /// </summary>
    public HomeViewModel(IPublishedContent content) : base(content) { }

    public string SiteName => Content.Value<string>("siteName") ?? string.Empty;
    public string SiteDescription => Content.Value<string>("siteDescription") ?? string.Empty;
    public string? SearchQuery { get; set; }
    public IEnumerable<ArticleViewModel> SearchResults { get; set; } = Enumerable.Empty<ArticleViewModel>();

    public PaginationInfo Pagination { get; set; } = new();
  }
}
