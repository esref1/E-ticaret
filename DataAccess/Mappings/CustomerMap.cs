namespace DataAccess.Mappings
{
    public class CustomerMap : IEntityTypeConfiguration<Customers>
    {
        public void Configure(EntityTypeBuilder<Customers> builder)
        {
            builder.HasKey(x=> x.Id);
            builder.Property(x => x.NameSurname).HasMaxLength(100);
            builder.Property(x => x.Email).HasMaxLength(50);
            builder.Property(x => x.Phone).HasMaxLength(20);
            builder.Property(x => x.Password).HasMaxLength(20);


            builder.HasMany(x => x.Orders).WithOne(x => x.Customers).HasForeignKey(x=> x.CustomersId);

            builder.ToTable("Customers");

        }
    }
}
