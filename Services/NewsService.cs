using NewsAnalysisAPI.DTOs;
using System.Collections.Generic;

namespace NewsAnalysisAPI.Services
{
    public class NewsService : INewsService
    {
        private readonly List<NewsDTO> _newsList = new();

        public IEnumerable<NewsDTO> GetAllNews()
        {
            return _newsList;
        }

        public NewsDTO? GetNewsById(int id)
        {
            return _newsList.Find(news => news.Id == id);
        }

        public NewsDTO CreateNews(NewsDTO newsDto)
        {
            newsDto.Id = _newsList.Count + 1;
            _newsList.Add(newsDto);
            return newsDto;
        }
    }
}
