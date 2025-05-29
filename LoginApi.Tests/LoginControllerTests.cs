using Xunit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LoginApi.Controllers;
using LoginApi.Data;
using LoginApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace LoginApi.Tests
{
    public class LoginControllerTests
    {
        private AppDbContext GetContextWithData()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDb")
                .Options;

            var context = new AppDbContext(options);

            context.Logins.AddRange(new List<Login>
            {
                new Login { Id = 1, Email = "test1@example.com", Password = "pass", IsLoggedIn = false },
                new Login { Id = 2, Email = "test2@example.com", Password = "pass", IsLoggedIn = true }
            });
            context.SaveChanges();

            return context;
        }

        [Fact]
        public void GetAll_ReturnsAllLogins()
        {
            var context = GetContextWithData();
            var controller = new LoginController(context);

            var result = controller.GetAll() as OkObjectResult;
            var logins = result?.Value as List<Login>;

            Assert.NotNull(logins);
            Assert.Equal(2, logins.Count);
        }

        [Fact]
        public void Login_ValidCredentials_LogsInUser()
        {
            var context = GetContextWithData();
            var controller = new LoginController(context);

            var result = controller.Login(new Login { Email = "test1@example.com", Password = "pass" });

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void Login_AlreadyLoggedIn_ReturnsBadRequest()
        {
            var context = GetContextWithData();
            var controller = new LoginController(context);

            var result = controller.Login(new Login { Email = "test2@example.com", Password = "pass" });

            Assert.IsType<BadRequestObjectResult>(result);
        }
    }
}
