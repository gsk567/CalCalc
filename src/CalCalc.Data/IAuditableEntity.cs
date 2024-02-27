using System;

namespace CalCalc.Data;

public interface IAuditableEntity : IEntity
{
    string CreatedBy { get; set; }

    DateTime CreatedOn { get; set; }

    string UpdatedBy { get; set; }

    DateTime UpdatedOn { get; set; }
}