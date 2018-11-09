using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
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
using System;
using Open.Facade;
using Open.Sentry.MenuMasterNew;

namespace Open.Sentry {
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
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
            services.AddTransient<MenuMasterService, MenuMasterService>();



            //Password Strength Setting
            services.Configure<IdentityOptions>(options =>
            {
                // Password settings
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = false;
                options.Password.RequiredUniqueChars = 6;

                // Lockout settings
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                options.Lockout.MaxFailedAccessAttempts = 10;
                options.Lockout.AllowedForNewUsers = true;

                // User settings
                options.User.RequireUniqueEmail = true;
            });

            //Seting the Account Login page
            services.ConfigureApplicationCookie(options =>
            {
                // Cookie settings
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
                options.LoginPath = "/Account/Login"; // If the LoginPath is not set here, ASP.NET Core will default to /Account/Login
                options.LogoutPath = "/Account/Logout"; // If the LogoutPath is not set here, ASP.NET Core will default to /Account/Logout
                options.AccessDeniedPath = "/Account/AccessDenied"; // If the AccessDeniedPath is not set here, ASP.NET Core will default to /Account/AccessDenied
                options.SlidingExpiration = true;
            });
        }

        protected virtual void setMvcWithAntyFoggeryToken(IServiceCollection services)
        {
            services.AddMvc(options => options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute()));
        }

        protected virtual void setAuthentication(IServiceCollection services) { }
        protected virtual void setDatabase(IServiceCollection services)
        {
            var s = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ApplicationDbContext>(
                options => options.UseSqlServer(s));
            services.AddDbContext<SentryDbContext>(
                options => options.UseSqlServer(s));
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            setErrorPage(app, env);
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseMvc(routes =>
            {
                routes.MapRoute(name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
        protected virtual void setErrorPage(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else { app.UseExceptionHandler("/Home/Error"); }
        }






        private async Task CreateUserRoles(IServiceProvider serviceProvider)
        {
            var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var UserManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();


            IdentityResult roleResult;
            //Adding Addmin Role  
            var roleCheck = await RoleManager.RoleExistsAsync("Admin");
            if (!roleCheck)
            {
                //create the roles and seed them to the database  
                roleResult = await RoleManager.CreateAsync(new IdentityRole("Admin"));
            }

            roleCheck = await RoleManager.RoleExistsAsync("Manager");
            if (!roleCheck)
            {
                //create the roles and seed them to the database  
                roleResult = await RoleManager.CreateAsync(new IdentityRole("Manager"));
            }

            //Assign Admin role to the main User here we have given our newly loregistered login id for Admin management  
            ApplicationUser user = await UserManager.FindByEmailAsync("admin@gmail.com");
            var User = new ApplicationUser();
            await UserManager.AddToRoleAsync(user, "Admin");


            user = await UserManager.FindByEmailAsync("Afraz@gmail.com");
            await UserManager.AddToRoleAsync(user, "Manager");

        }
        
    }

}

