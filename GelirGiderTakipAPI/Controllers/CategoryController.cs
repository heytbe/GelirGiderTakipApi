using Entity.API.Dto.Category;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.API.Services.Abstract;

namespace GelirGiderTakipAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        public readonly ICategoryService _service;
        public readonly IWebHostEnvironment _environment;
        public CategoryController(ICategoryService service, IWebHostEnvironment environment)
        {
            _service = service;
            _environment = environment;
        }

        [HttpGet]
        public async Task<IActionResult> Listele()
        {
            var categoryImage = await _service.GetAllAsync();
            return Ok(categoryImage);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm]CategoryDto categoryDto)
        {
            var fileDir = _environment.WebRootPath;
            var category = await _service.AddAsync(categoryDto, fileDir);
            return Ok(category);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var delete = await _service.DeleteAsync(id);
            return Ok(delete);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetList(int id)
        {
           var category =  await _service.GetByIdList(id);
            return Ok(category);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> CategoryUpdate([FromForm]CategoryDto categoryDto,int id)
        {
            if(categoryDto.File != null)
            {
                var fileDir = _environment.WebRootPath;
                var category = await _service.CategoryAndImageUpdate(categoryDto,id,fileDir);
                return Ok(category);
            }
            else
            {
                var category = await _service.CategoryAndImageUpdate(categoryDto, id);
                return Ok(category);
            }
        }
    }
}
