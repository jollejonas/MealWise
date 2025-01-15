using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MealWiseAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataUpdate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShoppingListItem");

            migrationBuilder.DeleteData(
                table: "MealPlanRecipes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "ShoppingLists",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "MealPlans",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { 1, 1 },
                column: "Id",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Description", "ImageUrl", "Instructions", "UpdatedAt" },
                values: new object[] { new DateOnly(2025, 1, 1), "Lækker salat", "", "Kog kartoflerne og skær dem i skiver. Bland dem med mayonnaise og purløg.", new DateOnly(2025, 1, 1) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ShoppingListItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IngredientId = table.Column<int>(type: "int", nullable: false),
                    ShoppingListId = table.Column<int>(type: "int", nullable: false),
                    Checked = table.Column<bool>(type: "bit", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UnitOverride = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingListItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShoppingListItem_Ingredients_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Ingredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShoppingListItem_ShoppingLists_ShoppingListId",
                        column: x => x.ShoppingListId,
                        principalTable: "ShoppingLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "Name", "UnitType" },
                values: new object[,]
                {
                    { 2, "Ris", "g" },
                    { 3, "Kyllingebryst", "stk" },
                    { 4, "Æg", "stk" }
                });

            migrationBuilder.InsertData(
                table: "MealPlans",
                columns: new[] { "Id", "EndDate", "Name", "StartDate", "UserId" },
                values: new object[] { 1, new DateOnly(2025, 1, 22), "Ugeplan", new DateOnly(2025, 1, 15), 1 });

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { 1, 1 },
                column: "Id",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Description", "ImageUrl", "Instructions", "UpdatedAt" },
                values: new object[] { new DateOnly(2025, 1, 15), "En lækker kartoffelsalat med creme fraiche.", "https://example.com/kartoffelsalat.jpg", "1. Kog kartoflerne. 2. Bland ingredienserne.", new DateOnly(2025, 1, 15) });

            migrationBuilder.InsertData(
                table: "ShoppingLists",
                columns: new[] { "Id", "CreatedAt", "Status", "UpdatedAt", "UserId" },
                values: new object[] { 1, new DateOnly(2025, 1, 15), "Active", new DateOnly(2025, 1, 15), 1 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 15, 16, 32, 10, 813, DateTimeKind.Local).AddTicks(7665), new DateTime(2025, 1, 15, 16, 32, 10, 816, DateTimeKind.Local).AddTicks(461) });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "Name", "PasswordHash", "UpdatedAt", "Username" },
                values: new object[] { 2, new DateTime(2025, 1, 15, 16, 32, 10, 816, DateTimeKind.Local).AddTicks(698), "jane.doe@example.com", "Jane Doe", "hashedpassword456", new DateTime(2025, 1, 15, 16, 32, 10, 816, DateTimeKind.Local).AddTicks(704), "janedoe" });

            migrationBuilder.InsertData(
                table: "MealPlanRecipes",
                columns: new[] { "Id", "Date", "MealPlanId", "MealType", "RecipeId", "ServingsOverride" },
                values: new object[] { 1, new DateOnly(2025, 1, 15), 1, "Dinner", 1, 2 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "IngredientId", "RecipeId", "Id", "Quantity", "UnitOverride" },
                values: new object[] { 4, 1, 2, 3.0, "stk" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "CookTime", "CreatedAt", "Description", "ImageUrl", "Instructions", "PrepTime", "Servings", "Title", "UpdatedAt", "UserId" },
                values: new object[] { 2, 30, new DateOnly(2025, 1, 15), "Kyllingebryst med ris og grøntsager.", "https://example.com/kylling_med_ris.jpg", "1. Steg kyllingen. 2. Kog risene.", 10, 2, "Stegt kylling med ris", new DateOnly(2025, 1, 15), 2 });

            migrationBuilder.InsertData(
                table: "ShoppingListItem",
                columns: new[] { "Id", "Checked", "IngredientId", "Quantity", "ShoppingListId", "UnitOverride" },
                values: new object[,]
                {
                    { 1, false, 1, 1, 1, "kg" },
                    { 2, true, 2, 500, 1, "g" }
                });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "IngredientId", "RecipeId", "Id", "Quantity", "UnitOverride" },
                values: new object[,]
                {
                    { 2, 2, 3, 200.0, "g" },
                    { 3, 2, 4, 2.0, "stk" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingListItem_IngredientId",
                table: "ShoppingListItem",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingListItem_ShoppingListId",
                table: "ShoppingListItem",
                column: "ShoppingListId");
        }
    }
}
