using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using Core.ApplicationService;
using Core.Domain.Model;
using Core.Domain.Services;
using Core.DomainModel;
using Core.DomainServices;
using Moq;
using NUnit.Framework;

namespace Core.Test
{
    public class Tests
    { 

        [Test]
        public async Task TestSubscriptionOk()
        {
            
            var emailServiceMock = new Mock<IEmailService>();
            var subscriptionRepoMock = new Mock<ISubscriptionRepository>();
            emailServiceMock
                .Setup(es => es.Send(It.IsAny<Email>()))
                .ReturnsAsync(true);
            subscriptionRepoMock
                .Setup(sr => sr.Create(It.IsAny<Subscription>()))
                .ReturnsAsync(true);
            var service = new SubscriptionService(emailServiceMock.Object, subscriptionRepoMock.Object);

            
            var subscription = new Subscription("Tom Erik", "tomerik@getacademy.no");
            var subscribeIsSuccess = await service.Subscribe(subscription);

            
            Assert.IsTrue(subscribeIsSuccess);
            emailServiceMock.Verify(es=>es.Send(It.Is<Email>(e=>e.To == "tomerik@getacademy.no")));
            subscriptionRepoMock.Verify(sr=>sr.Create(It.Is<Subscription>(s=>s.Email == "tomerik@getacademy.no")));
            emailServiceMock.VerifyNoOtherCalls();
            subscriptionRepoMock.VerifyNoOtherCalls();
        }

        [Test]
        public async Task TestSubscriptionDbFail()
        {
            var emailServiceMock = new Mock<IEmailService>();
            var subscriptionRepoMock = new Mock<ISubscriptionRepository>();

            subscriptionRepoMock
                .Setup(sr => sr.Create(It.IsAny<Subscription>()))
                .ReturnsAsync(false);

            var service = new SubscriptionService(emailServiceMock.Object, subscriptionRepoMock.Object);
            var subscription = new Subscription("Tom Erik", "tomerik@getacademy.no");
            var isSuccess = await service.Subscribe(subscription);

            Assert.IsFalse(isSuccess);
            subscriptionRepoMock.Verify(sr => sr.Create(It.Is<Subscription>(s =>s.Name == "Tom Erik")));
            emailServiceMock.VerifyNoOtherCalls();
            subscriptionRepoMock.VerifyNoOtherCalls();
        }

        [Test]
        public async Task TestSubscriptionEmailFail()
        {
            var emailServiceMock = new Mock<IEmailService>();
            var subscriptionRepoMock = new Mock<ISubscriptionRepository>();

            emailServiceMock
                .Setup(es => es.Send(It.IsAny<Email>()))
                .ReturnsAsync(false);
            subscriptionRepoMock
                .Setup(sr => sr.Create(It.IsAny<Subscription>()))
                .ReturnsAsync(true);

            var service = new SubscriptionService(emailServiceMock.Object, subscriptionRepoMock.Object);
            var subscription = new Subscription("Tom Erik", "tomerik@getacademy.no");
            var isSuccess = await service.Subscribe(subscription);
            Assert.IsFalse(isSuccess);
            emailServiceMock.Verify(es => es.Send(It.Is<Email>(e=>e.To=="tomerik@getacademy.no")));
            subscriptionRepoMock.Verify(sr => sr.Create(It.Is<Subscription>(s=>s.Name=="Tom Erik")));
            emailServiceMock.VerifyNoOtherCalls();
            subscriptionRepoMock.VerifyNoOtherCalls();
        }

        [Test]
        public async Task VerifyOk()
        {
            var code = "ed863c05-c1ef-4537-n4e4-31hksg3h7654";
            var email = "tomerik@getacademy.no";
            var verificationRequest = new Subscription(null, email, code);
            var subscriptionFromDb = new Subscription(null, null, code);

            var subscriptionRepoMock = new Mock<ISubscriptionRepository>();
            subscriptionRepoMock
                .Setup(sr => sr.ReadByEmail(email))
                .ReturnsAsync(subscriptionFromDb);
            subscriptionRepoMock
                .Setup(sr => sr.Update(It.IsAny<Subscription>()))
                .ReturnsAsync(true);
            var service = new SubscriptionService(null, subscriptionRepoMock.Object);
            var isSuccess = await service.Verify(verificationRequest);
            Assert.IsTrue(isSuccess);
            subscriptionRepoMock.Verify(sr => sr.Update(It.IsAny<Subscription>()));
        }

        [Test]
        public async Task TestVerifyInvalidCode()
        {
            var code1 = "jgh765e02-j6rd-7256-k5x3-95hgfd9g3267";
            var code2 = "fs925n17-j6rd-7256-k5x3-95hgfd9g3267";
            var email = "tomerik@getacademy.no";
            var verificationRequest = new Subscription(null, email, code1);
            var subscriptionFromDb = new Subscription(null, null, code2);

            var subscriptionRepoMock = new Mock<ISubscriptionRepository>();
            subscriptionRepoMock
                .Setup(sr=>sr.ReadByEmail(email))
                .ReturnsAsync(subscriptionFromDb);
            var service = new SubscriptionService(null, subscriptionRepoMock.Object);
            var isSuccess = await service.Verify(verificationRequest);
            Assert.IsFalse(isSuccess);
            subscriptionRepoMock.Verify(sr=>sr.ReadByEmail(email));
            subscriptionRepoMock.VerifyNoOtherCalls();
        }
    }
}