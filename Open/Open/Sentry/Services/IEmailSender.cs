using System.Threading.Tasks;
namespace Open.Sentry.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
