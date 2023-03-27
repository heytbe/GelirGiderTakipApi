using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.API.Entities
{
    public class GelirCategory
    {
        public int GelirlerId { get; set; }
        public int CategoryId { get; set; }
        public Gelirler Gelirler { get; set; }
        public Category Category { get; set; }
    }
}
