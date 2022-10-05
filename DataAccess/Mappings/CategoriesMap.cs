namespace DataAccess.Mappings
{
    public class CategoriesMap : IEntityTypeConfiguration<Categories>
    {
        public void Configure(EntityTypeBuilder<Categories> builder)
        {
            builder.HasKey(x=> x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x=> x.Name).HasMaxLength(50);

            builder.HasMany(x => x.Products).WithOne(x=> x.Categories).HasForeignKey(x=> x.CategoriesId).OnDelete(DeleteBehavior.Cascade);

            builder.ToTable("Categories");
        }
    }
}
