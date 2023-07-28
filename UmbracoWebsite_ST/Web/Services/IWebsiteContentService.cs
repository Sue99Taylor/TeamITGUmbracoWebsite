using TeamITG.Interview.Website.Web.ViewModels;

namespace TeamITG.Interview.Website.Web.Services
{
    public interface IWebsiteContentService
    {
        Task<PagedNewsList> GetNewsItems(int pageNumber);
    }
}