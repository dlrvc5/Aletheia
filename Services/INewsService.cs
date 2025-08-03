using NewsAnalysisAPI.DTOs;
using System.Collections.Generic;

namespace NewsAnalysisAPI.Services
{
    public interface INewsService
    {
        IEnumerable<NewsDTO> GetAllNews();
        NewsDTO GetNewsById(int id);
        
    }
}
