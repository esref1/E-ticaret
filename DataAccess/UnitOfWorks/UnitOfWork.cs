using Core.Results;
using Core.Results.ComplexTypes;
using DataAccess.Abstract;
using DataAccess.Concrete;

namespace DataAccess.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EticaretContext context;
        public UnitOfWork(EticaretContext context)
        {
            this.context = context;
        }

        // Singleton Design (Tek NESNE Yaklaşımı)
        // Kullanılacak Olan Sınıflardan Tek Bir Adet Yönetmemizi isteyen Bir Yaklaşımdır.

        private CategoriesRepo categories;
        private CustomerRepo customer;
        private OrderAddressRepo orderaddress;
        private OrderDetailsRepo orderdetails;
        private OrdersRepo orders;
        private ProductsRepo products;
        private TemporaryBasketsRepo temporarybasket;

        public ICategoriesRepo RepoCategories => categories ?? new CategoriesRepo(context);
        public ICustomersRepo RepoCustomers => customer ?? new CustomerRepo(context);
        public IOrderAddressRepo RepoOrderAddress => orderaddress ?? new OrderAddressRepo(context);
        public IOrderDetailsRepo RepoOrderDetails => orderdetails ?? new OrderDetailsRepo(context);
        public IOrdersRepo RepoOrders => orders ?? new OrdersRepo(context);
        public IProductsRepo RepoProducts => products ?? new ProductsRepo(context);
        public ITemporaryBasketsRepo RepoTemporaryBaskets => temporarybasket ?? new TemporaryBasketsRepo(context);
        public async Task<IResult> SaveChanges()
        {
            // Transaction Kontrolü
            // Birden fazla data aynı anda eklenmek istendiğinde, Datalar'ın hepsinin sorunsuz bir şekilde eklendiğinden emin olmak için kullanılan bir yaklaşımdır.
            using (context.Database.BeginTransaction())
            {
                try
                {
                    context.SaveChanges();
                    context.Database.CommitTransaction();
                    return Result.FactoryResult(StatusCode.Success,"İşlem Başarılı");
                }
                catch (Exception e)
                {
                    // Loglama İşlemlerini burada Gerçekleştirebilirsiniz.
                    context.Database.RollbackTransaction();
                    return Result.FactoryResult(StatusCode.Error, "İşlem Başarısız", e);
                }
            }
        }
    }
}
