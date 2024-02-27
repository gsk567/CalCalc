using System;

namespace CalCalc.Data;

public class MealFood : Entity
{
    public Guid FoodId { get; set; }

    public Food Food { get; set; }

    public Guid MealId { get; set; }

    public Meal Meal { get; set; }

    /// <summary>
    /// Amount is in grams.
    /// </summary>
    public double Amount { get; set; }

    /// <summary>
    /// Amount is in grams.
    /// </summary>
    public double AmountInCookedState { get; set; }
}