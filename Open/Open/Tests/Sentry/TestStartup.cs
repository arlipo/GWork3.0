using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Open.Infra;
using Open.Sentry;
using Open.Sentry.Data;
namespace Open.Tests.Sentry {

    public class TestStartup : Startup {

        public const string Testing = "Testing";

        public TestStartup(IConfiguration configuration) : base(configuration) { }

        protected override void setDatabase(IServiceCollection services) {
            services.AddDbContext<ApplicationDbContext>(
                options => options.UseInMemoryDatabase(Testing));
            services.AddDbContext<SentryDbContext>(
                options => options.UseInMemoryDatabase(Testing));
        }

        protected override void setAuthentication(IServiceCollection services) {
            services.AddAuthentication(options => {
                options.DefaultAuthenticateScheme = "Test Scheme";
                options.DefaultChallengeScheme = "Test Scheme";
            }).AddTestAuth(o => { });
        }

        protected override void setMvcWithAntyFoggeryToken(IServiceCollection services)
        {
            services.AddMvc(options =>options.Filters.Add(new TestAntiForgeryAttribute()));
        }

        protected override void setErrorPage(IApplicationBuilder app, IHostingEnvironment env) {
            app.UseBrowserLink();
            app.UseDeveloperExceptionPage();
            app.UseDatabaseErrorPage();
        }
    }
}

