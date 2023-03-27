using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.API.Entities
{
    public class BorcCategory
    {
        public int BorcId { get; set; }
        public int CategoryId { get; set; }
        public Borclar Borc { get; set; }
        public Category Category { get; set; }
    }
}
