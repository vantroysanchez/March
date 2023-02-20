using Application.Dtos;
using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetailController : ControllerBase
    {
        private readonly IDetailService _detailService;

        public DetailController(IDetailService detailService)
        {
            _detailService = detailService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var detail = _detailService.GetAll();

            if (detail == null)
            {
                return NotFound();
            }

            return Ok(detail);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var detail = _detailService.GetById(id);

            if (detail == null)
            {
                return NotFound();
            }

            return Ok(detail);
        }

        [HttpPost]
        public IActionResult Post(DetailDto entity)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            _detailService.Insert(entity);

            return StatusCode(201, entity);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, DetailDto entity)
        {
            if (id < 0 || !ModelState.IsValid)
                return BadRequest();

            _detailService.Update(id, entity);                

            return StatusCode(200, entity);            
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var data = _detailService.GetById(id);

            if (data == null)
                return BadRequest();

            _detailService.Delete(id);

            return StatusCode(200, new { message = "Se eliminó el elemento " + id});
        }
    }
}
