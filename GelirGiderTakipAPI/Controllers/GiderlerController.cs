using Entity.API.Dto.Giderler;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.API.Services.Abstract;

namespace GelirGiderTakipAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GiderlerController : ControllerBase
    {
        private readonly IGiderlerService _service;
        private readonly IWebHostEnvironment _environment;

        public GiderlerController(IGiderlerService service, IWebHostEnvironment environment)
        {
            _service = service;
            _environment = environment;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var giderler = await _service.GetAll();
            return Ok(giderler);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromForm]GiderlerAddDto giderlerAddDto)
        {
            var fileDir = _environment.WebRootPath;
            var giderEkle = await _service.AddGiderlerAsync(giderlerAddDto, fileDir);
            return Ok(giderEkle);
        }
    }
}
