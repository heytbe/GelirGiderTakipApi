using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.API.Dto.Gelirler
{
    public class GelirImageUpdateDto
    {
        public IFormFile Files { get; set; }
    }
}
