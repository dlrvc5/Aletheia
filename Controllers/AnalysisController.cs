using Microsoft.AspNetCore.Mvc;
using NewsAnalysisAPI.DTOs;
using NewsAnalysisAPI.Services;
using System.Threading.Tasks;

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

        // POST: api/analysis
        [HttpPost]
        public async Task<ActionResult<AnalysisResultDTO>> AnalyzeNews([FromBody] AnalysisDTO analysisDto)
        {
            if (analysisDto == null || string.IsNullOrWhiteSpace(analysisDto.Content))
            {
                return BadRequest("Haber analizi için geçerli bir içerik sağlamalısınız.");
            }

            var result = await _analysisService.AnalyzeNewsAsync(analysisDto);
            return Ok(result);
        }
        // GET: api/analysis
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AnalysisResultDTO>>> GetAllAnalyses()
        {
            var results = await _analysisService.GetAllAnalysesAsync();
            return Ok(results);
        }
    }
}