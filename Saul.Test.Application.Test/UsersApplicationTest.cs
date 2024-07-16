using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Saul.Test.Application.Interface;
using Saul.Test.Services.WebAPI;
using System.IO;

namespace Saul.Test.Application.Test
{
    [TestClass]
    public class UsersApplicationTest
    {
        private static IConfiguration _configuration;
        private static IServiceScopeFactory _scopeFactory;

        [ClassInitialize]
        public static void Initialize(TestContext _)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                .AddEnvironmentVariables();
            _configuration = builder.Build();

            var startup = new Startup(_configuration);
            var services = new ServiceCollection();
            startup.ConfigureServices(services);
            _scopeFactory = services.BuildServiceProvider().GetService<IServiceScopeFactory>();

        }

        [TestMethod]
        public void Authenticate_WhenParamsAreNull_ReturnErrorValidation()
        {
            using var scope = _scopeFactory.CreateScope();
            var context = scope.ServiceProvider.GetService<IUsersApplication>();

            var userName = string.Empty;
            var password = string.Empty;
            var expected = "Validation Error";

            var result = context.Authenticate(userName, password);
            var current = result.Message;

            Assert.AreEqual(expected, current);
        }

        [TestMethod]
        public void Authenticate_WhenParamsAreRight_ReturnSuccess()
        {
            using var scope = _scopeFactory.CreateScope();
            var context = scope.ServiceProvider.GetService<IUsersApplication>();

            var userName = "User1";
            var password = "123456";
            var expected = "Successful Authentication";

            var result = context.Authenticate(userName, password);
            var current = result.Message;

            Assert.AreEqual(expected, current);
        }

        [TestMethod]
        public void Authenticate_WhenParamsAreWrong_ReturnUserDoesntExist()
        {
            using var scope = _scopeFactory.CreateScope();
            var context = scope.ServiceProvider.GetService<IUsersApplication>();

            var userName = "User1";
            var password = "123123";
            var expected = "User doesn't exist";

            var result = context.Authenticate(userName, password);
            var current = result.Message;

            Assert.AreEqual(expected, current);
        }
    }
}
