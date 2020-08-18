using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using NewsletterX.Core.Domain.Model;
using NewsletterX.Core.Domain.Serivce;

namespace NewsletterX.Core.Application.Serivce
{
    public class SubscriptionService
    {
        private readonly IEmailService _emailService;
        private readonly ISubscriptionRepository _subscriptionRepository;

        public SubscriptionService(
            IEmailService emailService, 
            ISubscriptionRepository subscriptionRepository)
        {
            _emailService = emailService;
            _subscriptionRepository = subscriptionRepository;
        }

        public async Task<bool> Subscribe(Subscription request)
        {
            var subscription = new Subscription(request.Name, request.Email);
            var isCreated = await _subscriptionRepository.Create(subscription);
            if (!isCreated) return false;
            var email = new ConfirmSubscriptionEmail(
                request.Email, "tomerik@getacademy.no", subscription.VerificationCode);
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

            subscription.isVerified = true;
            var hasUpdated = await _subscriptionRepository.Update(subscription);
            return hasUpdated;
        }
    }
}
