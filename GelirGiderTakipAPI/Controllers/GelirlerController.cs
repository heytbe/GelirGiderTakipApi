using Entity.API.Dto.Gelirler;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.API.Services.Abstract;

namespace GelirGiderTakipAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GelirlerController : ControllerBase
    {
        public readonly IGelirlerService _service;
        public readonly IWebHostEnvironment _environment;
        public GelirlerController(IGelirlerService service, IWebHostEnvironment environment)
        {
            _service = service;
            _environment = environment;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var gelir = await _service.GetAllAsync();
            return Ok(gelir);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm]GelirlerDto gelirlerDto)
        { 
            var file = _environment.WebRootPath;
            var gelirler = await _service.GelirCategoryImageAddAsync(gelirlerDto, file);
            return Ok(gelirler);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromForm]GelirlerUpdateDto gelirlerDto,int id)
        {
            var gelirler = await _service.UpdateGelirlerCategory(gelirlerDto, id);
            return Ok(gelirler);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var gelirdelete = await _service.DeleteGelir(id);
            return Ok(gelirdelete);
        }

        [HttpPut("{imageid},{gelirid}")]
        public async Task<IActionResult> ImageUpdate([FromForm]GelirImageUpdateDto gelirImageUpdateDto,int gelirid,int imageid) 
        {
            var fileDir = _environment.WebRootPath;
            var gelir = await _service.UpdateImageGelirlerImages(gelirImageUpdateDto, gelirid, imageid,fileDir);
            return Ok(gelir);
        }

    }
}
