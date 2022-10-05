using Core.Abstract;

namespace Entities
{
    public class Products : IEntity
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

        // Her Bir Ürünün Bir Kategorisi Olacaktır.(Tek'e Tek İlişki)
        public Categories Categories { get; set; }
    }
}
