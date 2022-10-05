using DataAccess.Abstract;
using DataAccess.Repository;

namespace DataAccess.Concrete
{
    public class OrderDetailsRepo : Repositories<OrderDetails>, IOrderDetailsRepo
    {
        public OrderDetailsRepo(DbContext context) : base(context)
        {

        }
    }
}