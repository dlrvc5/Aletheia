using NewsAnalysisAPI.DTOs;
using NewsAnalysisAPI.Services;

public class AIService : IAIService
{
    public async Task<AIResultDTO> AnalyzeNewsAsync(string content)
    {
        return new AIResultDTO
        {
            ConsistencyScore = 0,
            MisinformationProbability = 0,
            AnalysisSummary = "AI servisi henüz bağlı değil"
        };
    }
}
