using Core.Abstract;

namespace Entities
{
    public class Categories:IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
        // Her Bir Kategori'nin Birden Fazla Ürünü Vardır. (Bir'e Çok İlişki)
        public IList<Products> Products { get; set; }
    }
}
