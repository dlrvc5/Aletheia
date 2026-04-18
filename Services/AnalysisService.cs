using NewsAnalysisAPI.DTOs;
using NewsAnalysisAPI.Models;
using MongoDB.Driver;

namespace NewsAnalysisAPI.Services
{
    public class AnalysisService : IAnalysisService
    {
        private readonly IMongoCollection<News> _newsCollection;
        private readonly IAIService _aiService;

        public AnalysisService(IConfiguration configuration, IAIService aiService)
        {
            var client = new MongoClient(configuration["MongoDB:ConnectionString"]);
            var database = client.GetDatabase(configuration["MongoDB:DatabaseName"]);

           
            _newsCollection = database.GetCollection<News>("News");

            _aiService = aiService;
        }

        
        public async Task<AnalysisResultDTO> AnalyzeNewsAsync(string newsId)
        {
            if (string.IsNullOrWhiteSpace(newsId))
                throw new ArgumentException("NewsId boş olamaz.");

           
            var news = await _newsCollection
                .Find(x => x.Id == newsId)
                .FirstOrDefaultAsync();

            if (news == null)
                throw new Exception("Haber bulunamadı.");

            
            var aiResult = await _aiService.AnalyzeNewsAsync(news.Content);

            
            return new AnalysisResultDTO
            {
                NewsId = news.Id,
                ConsistencyScore = aiResult.ConsistencyScore,
                MisinformationProbability = aiResult.MisinformationProbability,
                AnalysisSummary = aiResult.AnalysisSummary
            };
        }

        
        public async Task<IEnumerable<AnalysisResultDTO>> GetAllAnalysesAsync()
        {
            var newsList = await _newsCollection.Find(_ => true).ToListAsync();

            var results = new List<AnalysisResultDTO>();

            foreach (var news in newsList)
            {
                var aiResult = await _aiService.AnalyzeNewsAsync(news.Content);

                results.Add(new AnalysisResultDTO
                {
                    NewsId = news.Id,
                    ConsistencyScore = aiResult.ConsistencyScore,
                    MisinformationProbability = aiResult.MisinformationProbability,
                    AnalysisSummary = aiResult.AnalysisSummary
                });
            }

            return results;
        }
    }
}