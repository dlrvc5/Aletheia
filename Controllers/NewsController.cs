using Microsoft.AspNetCore.Mvc;
using NewsAnalysisAPI.DTOs;
using NewsAnalysisAPI.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewsAnalysisAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly INewsService _newsService;

        public NewsController(INewsService newsService)
        {
            _newsService = newsService;
        }

        // GET: api/news
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NewsDTO>>> GetAllNews()
        {
            var news = await _newsService.GetAllNewsAsync();
            return Ok(news);
        }

        // GET: api/news/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<NewsDTO>> GetNewsById(string id)
        {
            var news = await _newsService.GetNewsByIdAsync(id);
            if (news == null)
                return NotFound();
            return Ok(news);
        }
    }
}