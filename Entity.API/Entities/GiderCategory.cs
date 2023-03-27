using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.API.Entities
{
    public class GiderCategory
    {
        public int GiderlerId { get; set; }
        public int CategoryId { get; set; }
        public Giderler Giderler { get; set; }
        public Category Category { get; set; }
    }
}
