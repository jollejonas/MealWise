using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MealWiseAPI.Migrations
{
    /// <inheritdoc />
    public partial class ShoppingListName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingLists_MealPlans_MealPlanId",
                table: "ShoppingLists");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingLists_MealPlanId",
                table: "ShoppingLists");

            migrationBuilder.DropColumn(
                name: "MealPlanId",
                table: "ShoppingLists");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "ShoppingLists",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "MealPlanId",
                table: "ShoppingListItem",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Source",
                table: "ShoppingListItem",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "ShoppingLists");

            migrationBuilder.DropColumn(
                name: "MealPlanId",
                table: "ShoppingListItem");

            migrationBuilder.DropColumn(
                name: "Source",
                table: "ShoppingListItem");

            migrationBuilder.AddColumn<int>(
                name: "MealPlanId",
                table: "ShoppingLists",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingLists_MealPlanId",
                table: "ShoppingLists",
                column: "MealPlanId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingLists_MealPlans_MealPlanId",
                table: "ShoppingLists",
                column: "MealPlanId",
                principalTable: "MealPlans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
