using System;
using System.Collections.Generic;
using System.Text;

namespace NumberPuzzleWeb.Core.DomainModel
{
    public class BaseModel
    {
        public Guid Id { get; }

        public BaseModel()
        {
            Id = Guid.NewGuid();
        }

        public BaseModel(Guid id)
        {
            Id = id;
        }
    }
}
