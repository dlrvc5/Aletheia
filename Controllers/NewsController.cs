using Microsoft.AspNetCore.Mvc;
using NewsAnalysisAPI.Models;
using NewsAnalysisAPI.DTOs;
using NewsAnalysisAPI.Services;
using System.Collections.Generic;

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
        public ActionResult<IEnumerable<NewsDTO>> GetAllNews()
        {
            IEnumerable<NewsDTO> news = _newsService.GetAllNews();
            return Ok(news);
        }

        // GET: api/news/{id}
        [HttpGet("{id}")]
        public ActionResult<NewsDTO> GetNewsById(int id)
        {
            var news = _newsService.GetNewsById(id);
            if (news == null)
            {
                return NotFound();
            }
            return Ok(news);
        }

        // POST: api/news
        [HttpPost]
        public ActionResult<NewsDTO> CreateNews(NewsDTO newsDto)
        {
            var createdNews = _newsService.CreateNews(newsDto);
            return CreatedAtAction(nameof(GetNewsById), new { id = createdNews.Id }, createdNews);
        }
    }
}
