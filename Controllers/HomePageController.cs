using ContentManagementSystem.Models;
using ContentManagementSystem.Models.ViewModels;
using ContentManagementSystem.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.Extensions.Options;
using Umbraco.Cms.Core.Media.EmbedProviders;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common.Controllers;

namespace ContentManagementSystem.Controllers
{
  /// <summary>
  /// Controller for the Home Page. 
  /// Handles the "Route Hijacking" to provide a custom ViewModel and search logic.
  /// </summary>
  public class HomePageController : RenderController
  {
    private readonly IArticleSearchService _searchService;
    private readonly ArticleSettings _settings;

    public HomePageController(
            ILogger<HomePageController> logger,
            ICompositeViewEngine compositeViewEngine,
            IUmbracoContextAccessor umbracoContextAccessor,
            IArticleSearchService searchService,
            IOptions<ArticleSettings> settings) 
      : base(logger, compositeViewEngine, umbracoContextAccessor)
    {
      _searchService = searchService;
      _settings = settings.Value;
    } 

    public override IActionResult Index()
    {
      if (CurrentPage == null)
      {
        return NotFound();
      }

      var query = Request.Query["query"].ToString().Trim(); 
      int.TryParse(Request.Query["page"], out int page);

      var articles = _searchService.GetArticles(CurrentPage);
      articles = _searchService.Search(articles, query);

      int totalItems = articles.Count();
      var pagedArticles = _searchService.Paginate(articles, page, _settings.PageSize);

      var model = new HomeViewModel(CurrentPage!)
      {
        SearchQuery = query,
        SearchResults = pagedArticles.Select(x => new ArticleViewModel(x)),
        Pagination = new PaginationInfo
        {
          PageNumber = page,
          PageSize = _settings.PageSize,
          TotalItems = totalItems
        }
      };

      return CurrentTemplate(model);
    }
  }
}
