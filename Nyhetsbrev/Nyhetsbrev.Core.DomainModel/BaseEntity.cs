using System;

namespace Nyhetsbrev.Core.DomainModel
{
    public class BaseEntity
    {
        public Guid? Id { get; }

        public BaseEntity(Guid? id = null)
        {
            Id = id ?? Guid.NewGuid();
        }
    }
}
