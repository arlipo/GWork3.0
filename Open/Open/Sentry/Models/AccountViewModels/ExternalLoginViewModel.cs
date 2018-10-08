using System.ComponentModel.DataAnnotations;
namespace Open.Sentry.Models.AccountViewModels
{
    public class ExternalLoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
