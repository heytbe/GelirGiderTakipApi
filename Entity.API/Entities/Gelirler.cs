using Core.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Entity.API.Entities
{
    public class Gelirler:EntityBase
    {
        public Gelirler()
        {
            Images = new HashSet<Images>();
            Categories = new HashSet<GelirCategory>();
        }
        public string GelirAdi { get; set; }
        public decimal GelirMiktari { get; set; }
        public string GelirYolu { get; set; }
        public string? GelirKimden { get; set; }
        public ICollection<Images> Images { get; set; }
        public ICollection<GelirCategory> Categories { get; set; }
    }
}
