using NewsAnalysisAPI.DTOs;

namespace NewsAnalysisAPI.Services
{
    public interface IAIService
    {
        Task<AIResultDTO> AnalyzeNewsAsync(string content);
    }
}
