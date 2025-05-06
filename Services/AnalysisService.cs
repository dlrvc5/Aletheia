using NewsAnalysisAPI.DTOs;

namespace NewsAnalysisAPI.Services
{
    public class AnalysisService : IAnalysisService
    {
        public AnalysisResultDTO AnalyzeNews(AnalysisDTO analysisDto)
        {
            // Gelen DTO'nun geçerli olup olmadığını kontrol et
            if (analysisDto == null || string.IsNullOrWhiteSpace(analysisDto.Content))
            {
                throw new ArgumentException("Geçersiz analiz verisi.");
            }

            return new AnalysisResultDTO
            {
                NewsId = analysisDto.NewsId,
                ConsistencyScore = 85.5,  // Sahte veri
                MisinformationProbability = 10.2,  // Sahte veri
                AnalysisSummary = "Bu haber büyük ölçüde tutarlıdır."
            };
        }
    }
}
