using Core.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.API.Entities
{
    public class Images:EntityBase
    {
        public string ImageName { get; set; }
        public string ImageFile { get; set; }
        public string ImageSize { get; set; }
        public int? GelirlerId { get; set; }
        public Gelirler? Gelirler { get; set; }
        public Category Category { get; set; }
        public int? GiderlerId { get; set; }
        public Giderler? Giderler { get; set; }
        public int? BorcId { get; set; }
        public Borclar? Borc { get; set; }
    }
}
