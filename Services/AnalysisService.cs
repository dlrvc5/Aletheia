using NewsAnalysisAPI.DTOs;
using NewsAnalysisAPI.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewsAnalysisAPI.Services
{
    public class AnalysisService : IAnalysisService
    {
        private readonly IMongoCollection<AnalysisResult> _collection;

        public AnalysisService(IConfiguration configuration)
        {
            var client = new MongoClient(configuration["MongoDB:ConnectionString"]);
            var database = client.GetDatabase(configuration["MongoDB:DatabaseName"]);
            _collection = database.GetCollection<AnalysisResult>("AnalysisResults");
        }

        public async Task<AnalysisResultDTO> AnalyzeNewsAsync(AnalysisDTO analysisDto)
        {
            if (analysisDto == null || string.IsNullOrWhiteSpace(analysisDto.Content))
                throw new ArgumentException("Geçersiz analiz verisi.");

            var resultDto = new AnalysisResultDTO
            {
                NewsId = analysisDto.NewsId,
                ConsistencyScore = 85.5,
                MisinformationProbability = 10.2,
                AnalysisSummary = "Bu haber büyük ölçüde tutarlıdır."
            };

            var result = new AnalysisResult
            {
                NewsId = resultDto.NewsId,
                ConsistencyScore = resultDto.ConsistencyScore,
                MisinformationProbability = resultDto.MisinformationProbability,
                AnalysisSummary = resultDto.AnalysisSummary
            };

            await _collection.InsertOneAsync(result);
            return resultDto;
        }

        //analizleri getirir
        public async Task<IEnumerable<AnalysisResultDTO>> GetAllAnalysesAsync()
        {
            var results = await _collection.Find(_ => true).ToListAsync();

            var dtoList = new List<AnalysisResultDTO>();
            foreach (var r in results)
            {
                dtoList.Add(new AnalysisResultDTO
                {
                    NewsId = r.NewsId,
                    ConsistencyScore = r.ConsistencyScore,
                    MisinformationProbability = r.MisinformationProbability,
                    AnalysisSummary = r.AnalysisSummary
                });
            }

            return dtoList;
        }
    }
}