using TeamITG.Interview.Models;

namespace TeamITG.Interview.Website.Web.ViewModels
{
    public class PagedNewsList
    {
        public IEnumerable<NewsPage>? News { get; set; }

        public int PageNumber { get; set; }

    }
}
