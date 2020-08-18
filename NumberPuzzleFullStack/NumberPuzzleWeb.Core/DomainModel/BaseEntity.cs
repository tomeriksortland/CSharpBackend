using System;
using System.Collections.Generic;
using System.Text;

namespace NumberPuzzleWeb.Core.DomainModel
{
    public class BaseEntity
    {
        public Guid Id { get; }

        public BaseEntity()
        {
            Id = Guid.NewGuid();
        }

        public BaseEntity(Guid id)
        {
            Id = id;
        }
    }
}
