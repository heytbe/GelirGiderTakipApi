using Entity.API.Dto.Images;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.API.Dto.Category
{
    public class CategoryListeOlusturDto
    {
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public ImagesDto Images { get; set; }
    }
}
