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
        // Enum konvertering
        modelBuilder.Entity<MealPlanRecipe>()
            .Property(e => e.MealType)
            .HasConversion(new EnumToStringConverter<MealType>());

        // Relationer og sletteadfærd
        modelBuilder.Entity<MealPlanRecipe>()
            .HasOne(e => e.Recipe)
            .WithMany()
            .HasForeignKey(e => e.RecipeId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<RecipeIngredient>()
            .HasKey(ri => new { ri.RecipeId, ri.IngredientId });

        // Seed Users
        modelBuilder.Entity<User>().HasData(
            new User { Id = 1, Username = "johndoe", PasswordHash = "hashedpassword123", Email = "john.doe@example.com", Name = "John Doe", CreatedAt = new DateTime(2025, 1, 1), UpdatedAt = new DateTime(2025, 1, 1) }
        );

        // Seed Ingredients
        modelBuilder.Entity<Ingredient>().HasData(
            new Ingredient { Id = 1, Name = "Kartoffel", UnitType = "kg" }
        );

        // Seed Recipes
        modelBuilder.Entity<Recipe>().HasData(
            new Recipe
            {
                Id = 1,
                Title = "Kartoffelsalat",
                Description = "Lækker salat",
                Instructions = "Kog kartoflerne og skær dem i skiver. Bland dem med mayonnaise og purløg.",
                PrepTime = 15,
                CookTime = 20,
                Servings = 4,
                ImageUrl = "",
                UserId = 1,
                CreatedAt = DateOnly.FromDateTime(new DateTime(2025, 1, 1)),
                UpdatedAt = DateOnly.FromDateTime(new DateTime(2025, 1, 1))
            }
        );

        // Seed RecipeIngredients
        modelBuilder.Entity<RecipeIngredient>().HasData(
            new RecipeIngredient { RecipeId = 1, IngredientId = 1, Quantity = 0.5, UnitOverride = "kg" }
        );
    }
}
