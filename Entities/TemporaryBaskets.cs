using Core.Abstract;

namespace Entities
{
    //Temporary Basket => Geçici Sepet
    public class TemporaryBaskets : IEntity
    {
        public int Id { get; set; }
        public int BasketId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Piece { get; set; } // Adet
        public string MainImages { get; set; }
        public int ProductsId { get; set; }
    }
}
