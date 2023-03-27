using Entity.API.Dto.Images;
using Entity.API.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.API.Dto.Gelirler
{
    public class GelirlerListeDto
    {
        public string GelirAdi { get; set; }
        public decimal GelirMiktari { get; set; }
        public string GelirYolu { get; set; }
        public string? GelirKimden { get; set; }
        public List<ImagesDto> Images { get; set; }
        public List<GelirCategoryListDto> Categories { get; set; }
    }
}
