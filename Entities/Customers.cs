using Core.Abstract;

namespace Entities
{
    public class Customers : IEntity
    {
        public int Id { get; set; }
        public string NameSurname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public bool Status { get; set; }
        public IList<Orders> Orders { get; set; }
    }
}
