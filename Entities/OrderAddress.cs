
using Core.Abstract;

namespace Entities
{
    public class OrderAddress : IEntity
    {
        public int Id { get; set; }
        public string NameSurname { get; set; }
        public string Phone { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public bool Status { get; set; }  // True ise Teslimat- False ise Fatura
        public int OrdersId { get; set; }
        public Orders Orders { get; set; }
        public string FullAddress { get; set; }
    }
}
