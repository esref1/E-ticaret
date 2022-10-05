using Core.Abstract;

namespace Entities.DTO
{
    public class DtoProductsCrud : IDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string MainImage { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string Explanation { get; set; }
        public int CategoriesId { get; set; }
        public bool Status { get; set; }
        public string Images1 { get; set; }
        public string Images2 { get; set; }
        public string Images3 { get; set; }
        public string Images4 { get; set; }
    }
}
