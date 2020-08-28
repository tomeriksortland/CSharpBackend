using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.ApplicationService;
using Core.Domain.Services;
using Core.DomainModel;
using Infrastructure.DataAccess.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Nyhetsbrev.Controller
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
            var subscription = new Subscription { Email = viewModel.Email, VerificationCode = viewModel.VerificationCode };
                return await _subscriptionService.Verify(subscription);
        }


    }
}