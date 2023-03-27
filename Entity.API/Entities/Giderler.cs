using Core.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Entity.API.Entities
{
    public class Giderler:EntityBase
    {
        public Giderler()
        {
            Categories = new HashSet<GiderCategory>();
            Images = new HashSet<Images>();
        }
        public string GiderName { get; set; }
        public decimal GiderMiktari { get; set; }
        public string NerdeHarcandi { get; set; }
        public string Description { get; set; } // Ne alındı
        public ICollection<GiderCategory> Categories { get; set; }
        public ICollection<Images> Images { get; set; }
    }
}
