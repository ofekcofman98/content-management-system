using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.Strings;

namespace ContentManagementSystem.Models.ViewModels
{
  public class ArticleViewModel : BaseViewModel
  {
    /// <summary>
    /// ViewModel representing an Article page. 
    /// Provides strongly-typed properties to avoid using "magic strings" in Razor views.
    /// </summary>
    public ArticleViewModel(IPublishedContent content) : base(content) { }

    public string Title => Content.Value<string>("title") ?? string.Empty;
    public string Author => Content.Value<string>("authorName") ?? string.Empty;
    public MediaWithCrops? HeroImage => Content.Value<MediaWithCrops>("heroImage");
    public IHtmlEncodedString? ArticleContent => Content.Value<IHtmlEncodedString>("content");
    public string Url => Content.Url() ?? string.Empty;
  }
}
