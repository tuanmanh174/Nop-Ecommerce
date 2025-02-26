using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nop.Core.Domain.CustomDish;

namespace Nop.Data.Mapping.CustomDish
{
    public class DishIngredientMappingMap : IEntityTypeConfiguration<DishIngredientMapping>
    {
        public void Configure(EntityTypeBuilder<DishIngredientMapping> builder)
        {
            builder.ToTable("DishIngredientMapping"); // Xác định tên bảng trong Database

            builder.HasKey(di => di.Id); // Định nghĩa khóa chính

            builder.HasOne<Dish>()
                   .WithMany()
                   .HasForeignKey(di => di.DishId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne<Ingredient>()
                   .WithMany()
                   .HasForeignKey(di => di.IngredientId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
