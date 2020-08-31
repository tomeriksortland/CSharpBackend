using System.Threading.Tasks;
using DomainModel;

namespace DomainServices
{
    public interface IEmailService
    {
        Task<bool> Send(Email email);
    }
}
