// (c) http://prideparrot.com/blog/archive/2012/7/securing_all_forms_using_antiforgerytoken
//
// (c) https://www.red-gate.com/simple-talk/dotnet/asp-net/anti-forgery-validation-asp-net-core/
//
//////////////////////////////////////////////////////////
using Microsoft.AspNetCore.Mvc.Filters;
namespace Open.Tests.Sentry
{
    public class TestAntiForgeryAttribute : IAuthorizationFilter {
        public static bool IsValidated;
        public void OnAuthorization(AuthorizationFilterContext context) {
        }
    }

}
