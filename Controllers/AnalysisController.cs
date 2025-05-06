using Microsoft.AspNetCore.Mvc;
using NewsAnalysisAPI.DTOs;
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

        // POST: api/analysis
        [HttpPost]
        public ActionResult<AnalysisResultDTO> AnalyzeNews([FromBody] AnalysisDTO analysisDto)
        {
            if (analysisDto == null || string.IsNullOrWhiteSpace(analysisDto.Content))
            {
                return BadRequest("Haber analizi için geçerli bir içerik sağlamalısınız.");
            }

            var result = _analysisService.AnalyzeNews(analysisDto);
            return Ok(result);
        }
    }
}
