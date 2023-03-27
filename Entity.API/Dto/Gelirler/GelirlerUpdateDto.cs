using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.API.Dto.Gelirler
{
    public class GelirlerUpdateDto
    {
        public string? GelirAdi { get; set; }
        public Decimal? GelirMiktari { get; set; }
        public string? GelirYolu { get; set; }
        public string? GelirKimden { get; set; }
        public List<int>? Categories { get; set; }
    }
}
