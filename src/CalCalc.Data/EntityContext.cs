using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CalCalc.Common.Contracts;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CalCalc.Data;

public class EntityContext : IdentityUserContext<ApplicationUser, Guid>
{
    private readonly EntityState[] auditableStates =
    {
        EntityState.Added,
        EntityState.Modified,
    };

    private readonly ICurrentUser currentUser;

    public EntityContext(
        DbContextOptions<EntityContext> options,
        ICurrentUser currentUser = null)
        : base(options)
    {
        this.currentUser = currentUser;
    }

    public DbSet<Food> Foods { get; set; }

    public DbSet<Meal> Meals { get; set; }

    public DbSet<MealFood> MealFoods { get; set; }

    public override int SaveChanges(bool acceptAllChangesOnSuccess)
    {
        this.HandleAuditableEntities();
        return base.SaveChanges(acceptAllChangesOnSuccess);
    }

    public override int SaveChanges()
    {
        this.HandleAuditableEntities();
        return base.SaveChanges();
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        this.HandleAuditableEntities();
        return base.SaveChangesAsync(cancellationToken);
    }

    public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
    {
        this.HandleAuditableEntities();
        return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
    }

    private void HandleAuditableEntities()
    {
        var userId = this.currentUser?.Id?.ToString();
        var now = DateTime.UtcNow;
        var auditableEntries = this.ChangeTracker
            .Entries()
            .Where(x => x.Entity is IAuditableEntity &&
                        this.auditableStates.Contains(x.State))
            .ToList();

        foreach (var entry in auditableEntries)
        {
            var entity = entry.Entity as IAuditableEntity;
            entity.UpdatedOn = now;
            entity.UpdatedBy = userId;

            if (entry.State == EntityState.Added)
            {
                entity.CreatedOn = now;
                entity.CreatedBy = userId;
            }
        }
    }
}