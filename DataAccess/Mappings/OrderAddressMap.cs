namespace DataAccess.Mappings
{
    public class OrderAddressMap : IEntityTypeConfiguration<OrderAddress>
    {
        public void Configure(EntityTypeBuilder<OrderAddress> builder)
        {
            builder.HasKey(x=> x.Id);
            builder.Property(x=> x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.NameSurname).HasMaxLength(100);
            builder.Property(x => x.Phone).HasMaxLength(20);
            builder.Property(x => x.City).HasMaxLength(50);
            builder.Property(x => x.District).HasMaxLength(50);

            builder.HasOne(x=> x.Orders).WithMany(x=> x.OrderAddress).HasForeignKey(x=> x.OrdersId);

            builder.Property(x=> x.FullAddress).HasMaxLength(350);

            builder.ToTable("OrderAddress");
        }
    }
}
