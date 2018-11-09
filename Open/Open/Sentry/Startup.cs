using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Open.Domain.Customers;
using Open.Domain.Goods;
using Open.Domain.Party;
using Open.Domain.Quantity;
using Open.Infra;
using Open.Infra.Users;
using Open.Infra.Goods;
using Open.Infra.Party;
using Open.Infra.Quantity;
using Open.Sentry.Data;
using Open.Sentry.Models;
using Open.Sentry.Services;
using System.Threading.Tasks;
using Open.Domain.Users;
using Open.Infra.Customers;

namespace Open.Sentry {
    public class Startup {
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services) {
            setDatabase(services);
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();
            setAuthentication(services);
            services.AddTransient<IEmailSender, EmailSender>();
            setMvcWithAntyFoggeryToken(services);
            services.AddScoped<ICountriesRepository, CountriesRepository>();
            services.AddScoped<ICurrencyRepository, CurrenciesRepository>();
            services.AddScoped<IGoodsRepository, GoodsRepository>();
            services.AddScoped<IUsersRepository, UsersRepository>();
            services.AddScoped<INationalCurrenciesRepository, NationalCurrenciesRepository>();
            services.AddScoped<IAddressesRepository, ContactsRepository>();
            services.AddScoped<ITelecomDeviceRegistrationsRepository, TelecomDeviceRegistrationsRepository>();
            services.AddScoped<IRateTypeRepository, RateTypesRepository>();
            services.AddScoped<IRateRepository, RatesRepository>();
            services.AddScoped<IPaymentMethodsRepository, PaymentMethodsRepository>();
            services.AddScoped<IPaymentsRepository, PaymentsRepository>();
        }

        protected virtual void setMvcWithAntyFoggeryToken(IServiceCollection services) {
            services.AddMvc(options => options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute()));
        }

        protected virtual void setAuthentication(IServiceCollection services) { }
        protected virtual void setDatabase(IServiceCollection services) {
            var s = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ApplicationDbContext>(
                options => options.UseSqlServer(s));
            services.AddDbContext<SentryDbContext>(
                options => options.UseSqlServer(s));
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env) {
            setErrorPage(app, env);
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseMvc(routes => {
                routes.MapRoute(name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
        protected virtual void setErrorPage(IApplicationBuilder app, IHostingEnvironment env) {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else { app.UseExceptionHandler("/Home/Error"); }
            }

    }


    //private async Task TaskAsync(ServiceProvider serviceProvider)
    //{
    //    //initializing custom roles 
    //    var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    //    var UserManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
    //    string[] roleNames = { "Admin", "Store-Manager", "Member" };
    //    IdentityResult roleResult;

    //    foreach (var roleName in roleNames)
    //    {
    //        var roleExist = await RoleManager.RoleExistsAsync(roleName);
    //        // ensure that the role does not exist
    //        if (!roleExist)
    //        {
    //            //create the roles and seed them to the database: 
    //            roleResult = await RoleManager.CreateAsync(new IdentityRole(roleName));
    //        }
    //    }

    //    // find the user with the admin email 
    //    var _user = await UserManager.FindByEmailAsync("admin@email.com");

    //    // check if the user exists
    //    if (_user == null)
    //    {
    //        //Here you could create the super admin who will maintain the web app
    //        var poweruser = new ApplicationUser
    //        {
    //            UserName = "Admin",
    //            Email = "admin@email.com",
    //        };
    //        string adminPassword = "12345";

    //        var createPowerUser = await UserManager.CreateAsync(poweruser, adminPassword);
    //        if (createPowerUser.Succeeded)
    //        {
    //            //here we tie the new user to the role
    //            await UserManager.AddToRoleAsync(poweruser, "Admin");

    //        }
    //    }
    //}
}

