using Microsoft.AspNetCore.Mvc;
using TeamITG.Interview.Website.Web.Services;

namespace TeamITG.Interview.Website.Web.ViewComponents
{
    public class PagedNewsListViewComponent : ViewComponent
    {
        private readonly IContentService _contentService;

        public PagedNewsListViewComponent(IContentService contentService)
        {
            _contentService = contentService;
        }
        public async Task<IViewComponentResult> InvokeAsync(int pageNumber=1)
        {
            var items = await _contentService.GetNewsItems(pageNumber);
            return View("PagedNewsList", items);
        }
    }
}
