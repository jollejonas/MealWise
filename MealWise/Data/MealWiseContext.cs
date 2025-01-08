using MealWise.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MealWise.Data;

public class MealWiseContext : DbContext
{
    public MealWiseContext(DbContextOptions<MealWiseContext> options) : base(options)
    {
    }
    public DbSet<MealPlan> MealPlans { get; set; }
    public DbSet<Recipe> Recipes { get; set; }
    public DbSet<Ingredient> Ingredients { get; set; }
    public DbSet<RecipeIngredient> RecipeIngredients { get; set; }
    public DbSet<MealPlanRecipe> MealPlanRecipes { get; set; }
    public DbSet<ShoppingList> ShoppingLists { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MealPlanRecipe>()
            .Property(e => e.MealType)
            .HasConversion(new EnumToStringConverter<MealType>());

        modelBuilder.Entity<MealPlanRecipe>()
            .HasOne(e => e.Recipe)
            .WithMany()
            .HasForeignKey(e => e.RecipeId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<MealPlanRecipe>()
            .HasOne(e => e.MealPlan)
            .WithMany()
            .HasForeignKey(e => e.MealPlanId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<RecipeIngredient>()
            .HasKey(ri => new { ri.RecipeId, ri.IngredientId });

        modelBuilder.Entity<RecipeIngredient>()
            .HasOne(ri => ri.Recipe)
            .WithMany(r => r.RecipeIngredients)
            .HasForeignKey(ri => ri.RecipeId);

        modelBuilder.Entity<RecipeIngredient>()
            .HasOne(ri => ri.Ingredient)
            .WithMany(i => i.RecipeIngredients)
            .HasForeignKey(ri => ri.IngredientId);
    }
}
