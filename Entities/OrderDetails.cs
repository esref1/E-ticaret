using Core.Abstract;

namespace Entities
{
    public class OrderDetails : IEntity
    {
        public int Id { get; set; }
        public int BasketId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Piece { get; set; } 
        public string MainImages { get; set; }
        public int ProductsId { get; set; }
        public int OrdersId { get; set; }
        public Orders Orders { get; set; }
    }
}
