using NewsAnalysisAPI.DTOs;

namespace NewsAnalysisAPI.Services
{
    public interface INewsService
    {
        IEnumerable<NewsDTO> GetAllNews();
        NewsDTO GetNewsById(int id);
        NewsDTO CreateNews(NewsDTO newsDto);
    }
}
