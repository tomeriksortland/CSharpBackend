using System.Threading.Tasks;
using DomainModel;

namespace DomainServices
{
    public interface ISubscriptionService
    {
        Task<bool> Subscribe(Subscription request);
        Task<bool> Verify(Subscription request);
    }
}
