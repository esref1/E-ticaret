using DataAccess.Abstract;
using DataAccess.Repository;

namespace DataAccess.Concrete
{
    public class ProductsRepo : Repositories<Products>, IProductsRepo
    {
        public ProductsRepo(DbContext context) : base(context)
        {

        }
    }
}