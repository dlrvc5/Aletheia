using Microsoft.AspNetCore.Mvc;
using NewsAnalysisAPI.Services;


namespace NewsAnalysisAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnalysisController : ControllerBase
    {
        private readonly IAnalysisService _analysisService;

        public AnalysisController(IAnalysisService analysisService)
        {
            _analysisService = analysisService;
        }


        
        [HttpPost("{newsId}")]
        public async Task<IActionResult> AnalyzeNews(string newsId)
        {
            var result = await _analysisService.AnalyzeNewsAsync(newsId);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAnalyses()
        {
            var results = await _analysisService.GetAllAnalysesAsync();
            return Ok(results);
        }
    }
}