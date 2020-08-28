using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Core.Domain.Model;

namespace Core.Domain.Services
{
    public interface IEmailService
    {
        Task<bool> Send(Email email);
    }
}
