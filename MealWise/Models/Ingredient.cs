﻿namespace MealWise.Models;

public class Ingredient
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string UnitType { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
