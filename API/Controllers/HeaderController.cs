using Application.Dtos;
using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeaderController : ControllerBase
    {
        private readonly IHeaderService _headerService;

        public HeaderController(IHeaderService HeaderService)
        {
            _headerService = HeaderService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var Header = _headerService.GetAll();

            if (Header == null)
            {
                return NotFound();
            }

            return Ok(Header);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var Header = _headerService.GetById(id);

            if (Header == null)
            {
                return NotFound();
            }

            return Ok(Header);
        }

        [HttpPost]
        public IActionResult Post(HeaderDto entity)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            _headerService.Insert(entity);

            return StatusCode(201, entity);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, HeaderDto entity)
        {
            if (id < 0 || !ModelState.IsValid)
                return BadRequest();

            _headerService.Update(id, entity);

            return StatusCode(200, entity);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var data = _headerService.GetById(id);

            if (data == null)
                return BadRequest();

            _headerService.Delete(id);

            return StatusCode(200, new { message = "Se eliminó el elemento " + id });
        }
    }
}
