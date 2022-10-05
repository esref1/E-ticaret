using DataAccess.Abstract;
using DataAccess.Repository;

namespace DataAccess.Concrete
{
    public class OrderAddressRepo : Repositories<OrderAddress>, IOrderAddressRepo
    {
        public OrderAddressRepo(DbContext context) : base(context)
        {

        }
    }
}