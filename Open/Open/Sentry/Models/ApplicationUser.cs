using Microsoft.AspNetCore.Identity;

namespace Open.Sentry.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        private decimal credits = -1;

        public decimal Credits
        {
            get => credits == -1 ? credits = 500 : credits;
            set => credits = value;
        }

        public bool RemoveCredits(decimal price)
        {
            if (price > Credits) return false;
            Credits -= price;
            return true;
        }
    }
}
