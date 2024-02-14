using System;

namespace CalCalc.Common.Contracts;

public interface ICurrentUser
{
    public Guid? Id { get; }
}