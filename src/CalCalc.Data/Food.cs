using System.Collections.Generic;

namespace CalCalc.Data;

public class Food : AuditableEntity
{
    public Food()
    {
        this.MealParticipations = new HashSet<MealFood>();
    }
    
    public string Name { get; set; }

    /// <summary>
    /// Weight is in grams.
    /// </summary>
    public double Weight { get; set; }
    
    /// <summary>
    /// Based on the Weight.
    /// </summary>
    public int Calories { get; set; }

    /// <summary>
    /// Based on the Weight.
    /// </summary>
    public double Carbohydrates { get; set; }

    /// <summary>
    /// Based on the Weight.
    /// </summary>
    public double Sugars { get; set; }
    
    /// <summary>
    /// Based on the Weight.
    /// </summary>
    public double Fats { get; set; }
    
    /// <summary>
    /// Based on the Weight.
    /// </summary>
    public double Protein { get; set; }
    
    /// <summary>
    /// Based on the Weight.
    /// </summary>
    public double Salt { get; set; }

    /// <summary>
    /// Based on the Weight.
    /// </summary>
    public double Fibers { get; set; }

    /// <summary>
    /// Based on the Weight.
    /// </summary>
    public double Water { get; set; }
    
    public ICollection<MealFood> MealParticipations { get; }
}