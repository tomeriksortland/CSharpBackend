using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using NewsletterX.Core.Domain.Model;
using NewsletterX.Core.Domain.Serivce;

namespace NewsletterX.Infrastructure.API
{
    public class EmailService : IEmailService
    {
        public Task<bool> Send(Email email)
        {
            return Task.FromResult(true);
        }
    }
}
