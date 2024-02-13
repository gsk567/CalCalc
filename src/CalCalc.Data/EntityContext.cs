using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CalCalc.Data;

public class EntityContext : IdentityUserContext<ApplicationUser, Guid>
{
    public EntityContext(DbContextOptions<EntityContext> options)
        : base(options)
    {
    }
}