using System.Threading.Tasks;
using Open.Sentry.Services;
namespace Open.Tests {
    internal class mockEmailSender : IEmailSender
    {
        public string Email;
        public string Subject;
        public string Message;
        public Task SendEmailAsync(string email, string subject, string message)
        {
            Email = email;
            Subject = subject;
            Message = message;
            return Task.CompletedTask;
        }
    }
}