using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CalCalc.Data.Configurations;

public class MealConfiguration : IEntityTypeConfiguration<Meal>
{
    public void Configure(EntityTypeBuilder<Meal> builder)
    {
        builder
            .HasMany(x => x.Foods)
            .WithOne(x => x.Meal)
            .HasForeignKey(x => x.MealId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}