using Nop.Core;

namespace Nop.Core.Domain.CustomDish
{
    public class DishIngredientMapping : BaseEntity
    {
        public int DishId { get; set; }
        public int IngredientId { get; set; }
    }
}
