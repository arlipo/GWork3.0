using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Internal;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Primitives;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Infra;
using Open.Sentry;
using Open.Sentry.Data;
using Open.Sentry.Services;
namespace Open.Tests.Sentry {
    [TestClass] public class StartupTests : BaseTests {
        private Startup startup;
        private testConfiguration configuration;
        private ServiceCollection services;
        private testApp app;
        private IHostingEnvironment env;
        private class testConfiguration : IConfiguration {
            public List<string> Keys { get; } = new List<string>();
            public IConfigurationSection GetSection(string key) {
                Keys.Add(key);
                return null;
            }
            public IEnumerable<IConfigurationSection> GetChildren() => null;
            public IChangeToken GetReloadToken() => null;
            public string this[string key] {
                get => null;
                set { }
            }
        }
        private class testServiceProvider : IServiceProvider {
            public object GetService(Type serviceType) {
                if (serviceType.Name == "MvcRouteHandler")
                    return new MvcRouteHandler(null, null, null, new NullLoggerFactory());
                if (serviceType.Name == "IInlineConstraintResolver")
                    return new DefaultInlineConstraintResolver(
                        new OptionsWrapper<RouteOptions>(
                            new RouteOptions()));
                if (serviceType.Name == "IActionDescriptorCollectionProvider")
                    return new ActionDescriptorCollectionProvider(
                        new List<IActionDescriptorProvider>(), 
                        new List<IActionDescriptorChangeProvider>());
                return new MiddlewareFilterBuilder(null);
            }
        }
        private class testApp: IApplicationBuilder {
            public List<object> Middleware { get; } = new List<object>();
            public IApplicationBuilder Use(Func<RequestDelegate, RequestDelegate> middleware) {
                Middleware.Add(middleware.Target);
                return this;
            }
            public IApplicationBuilder New() {
                return this;
            }
            public RequestDelegate Build() {
                return null;
            }
            public IServiceProvider ApplicationServices { get; set; } = new testServiceProvider();
            public IFeatureCollection ServerFeatures { get; } = new FeatureCollection();
            public IDictionary<string, object> Properties { get; } = new Dictionary<string, object>();
        }
        private class testEnv : IHostingEnvironment {
            public string EnvironmentName { get; set; } = "Environment";
            public string ApplicationName { get; set; } = "Application";
            public string WebRootPath { get; set; } = "WebRoot";
            public IFileProvider WebRootFileProvider { get; set; } = new NullFileProvider();
            public string ContentRootPath { get; set; } = "ConnectionRoot";
            public IFileProvider ContentRootFileProvider { get; set; } = new NullFileProvider();
        }
        [TestInitialize] public override void TestInitialize() {
            base.TestInitialize();
            type = typeof(Startup);
            configuration = new testConfiguration();
            startup = new Startup(configuration);
            services = new ServiceCollection();
            app = new testApp();
            env = new testEnv();
        }

        [TestMethod] public void ConfigurationTest() {
            Assert.AreEqual(configuration, startup.Configuration);
        }

        [TestMethod] public void ConfigureServicesTest() {
            startup.ConfigureServices(services);
            Assert.AreEqual(1, configuration.Keys.Count);
            Assert.AreEqual("ConnectionStrings", configuration.Keys[0]);
            Assert.AreEqual(249, services.Count);
            isServiceRegistered<IEmailSender, EmailSender>();
            isServiceRegistered<ApplicationDbContext, ApplicationDbContext>();
            isServiceRegistered<SentryDbContext, SentryDbContext>();
        }
        private void isServiceRegistered<TService, TImplementation>() {
            var service = services.FirstOrDefault(x => x.ServiceType == typeof(TService));
            Assert.IsNotNull(service);
            Assert.AreEqual(service.ImplementationType, typeof(TImplementation));
        }
        [TestMethod] public void ConfigureTest() {
            startup.Configure(app, env);
            Assert.AreEqual(4, app.Middleware.Count);
        }

    }
}
