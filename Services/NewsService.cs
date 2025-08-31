using MongoDB.Driver;
using NewsAnalysisAPI.Models;
using NewsAnalysisAPI.DTOs;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsAnalysisAPI.Services
{
    public class NewsService : INewsService
    {
        private readonly IMongoCollection<News> _newsCollection;

        public NewsService(IConfiguration configuration)
        {
            var client = new MongoClient(configuration["MongoDB:ConnectionString"]);
            var database = client.GetDatabase(configuration["MongoDB:DatabaseName"]);
            _newsCollection = database.GetCollection<News>("Leroy_Sane_den_Sacha_Boey_e_sürpriz_telefon");
        }

        public async Task<IEnumerable<NewsDTO>> GetAllNewsAsync()
        {
            var newsList = await _newsCollection.Find(_ => true).ToListAsync();

            return newsList.Select(n => new NewsDTO
            {
                Id = n.Id,
                Title = n.Title,
                Content = n.Content,
                Author = n.Author,
                Source = n.Source,
                ImageUrl = n.ImageUrl
            });
        }

        public async Task<NewsDTO?> GetNewsByIdAsync(string id)
        {
            var news = await _newsCollection.Find(n => n.Id == id).FirstOrDefaultAsync();

            if (news == null) return null;

            return new NewsDTO
            {
                Id = news.Id,
                Title = news.Title,
                Content = news.Content,
                Author = news.Author,
                Source = news.Source
            };
        }

        public async Task CreateNewsAsync(NewsDTO newsDto)
        {
            var news = new News
            {
                Title = newsDto.Title,
                Content = newsDto.Content,
                Author = newsDto.Author,
                Source = newsDto.Source
            };

            await _newsCollection.InsertOneAsync(news);
        }

        public async Task UpdateNewsAsync(string id, NewsDTO newsDto)
        {
            var news = new News
            {
                Id = id,
                Title = newsDto.Title,
                Content = newsDto.Content,
                Author = newsDto.Author,
                Source = newsDto.Source
            };

            await _newsCollection.ReplaceOneAsync(n => n.Id == id, news);
        }

        public async Task DeleteNewsAsync(string id)
        {
            await _newsCollection.DeleteOneAsync(n => n.Id == id);
        }
    }
}