using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nop.Core.Domain.CustomDish;
using Nop.Data.Mapping;

namespace Nop.Data.Mapping.CustomDish
{
    public class IngredientMap : IEntityTypeConfiguration<Ingredient>
    {
        public void Configure(EntityTypeBuilder<Ingredient> builder)
        {
            builder.ToTable("Ingredient");
            builder.HasKey(i => i.Id);
        }
    }
}
