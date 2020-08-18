using System;
using System.Collections.Generic;
using System.Text;

namespace NewsletterX.Core.Domain.Model
{
    class BaseEntity
    {
        public Guid Id { get; set; }

        public BaseEntity()
        {
            Id = Guid.NewGuid();
        }
    }
}
