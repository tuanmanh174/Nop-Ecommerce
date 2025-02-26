using FluentMigrator;
using Nop.Data.Migrations;
using static LinqToDB.Reflection.Methods.LinqToDB;

namespace Nop.Data.Migrations
{
    [NopMigration("2024/02/26 12:00:00", "Nop.Data schema update - Add Dish, Ingredient, and DishIngredientMapping tables", MigrationProcessType.Update)]
    public class AddDishTables : MigrationBase
    {
        public override void Up()
        {
            // Tạo bảng Ingredient (Danh sách nguyên liệu)
            if (!Schema.Table("Ingredient").Exists())
            {
                Create.Table("Ingredient")
                    .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                    .WithColumn("Name").AsString(255).NotNullable()
                    .WithColumn("Price").AsDecimal().NotNullable();
            }

            // Tạo bảng Dish (Danh sách món ăn)
            if (!Schema.Table("Dish").Exists())
            {
                Create.Table("Dish")
                    .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                    .WithColumn("Name").AsString(255).NotNullable()
                    .WithColumn("TotalPrice").AsDecimal().NotNullable();
            }

            // Tạo bảng DishIngredientMapping (Quan hệ món ăn - nguyên liệu)
            if (!Schema.Table("DishIngredientMapping").Exists())
            {
                Create.Table("DishIngredientMapping")
                    .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                    .WithColumn("DishId").AsInt32().NotNullable()
                    .WithColumn("IngredientId").AsInt32().NotNullable();

                // Thêm khóa ngoại
                Create.ForeignKey("FK_DishIngredientMapping_Dish")
                    .FromTable("DishIngredientMapping").ForeignColumn("DishId")
                    .ToTable("Dish").PrimaryColumn("Id");

                Create.ForeignKey("FK_DishIngredientMapping_Ingredient")
                    .FromTable("DishIngredientMapping").ForeignColumn("IngredientId")
                    .ToTable("Ingredient").PrimaryColumn("Id");
            }
        }

        public override void Down()
        {
            //if (Schema.Table("DishIngredientMapping").Exists())
            //{
            //    Delete.Table("DishIngredientMapping");
            //}
            //if (Schema.Table("Dish").Exists())
            //{
            //    Delete.Table("Dish");
            //}
            //if (Schema.Table("Ingredient").Exists())
            //{
            //    Delete.Table("Ingredient");
            //}
        }
    }
}
