using Core.API.Entities;

namespace Entity.API.Entities
{
    public class Category:EntityBase
    {
        public Category()
        {
            Giderlers = new HashSet<GiderCategory>();
            Gelirlers = new HashSet<GelirCategory>();
            Borcs = new HashSet<BorcCategory>();
        }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public ICollection<GelirCategory> Gelirlers { get; set; }
        public int? ImagesId { get; set; }
        public Images? Images { get; set; }
        public ICollection<GiderCategory> Giderlers { get; set; }
        public ICollection<BorcCategory> Borcs { get; set; }
    }
}
