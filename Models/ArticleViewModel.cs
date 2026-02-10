using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.Strings;

namespace ContentManagementSystem.Models
{
  public class ArticleViewModel : ContentModel
  {
    public ArticleViewModel(IPublishedContent content) : base(content) { }

    public string Title => Content.Value<string>("title") ?? string.Empty;
    public string Author => Content.Value<string>("authorName") ?? string.Empty;
    public MediaWithCrops? HeroImage => Content.Value<MediaWithCrops>("heroImage");
    public IHtmlEncodedString? ArticleContent => Content.Value<IHtmlEncodedString>("content");
  }
}
