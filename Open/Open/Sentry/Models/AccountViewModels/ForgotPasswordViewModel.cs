using System.ComponentModel.DataAnnotations;
namespace Open.Sentry.Models.AccountViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
