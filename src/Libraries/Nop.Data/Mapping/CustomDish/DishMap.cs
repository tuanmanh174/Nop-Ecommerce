using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nop.Core.Domain.CustomDish;

namespace Nop.Data.Mapping.CustomDish
{
    public class DishMap : IEntityTypeConfiguration<Dish>
    {
        public void Configure(EntityTypeBuilder<Dish> builder)
        {
            builder.ToTable("Dish"); // Xác định tên bảng trong Database
            builder.HasKey(d => d.Id); // Đặt khóa chính
        }
    }
}
