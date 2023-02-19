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
        public ActionResult<IEnumerable<DetailDto>> GetAll()
        {
            var detail = _detailService.GetAll().ToList();

            if (detail == null)
            {
                return NotFound();
            }

            return detail;
        }
    }
}
