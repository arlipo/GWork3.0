using Microsoft.AspNetCore.Identity;

namespace Open.Sentry.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {

        public decimal Credits { get; set; }

        public bool RemoveCredits(decimal price)
        {
            if (price > Credits) return false;
            Credits -= price;
            return true;
        }
    }
}
