using System;
using Microsoft.AspNetCore.Authentication;
namespace Open.Tests.Sentry {

    public static class TestAuthenticationExtensions {

        public static AuthenticationBuilder AddTestAuth(this AuthenticationBuilder builder,
            Action<TestAuthenticationOptions> configureOptions) {
            return builder.AddScheme<TestAuthenticationOptions, TestAuthenticationHandler>(
                "Test Scheme", "Test Auth", configureOptions);
        }

    }

}




