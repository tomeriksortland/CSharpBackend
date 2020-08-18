using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using NewsletterX.Core.Domain.Model;

namespace NewsletterX.Core.Domain.Serivce
{
    public interface IEmailService
    {
        Task<bool> Send(Email email);
    }
}
