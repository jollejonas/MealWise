using MealWiseAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace MealWiseAPI.Data;

public class MealWiseContext : DbContext
{
    public MealWiseContext(DbContextOptions<MealWiseContext> options) : base(options)
    {
    }
    public DbSet<MealPlan> MealPlans { get; set; }
    public DbSet<Recipe> Recipes { get; set; }
    public DbSet<Ingredient> Ingredients { get; set; }
    public DbSet<IngredientGroup> IngredientGroups { get; set; }
    public DbSet<IngredientGroupIngredient> IngredientGroupIngredients { get; set; }
    public DbSet<RecipeStep> RecipeSteps { get; set; }
    public DbSet<MealPlanRecipe> MealPlanRecipes { get; set; }
    public DbSet<ShoppingList> ShoppingLists { get; set; }
    public DbSet<User> Users { get; set; }
}
