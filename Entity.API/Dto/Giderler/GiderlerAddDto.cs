using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.API.Dto.Giderler
{
    public class GiderlerAddDto
    {
        public string GiderName { get; set; }
        public decimal GiderMiktari { get; set; }
        public string NerdeHarcandi { get; set; }
        public string Description { get; set; } // Ne alındı
        public List<IFormFile> File { get; set; }
        public List<int> Categories { get; set; }
    }
}
