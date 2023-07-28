using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Core.Cache;
using Umbraco.Cms.Core.Logging;
using Umbraco.Cms.Core.Routing;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Infrastructure.Persistence;
using Umbraco.Cms.Web.Website.Controllers;
using TeamITG.Interview.Website.Web.Services;

namespace TeamITG.Interview.Website.Web.Controllers.Surface
{
    public class NewsController : SurfaceController
    {
        private readonly IWebsiteContentService _contentService;

        public NewsController(IUmbracoContextAccessor umbracoContextAccessor, IUmbracoDatabaseFactory databaseFactory, 
            ServiceContext services, AppCaches appCaches, IProfilingLogger profilingLogger, IPublishedUrlProvider publishedUrlProvider,
            IWebsiteContentService contentService) : base(umbracoContextAccessor, databaseFactory, services, appCaches, profilingLogger, publishedUrlProvider)
        {
            _contentService = contentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetNews(int pageNumber)
        {
            var model = await _contentService.GetNewsItems(pageNumber);
            var result =  PartialView("_NewsItems", model);

            return result;
        }
    }
}
