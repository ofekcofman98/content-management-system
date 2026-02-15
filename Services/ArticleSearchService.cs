using Microsoft.IdentityModel.Tokens.Experimental;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace ContentManagementSystem.Services
{
  public class ArticleSearchService : IArticleSearchService
  {
    private readonly ILogger<ArticleSearchService> _logger;

    public ArticleSearchService(ILogger<ArticleSearchService> logger)
    {
      _logger = logger;
    }

    public IEnumerable<IPublishedContent> GetArticles(IPublishedContent homePage)
    {
      try
      {
        if (homePage == null) return Enumerable.Empty<IPublishedContent>();

        var children = homePage.Children() ?? Enumerable.Empty<IPublishedContent>(); 
        return children.Where(x => x.ContentType.Alias == "article");
      }
      catch (Exception ex)
      {
        _logger.LogError(ex, "Error fetching articles from home page with ID {HomePageId}", homePage.Id);
        return Enumerable.Empty<IPublishedContent>();
      }
    }

    public IEnumerable<IPublishedContent> Paginate(IEnumerable<IPublishedContent> articles, int page, int pageSize)
    {
      return articles
          .Skip((page - 1) * pageSize)
          .Take(pageSize);
    }

    public IEnumerable<IPublishedContent> Search(IEnumerable<IPublishedContent> articles, string query)
    {
      if (string.IsNullOrEmpty(query))
        return articles;

      return articles.Where(a =>
          (a.Value<string>("title") ?? "").Contains(query, StringComparison.OrdinalIgnoreCase));
    }
  }
}
