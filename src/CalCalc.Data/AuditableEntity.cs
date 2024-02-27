using System;

namespace CalCalc.Data;

public abstract class AuditableEntity : Entity, IAuditableEntity
{
    public string CreatedBy { get; set; }

    public DateTime CreatedOn { get; set; }

    public string UpdatedBy { get; set; }

    public DateTime UpdatedOn { get; set; }
}