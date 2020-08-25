using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.ApplicationService;
using Core.DomainModel;
using Infrastructure.DataAccess.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Nyhetsbrev.Controller
{
    [Route("api/Subscribe")]
    [ApiController]
    public class SubscribeController : ControllerBase
    {
        private readonly SubscriptionService _subscriptionService;

        public SubscribeController(SubscriptionService subscriptionService)
        {
            _subscriptionService = subscriptionService;
        }

        [HttpPost]
        public async Task<bool> Subscribe(ViewModel viewModel)
        {
            var subscription = new Subscription {Name = viewModel.Name, Email = viewModel.Email};
            return await _subscriptionService.Subscribe(subscription);
        }


    }
}