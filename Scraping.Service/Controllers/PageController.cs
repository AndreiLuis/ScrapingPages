using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Scraping.Core.Services;
using Scraping.Domain.Entities;

namespace Scraping.Service.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PageController : ControllerBase
    {
        [HttpPost, Route("Consult")]
        public IActionResult Consult(dynamic page)
        {
            var wordService = new WordService<WordEntity>();
            try
            {
                string json = page.ToString();
                PageEntity pageEntity = JsonSerializer.Deserialize<PageEntity>(json);
                var images = new ImageService<ImageEntity>().Get(pageEntity.Link);
                var words = wordService.Get(pageEntity.Link);
                var totalWords = wordService.CalculateTotalWords(words);

                var dataReturn = new DataReturnEntity(images, words, totalWords);

                if (dataReturn == null || (dataReturn.Images.Count <= 0 && dataReturn.Words.Count <= 0))
                    return NotFound(dataReturn);

                return Ok(dataReturn);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
