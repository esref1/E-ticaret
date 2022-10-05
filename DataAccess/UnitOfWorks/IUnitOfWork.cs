using Core.Results;
using DataAccess.Abstract;

namespace DataAccess.UnitOfWorks
{
    public interface IUnitOfWork
    {
        public ICategoriesRepo RepoCategories { get; }
        public ICustomersRepo RepoCustomers { get; }
        public IOrderAddressRepo RepoOrderAddress { get; }
        public IOrderDetailsRepo RepoOrderDetails { get; }
        public IOrdersRepo RepoOrders { get; }
        public IProductsRepo RepoProducts { get; }
        public ITemporaryBasketsRepo RepoTemporaryBaskets { get; }
        public Task<IResult> SaveChanges();
    }
}
