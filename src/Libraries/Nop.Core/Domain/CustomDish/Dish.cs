using System.Collections.Generic;
using System.Linq;
using Nop.Core;

namespace Nop.Core.Domain.CustomDish
{
    public class Dish : BaseEntity
    {
        public string Name { get; set; }
        public decimal TotalPrice { get; set; } // Thêm setter để có thể gán giá trị
        public virtual List<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
    }
}
