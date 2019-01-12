using Microsoft.AspNetCore.Identity;
namespace Open.Sentry.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        private decimal credits = -1;
        public decimal Credits
        {
            get => credits == -1 ? 1000 : credits;
            set => credits = value;
        }

        //remove true, if added
        public bool RemoveCredits(decimal amount)
        {
            if (amount > credits) return false;
            Credits -= amount;
            return true;
        }

        public void RemoveAllCredits()
        {
            Credits = 0;
        }

        public void AddCredits(decimal amount)
        {
            Credits += amount > 0 ? amount : 0;
        }
    }
}
