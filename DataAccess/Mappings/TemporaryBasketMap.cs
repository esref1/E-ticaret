using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mappings
{
    public class TemporaryBasketMap : IEntityTypeConfiguration<TemporaryBaskets>
    {
        public void Configure(EntityTypeBuilder<TemporaryBaskets> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Name).HasMaxLength(100);
            builder.Property(x => x.MainImages).HasMaxLength(50);
            builder.Property(x => x.Price).HasColumnType("money");

            builder.ToTable("TemporaryBaskets");
        }
    }
}
