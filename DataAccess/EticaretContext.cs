using DataAccess.Mappings;

namespace DataAccess
{
    public class EticaretContext:DbContext
    {
        // DbSet => EKLE,SİL,GÜNCELLE,LİSTELEME işlemlerimizi yaptıran bir Sınıf yapısıdır
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Customers> Customers { get; set; }
        public DbSet<OrderAddress> OrderAddress { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<TemporaryBaskets> TemporaryBaskets { get; set; }

        // Veritabanı Bağlantısı Gerçekleştiren Metot.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-RO1RB58\SQLEXPRESS;Database=EticaretDataBase;Trusted_Connection=True;");
        }
        // Veritabanında işlem yapılacağı zaman Mapping Olayını Gerçekleştiren Metot.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new OrderDetailsMap());
            modelBuilder.ApplyConfiguration(new CategoriesMap());
            modelBuilder.ApplyConfiguration(new CustomerMap());
            modelBuilder.ApplyConfiguration(new OrderAddressMap());
            modelBuilder.ApplyConfiguration(new TemporaryBasketMap());
            modelBuilder.ApplyConfiguration(new OrderMap());
            modelBuilder.ApplyConfiguration(new ProductsMap());
        }

    }
}
