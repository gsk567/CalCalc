using CalCalc.Common.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CalCalc.Data.Configurations;

public class FoodConfiguration : IEntityTypeConfiguration<Food>
{
    public void Configure(EntityTypeBuilder<Food> builder)
    {
        builder
            .Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(ModelDefaults.MaxNameLength);
        
        builder
            .Property(x => x.Weight)
            .IsRequired();
        
        builder
            .HasMany(x => x.MealParticipations)
            .WithOne(x => x.Food)
            .HasForeignKey(x => x.FoodId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}