using TeamITG.Interview.Models;
using TeamITG.Interview.Website.Web.ViewModels;
using Umbraco.Cms.Web.Common;

namespace TeamITG.Interview.Website.Web.Services
{
    public class WebsiteContentService : IWebsiteContentService
    {
        private readonly IUmbracoHelperAccessor _helper;

        public WebsiteContentService(IUmbracoHelperAccessor umbracoHelperAccessor)
        {
            _helper = umbracoHelperAccessor;
        }
        public async Task<PagedNewsList> GetNewsItems(int pageNumber)
        {
            int itemsPerPage = 5; //Hardcoded for now...
            UmbracoHelper umbHelper;
            IEnumerable<NewsPage> nodes = null;
            int resultingPageNumber = pageNumber;

            if (_helper.TryGetUmbracoHelper(out umbHelper))
            {

                var allNodes = umbHelper.ContentAtRoot()
                    .SelectMany(n => n.DescendantsOfType(NewsPage.ModelTypeAlias).Select(n => (NewsPage)n)
                    );

                nodes = GetPageFromNodes(pageNumber, itemsPerPage, allNodes);

                // Reset back to page 1
                if (nodes.Count() == 0)
                {
                    resultingPageNumber = 1;
                    nodes = GetPageFromNodes(resultingPageNumber, itemsPerPage, allNodes);
                }
            }

            var vm = new PagedNewsList()
            {
                News = nodes,
                PageNumber = resultingPageNumber
            };
            return vm;

            static IEnumerable<NewsPage> GetPageFromNodes(int pageNumber, int itemsPerPage, IEnumerable<NewsPage> allNodes)
            {
                return allNodes
                    .Skip((pageNumber - 1) * itemsPerPage)
                    .Take(itemsPerPage);
            }
        }
    }
}
