using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CalCalc.Data;

public class Meal : AuditableEntity
{
    public Meal()
    {
        this.Foods = new HashSet<MealFood>();
    }

    public string Name { get; set; }

    public ICollection<MealFood> Foods { get; }
}