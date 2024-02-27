using System;

namespace CalCalc.Service.Foods.Models;

public class FoodModel
{
    public Guid Id { get; set; }

    public string CreatedBy { get; set; }

    public DateTime CreatedOn { get; set; }

    public string UpdatedBy { get; set; }

    public DateTime UpdatedOn { get; set; }

    public string Name { get; set; }

    public double Weight { get; set; }

    public int Calories { get; set; }

    public double Carbohydrates { get; set; }

    public double Sugars { get; set; }

    public double Fats { get; set; }

    public double Protein { get; set; }

    public double Salt { get; set; }

    public double Fibers { get; set; }

    public double Water { get; set; }
}