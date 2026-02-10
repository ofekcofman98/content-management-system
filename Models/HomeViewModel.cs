using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.Strings;
using Umbraco.Extensions;

namespace ContentManagementSystem.Models
{
  public class HomeViewModel : ContentModel
  {
    /// <summary>
    /// ViewModel for the Home Page, extending the standard Umbraco ContentModel.
    /// Used to pass CMS data alongside calculated search results.
    /// </summary>
    public HomeViewModel(IPublishedContent content) : base(content) { }

    public string SiteName => Content.Value<string>("siteName") ?? string.Empty;
    public string SiteDescription => Content.Value<string>("siteDescription") ?? string.Empty;

    public string? SearchQuery { get; set; }
    public IEnumerable<IPublishedContent> SearchResults { get; set; } = Enumerable.Empty<IPublishedContent>();
  }
}
