using Umbraco.Cms.Core.Models.PublishedContent;

namespace ContentManagementSystem.Services
{
  public interface IArticleSearchService
  {
    IEnumerable<IPublishedContent> GetArticles(IPublishedContent homePage);
    IEnumerable<IPublishedContent> Search(IEnumerable<IPublishedContent> articles, string query);
    IEnumerable<IPublishedContent> Paginate(IEnumerable<IPublishedContent> articles, int page, int pageSize);
  }
}
