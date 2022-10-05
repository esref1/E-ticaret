using Core.Abstract;

namespace Entities
{
    public class Orders : IEntity
    {
        public int Id { get; set; }
        public string PaymentType { get; set; } // Ödeme Tipi
        public string OrderStatus { get; set; } // Sipariş Durumu
        public DateTime OrderDate { get; set; } // Sipariş Tarihi
        public string CargoNumber { get; set; }
        public decimal TotalPrice { get; set; }
        public int CustomersId { get; set; }
        public Customers Customers { get; set; }
        public IList<OrderDetails> OrderDetails { get; set; }
        public IList<OrderAddress> OrderAddress { get; set; }
    }
}
