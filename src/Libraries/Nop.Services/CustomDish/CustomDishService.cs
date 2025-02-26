using System.Collections.Generic;
using System.Linq;
using Nop.Core.Domain.CustomDish;
using Nop.Data;
using Nop.Services.CustomDish;

namespace Nop.Services.CustomDish
{
    public class CustomDishService : ICustomDishService
    {
        private readonly IRepository<Dish> _dishRepository;
        private readonly IRepository<Ingredient> _ingredientRepository;
        private readonly IRepository<DishIngredientMapping> _dishIngredientMappingRepository;

        public CustomDishService(
            IRepository<Dish> dishRepository,
            IRepository<Ingredient> ingredientRepository,
            IRepository<DishIngredientMapping> dishIngredientMappingRepository)
        {
            _dishRepository = dishRepository;
            _ingredientRepository = ingredientRepository;
            _dishIngredientMappingRepository = dishIngredientMappingRepository;
        }

        public List<Ingredient> GetAllIngredients()
        {
            return _ingredientRepository.Table.ToList();
        }

        public Dish CreateDish(string name, List<int> ingredientIds)
        {
            var selectedIngredients = _ingredientRepository.Table
                .Where(i => ingredientIds.Contains(i.Id)).ToList();

            var totalPrice = selectedIngredients.Sum(i => i.Price);

            var dish = new Dish
            {
                Name = name,
                TotalPrice = totalPrice
            };

            _dishRepository.Insert(dish);

            foreach (var ingredientId in ingredientIds)
            {
                _dishIngredientMappingRepository.Insert(new DishIngredientMapping
                {
                    DishId = dish.Id,
                    IngredientId = ingredientId
                });
            }

            return dish;
        }
    }
}
