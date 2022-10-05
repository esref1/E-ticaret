using Entities;

namespace DataAccess.Mappings
{
    public class OrderMap : IEntityTypeConfiguration<Orders>
    {
        public void Configure(EntityTypeBuilder<Orders> builder)
        {

            builder.HasKey(x=> x.Id); // Otomatik Artan Olmayacak
            builder.Property(x=> x.PaymentType).HasMaxLength(25);
            builder.Property(x => x.OrderStatus).HasMaxLength(25);
            builder.Property(x => x.OrderDate).HasColumnType("datetime");
            builder.Property(x => x.TotalPrice).HasColumnType("money");

            // Customes(Tek) - Orders(Çok) Tek'e Çok İlişki
            builder.HasOne(x => x.Customers).WithMany(x => x.Orders).HasForeignKey(x=> x.CustomersId);

            // Orders(Tek) - OrderDetails(Çok) Tek'e Çok İlişki
            builder.HasMany(x => x.OrderDetails).WithOne(x => x.Orders).HasForeignKey(x => x.OrdersId);

            // Orders(Tek) - OrderAddress(Çok) Tek'e Çok İlişki
            builder.HasMany(x => x.OrderAddress).WithOne(x => x.Orders).HasForeignKey(x => x.OrdersId);

            builder.Property(x => x.CargoNumber).HasMaxLength(35);

            builder.ToTable("Orders");
        }
    }
}
