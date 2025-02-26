using System.Collections.Generic;
using Nop.Core.Domain.CustomDish;

namespace Nop.Services.CustomDish
{
    public interface ICustomDishService
    {
        /// <summary>
        /// Lấy danh sách nguyên liệu
        /// </summary>
        /// <returns>Danh sách nguyên liệu</returns>
        List<Ingredient> GetAllIngredients();

        /// <summary>
        /// Tạo một món ăn mới từ các nguyên liệu đã chọn
        /// </summary>
        /// <param name="name">Tên món ăn</param>
        /// <param name="ingredientIds">Danh sách ID nguyên liệu</param>
        /// <returns>Món ăn đã được tạo</returns>
        Dish CreateDish(string name, List<int> ingredientIds);
    }
}
