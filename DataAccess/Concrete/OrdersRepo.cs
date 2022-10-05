using DataAccess.Abstract;
using DataAccess.Repository;

namespace DataAccess.Concrete
{
    public class OrdersRepo : Repositories<Orders>, IOrdersRepo
    {
        public OrdersRepo(DbContext context) : base(context)
        {

        }
    }
}