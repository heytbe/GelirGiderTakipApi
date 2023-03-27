using Entity.API.Dto.Images;
using Entity.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.API.Dto.Giderler
{
    public class GiderlerListDto
    {
        public string GiderName { get; set; }
        public decimal GiderMiktari { get; set; }
        public string NerdeHarcandi { get; set; }
        public string Description { get; set; } // Ne alındı
        public List<GiderCategoryListDto> Categories { get; set; }
        public List<ImagesDto> Images { get; set; }
    }
}
