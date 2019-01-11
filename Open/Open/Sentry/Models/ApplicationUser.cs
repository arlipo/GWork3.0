using Microsoft.AspNetCore.Identity;
namespace Open.Sentry.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        private int credits = -1;
        public int Credits
        {
            get => credits == -1 ? 100 : credits;
            set => credits = value;
        }
    }
}
