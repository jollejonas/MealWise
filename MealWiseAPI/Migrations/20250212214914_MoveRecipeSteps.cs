using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MealWiseAPI.Migrations
{
    /// <inheritdoc />
    public partial class MoveRecipeSteps : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecipeSteps_Recipes_RecipeId",
                table: "RecipeSteps");

            migrationBuilder.AlterColumn<int>(
                name: "RecipeId",
                table: "RecipeSteps",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "IngredientGroupId",
                table: "RecipeSteps",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_RecipeSteps_IngredientGroupId",
                table: "RecipeSteps",
                column: "IngredientGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeSteps_IngredientGroups_IngredientGroupId",
                table: "RecipeSteps",
                column: "IngredientGroupId",
                principalTable: "IngredientGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeSteps_Recipes_RecipeId",
                table: "RecipeSteps",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecipeSteps_IngredientGroups_IngredientGroupId",
                table: "RecipeSteps");

            migrationBuilder.DropForeignKey(
                name: "FK_RecipeSteps_Recipes_RecipeId",
                table: "RecipeSteps");

            migrationBuilder.DropIndex(
                name: "IX_RecipeSteps_IngredientGroupId",
                table: "RecipeSteps");

            migrationBuilder.DropColumn(
                name: "IngredientGroupId",
                table: "RecipeSteps");

            migrationBuilder.AlterColumn<int>(
                name: "RecipeId",
                table: "RecipeSteps",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeSteps_Recipes_RecipeId",
                table: "RecipeSteps",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
