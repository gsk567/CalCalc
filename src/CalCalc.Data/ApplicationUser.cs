using System;
using Microsoft.AspNetCore.Identity;

namespace CalCalc.Data;

public class ApplicationUser : IdentityUser<Guid>, IEntity
{
}