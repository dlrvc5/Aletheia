using NewsAnalysisAPI.DTOs;

namespace NewsAnalysisAPI.Services
{
    public interface IAnalysisService
    {
        Task<AnalysisResultDTO> AnalyzeNewsAsync(string newsId);
        Task<IEnumerable<AnalysisResultDTO>> GetAllAnalysesAsync();
    }
}
