using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Core.Domain.Model;
using Core.Domain.Services;
using Core.DomainModel;
using Core.DomainServices;

namespace Core.ApplicationService
{
    public class SubscriptionService : ISubscriptionService
    {
        private readonly IEmailService _emailService;
        private readonly ISubscriptionRepository _subscriptionRepository;

        public SubscriptionService(IEmailService emailService, ISubscriptionRepository subscriptionRepository)
        {
            _emailService = emailService;
            _subscriptionRepository = subscriptionRepository;
        }

        public async Task<bool> Subscribe(Subscription request)
        {
            var subscription = new Subscription(request.Name, request.Email);
            var isCreated = await _subscriptionRepository.Create(subscription);
            if (!isCreated) return false;
            var url = $"https://localhost:44340/index.html?email={subscription.Email}&code={subscription.VerificationCode}";
            var text = $"Hello {request.Name}! <a href=\"{url}\">Click here to confirm subscription!";
            var email = new Email(request.Email, "tomerik@getacademy.no", "confrim subscription", text);
            var isSent = await _emailService.Send(email);
            return isSent;

        }

        public async Task<bool> Verify(Subscription verificationRequest)
        {
            var subscription = await _subscriptionRepository.ReadByEmail(verificationRequest.Email);
            if (subscription == null || verificationRequest.VerificationCode != subscription.VerificationCode)
            {
                return false;
            }

            subscription.Active = true;
            var hasUpdated = await _subscriptionRepository.Update(subscription);
            return hasUpdated;
        }
    }
}
