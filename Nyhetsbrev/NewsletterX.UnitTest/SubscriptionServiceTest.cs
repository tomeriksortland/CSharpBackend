using System.Threading.Tasks;
using Moq;
using NewsletterX.Core.Application.Serivce;
using NewsletterX.Core.Domain.Model;
using NewsletterX.Core.Domain.Serivce;
using NewsletterX.Infrastructure.API;
using NUnit.Framework;

namespace NewsletterX.UnitTest
{
    public class Tests
    {
       [Test]
        public async Task TestSubscriptionOk()
        {
            //arrange
            var emailServiceMock = new Mock<IEmailService>();
            var subscriptionRepoMock = new Mock<ISubscriptionRepository>();
            emailServiceMock.Setup(es => es.Send(It.IsAny<Email>()))
                            .ReturnsAsync(true);
            subscriptionRepoMock.Setup(sr => sr.Create(It.IsAny<Subscription>()))
                            .ReturnsAsync(true);
            var service = new SubscriptionService(emailServiceMock.Object, subscriptionRepoMock.Object);

            //act
            var subscription = new Subscription("TomErik", "tomerik@getacademy.no");
            var subscribeIsSuccess = await service.Subscribe(subscription);

            //assert

            Assert.IsTrue(subscribeIsSuccess);
            emailServiceMock.Verify(
                es => es.Send(It.Is<Email>(e => e.To == "tomerik@getacademy.no")));
            subscriptionRepoMock.Verify(
                sr => sr.Create(It.Is<Subscription>(s => s.Email == "tomerik@getacademy.no")));
            emailServiceMock.VerifyNoOtherCalls();
            subscriptionRepoMock.VerifyNoOtherCalls();
        }

        [Test]
        public async Task TestSubscriptionOk2()
        {
            //samme som over, men uten Mock-rammeverket.

            //arrange
            var emailService = new EmailService();
            var subscriptionRepo = new SubscriptionRepository();
            var service = new SubscriptionService(emailService, subscriptionRepo);

            //act
            var subscription = new Subscription("Tom Erik", "tomerik@getacademy.no");
            var subscribeIsSuccess = await service.Subscribe(subscription);

            //assert
            //Assert.IsTrue(subscribeIsSuccess);
            //Assert.AreEqual("tomerik@getacademy.no", emailService.SentEmailToAdress);
            //Assert.AreEqual("tomerik@getacademy.no", subscriptionRepo.CreatedEmailToAdress);
            //Assert.AreEqual(1, emailService.CallCount);
            //Assert.AreEqual(1, subscriptionRepo.CallCount);

        }
    }
}