using System.Net.Http.Headers;
using System.Reflection;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Presentation;
using TemperatureMonitor.Application.Database;
using TemperatureMonitor.Application.Database.Entities;

namespace TemperatureMonitor.IntegrationTests
{
    [TestClass]
    public class InitServer
    {
        static string connection = "Server=(localdb)\\MSSQLLocalDB;Database=TemperatureMonitor;Trusted_Connection=True;MultipleActiveResultSets=true";
        static TestServer server;
        static HttpClient client;
        static ApplicationDbContext applicationDbContext;
        static UserManager<UserEntity> userManager;

        public static TestServer Server { get { return server; } }
        public static HttpClient Client { get { return client; } }
        public static ApplicationDbContext DbContext { get { return applicationDbContext; } }
        public static UserManager<UserEntity> UserManager { get { return userManager; } }

        [AssemblyInitialize()]
        public static void AssemblyInitialize(TestContext testContext)
        {
            InitializeServer();
            InitializeClient();
            InitializeDatabase();
        }

        private static void InitializeClient()
        {
            client = Server.CreateClient();
            client.BaseAddress = new Uri("http://localhost:5000");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Test");
        }

        private static void InitializeDatabase()
        {
            if (Server.Services != null)
            {
                applicationDbContext = Server.Services.GetService<ApplicationDbContext>();
                userManager = Server.Services.GetService<UserManager<UserEntity>>();
            }
        }

        private static void InitializeServer()
        {
            var targetAssembly = typeof(Startup).GetTypeInfo().Assembly;
            var targetRoot = FindProjectPath(targetAssembly);

            var configuration = new ConfigurationBuilder()
                .SetBasePath(targetRoot)
                .AddJsonFile("appsettings.json")
                .Build();

            var webHostBuilder = new WebHostBuilder()
                .UseContentRoot(targetRoot)
                .UseConfiguration(configuration)
                .UseEnvironment("Development")
                .ConfigureServices(InitializeServices)
                .UseStartup(typeof(Startup));

            server = new TestServer(webHostBuilder)
            {
                BaseAddress = new Uri("http://localhost:5000")
            };
        }

        [AssemblyCleanup()]
        public static void AssemblyCleanup()
        {
            Client.Dispose();
            Server.Dispose();
        }

        public static string FindProjectPath(Assembly startupAssembly)
        {
            var projectName = startupAssembly.GetName().Name;
            var applicationBasePath = AppContext.BaseDirectory;
            var directoryInfo = new DirectoryInfo(applicationBasePath);
            if (directoryInfo != null)
            {
                do
                {
                    directoryInfo = directoryInfo.Parent;
                    if (directoryInfo == null) break;

                    if (projectName != null)
                    {
                        var projectDirectoryInfo = new DirectoryInfo(Path.Combine(directoryInfo.FullName, ""));

                        if (projectDirectoryInfo.Exists)
                            if (new FileInfo(Path.Combine(projectDirectoryInfo.FullName, projectName, $"{projectName}.csproj")).Exists)
                                return Path.Combine(projectDirectoryInfo.FullName, projectName);
                    }
                }
                while (directoryInfo.Parent != null);
            }

            throw new Exception($"Project root could not be located using the application root {applicationBasePath}.");
        }

        public static void InitializeServices(IServiceCollection services)
        {
            var startupAssembly = typeof(Startup).GetTypeInfo().Assembly;

            var manager = new ApplicationPartManager
            {
                ApplicationParts =
                {
                    new AssemblyPart(startupAssembly)
                },
                FeatureProviders =
                {
                    new ControllerFeatureProvider(),
                    new ViewComponentFeatureProvider()
                }
            };

            services.AddLogging();

            services.AddSingleton(manager);

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connection));

            services.AddAuthentication("Test")
                    .AddScheme<AuthenticationSchemeOptions, TestAuthHandler>(
                        "Test", options => { });
        }
    }
}