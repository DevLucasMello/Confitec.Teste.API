using Confitec.Core.DomainObjects;
using System;

namespace Confitec.Core.Data
{
    public interface IRepository<T> : IDisposable where T : IAggregateRoot
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
