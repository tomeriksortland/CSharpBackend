using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Core.DomainModel;

namespace Core.Domain.Services
{
    public interface ISubscriptionService
    {
        Task<bool> Subscribe(Subscription request);
        Task<bool> Verify(Subscription request);
    }
}
