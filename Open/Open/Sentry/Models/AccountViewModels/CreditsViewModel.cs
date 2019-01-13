using System.ComponentModel.DataAnnotations;

namespace Open.Sentry.Models.AccountViewModels
{
    public class CreditsViewModel
    {
        [Required]
        [DataType(DataType.Currency)]
        [Display(Name = "Balance")]
        public decimal Credits { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
