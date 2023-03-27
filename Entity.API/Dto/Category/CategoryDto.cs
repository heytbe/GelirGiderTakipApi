using Microsoft.AspNetCore.Http;

namespace Entity.API.Dto.Category
{
    public class CategoryDto
    {
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public IFormFile? File { get; set; }
    }
}
