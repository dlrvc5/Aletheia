using NewsAnalysisAPI.DTOs;

namespace NewsAnalysisAPI.Services
{
    public interface IAnalysisService
    {
        AnalysisResultDTO AnalyzeNews(AnalysisDTO analysisDto);
    }
}
