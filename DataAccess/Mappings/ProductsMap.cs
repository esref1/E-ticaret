namespace DataAccess.Mappings
{
    public class ProductsMap : IEntityTypeConfiguration<Products>
    {
        public void Configure(EntityTypeBuilder<Products> builder)
        {
            builder.HasKey(x=> x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Name).HasMaxLength(100);
            builder.Property(x => x.MainImage).HasMaxLength(50);
            builder.Property(x => x.Images1).HasMaxLength(50).IsRequired(false);
            builder.Property(x => x.Images2).HasMaxLength(50).IsRequired(false);
            builder.Property(x => x.Images3).HasMaxLength(50).IsRequired(false);
            builder.Property(x => x.Images4).HasMaxLength(50).IsRequired(false);
            builder.Property(x => x.Price).HasColumnType("money");

            builder.HasOne(x => x.Categories).WithMany(x=> x.Products).HasForeignKey(x=> x.CategoriesId);

            builder.ToTable("Products");

        }
    }
}
