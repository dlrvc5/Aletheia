using NewsAnalysisAPI.DTOs;
using System.Threading.Tasks;

namespace NewsAnalysisAPI.Services
{
    public interface IAnalysisService
    {
        Task<AnalysisResultDTO> AnalyzeNewsAsync(AnalysisDTO analysisDto);
        Task<IEnumerable<AnalysisResultDTO>> GetAllAnalysesAsync();
    }
}
