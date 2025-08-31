using NewsAnalysisAPI.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewsAnalysisAPI.Services
{
    public interface INewsService
    {
        Task<IEnumerable<NewsDTO>> GetAllNewsAsync();
        Task<NewsDTO?> GetNewsByIdAsync(string id);
        Task CreateNewsAsync(NewsDTO news);
        Task UpdateNewsAsync(string id, NewsDTO news);
        Task DeleteNewsAsync(string id);
    }
}
