using Core.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Entity.API.Entities
{
    public class Borclar:EntityBase
    {
        public Borclar()
        {
            Categories = new HashSet<BorcCategory>();
        }
        public string BorcAlanVeren { get; set; }
        public decimal BorcMiktari { get; set; }
        public bool BorcAlindi { get; set; } = false;
        public bool BorcVerildi { get; set; } = true;
        public string Description { get; set; }
        public ICollection<BorcCategory> Categories { get; set; }
        public ICollection<Images> Images { get; set; }
    }
}
