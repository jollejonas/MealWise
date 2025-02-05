using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MealWiseAPI.Migrations
{
    /// <inheritdoc />
    public partial class ShoppingListNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingLists_Users_UserId",
                table: "ShoppingLists");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "ShoppingLists",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "MealPlanId",
                table: "ShoppingLists",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ShoppingListItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShoppingListId = table.Column<int>(type: "int", nullable: false),
                    IngredientId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UnitOverride = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Checked = table.Column<bool>(type: "bit", nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingLists_MealPlanId",
                table: "ShoppingLists",
                column: "MealPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingListItem_IngredientId",
                table: "ShoppingListItem",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingListItem_ShoppingListId",
                table: "ShoppingListItem",
                column: "ShoppingListId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingLists_MealPlans_MealPlanId",
                table: "ShoppingLists",
                column: "MealPlanId",
                principalTable: "MealPlans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingLists_Users_UserId",
                table: "ShoppingLists",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingLists_MealPlans_MealPlanId",
                table: "ShoppingLists");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingLists_Users_UserId",
                table: "ShoppingLists");

            migrationBuilder.DropTable(
                name: "ShoppingListItem");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingLists_MealPlanId",
                table: "ShoppingLists");

            migrationBuilder.DropColumn(
                name: "MealPlanId",
                table: "ShoppingLists");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "ShoppingLists",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingLists_Users_UserId",
                table: "ShoppingLists",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
