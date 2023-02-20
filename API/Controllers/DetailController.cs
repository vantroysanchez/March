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
        public ActionResult<DetailDto> Post(DetailDto entity)
        {
            _detailService.Insert(entity);

            return CreatedAtAction("Detail", entity);
        }
    }
}
