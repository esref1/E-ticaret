using DataAccess.Abstract;
using DataAccess.Repository;

namespace DataAccess.Concrete
{
    public class TemporaryBasketsRepo : Repositories<TemporaryBaskets>, ITemporaryBasketsRepo
    {
        public TemporaryBasketsRepo(DbContext context) : base(context)
        {

        }
    }
}