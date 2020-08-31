using System.Threading.Tasks;
using DataAccess.Model;
using DomainModel;
using DomainServices;
using Microsoft.AspNetCore.Mvc;

namespace API.Controller
{
    [Route("api/Subscribe")]
    [ApiController]
    public class SubscribeController : ControllerBase
    {
        private readonly ISubscriptionService _subscriptionService;

        public SubscribeController(ISubscriptionService subscriptionService)
        {
            _subscriptionService = subscriptionService;
        }

        [HttpPost]
        public async Task<bool> Subscribe(ViewModel viewModel)
        {
            var subscription = new Subscription {Name = viewModel.Name, Email = viewModel.Email};
            return await _subscriptionService.Subscribe(subscription);
        }

        [HttpPatch]
        public async Task<bool> Verify(ViewModel viewModel)
        {
            var subscription = new Subscription {Email = viewModel.Email, VerificationCode = viewModel.VerificationCode};
            return await _subscriptionService.Verify(subscription);
        }


    }
}