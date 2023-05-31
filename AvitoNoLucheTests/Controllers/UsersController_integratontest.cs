using Microsoft.VisualStudio.TestTools.UnitTesting;
using AvitoNoLuche.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvitoNoLuche.Models;
using AvitoNoLuche;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Text.Json;

namespace AvitoNoLucheTests.Controllers
{
    [TestClass()]
    public class UsersController_integratontest
    {
        private user05_3Context _context = new user05_3Context();
        public User user { get; set; } = new User { Password = "123", Number = "222" };
        public Auth auth { get; set; } = new Auth { Login = "777", Password = "777" };
        [TestInitialize]
        public void Initialize()
        {
            _factory = new WebApplicationFactory<Program>();
            client = _factory.CreateClient();
        }
        static JsonSerializerOptions options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve
        };
        private WebApplicationFactory<Program> _factory;
        private HttpClient client;

        [TestMethod()]
        public async Task AuthUserTest_IntTest()
        {
            // Act
            var response = await client.PostAsync("/api/Users/Auth", new StringContent(JsonSerializer.Serialize(auth, options),
                Encoding.UTF8, "application/json"));
            var responseContent = await response.Content.ReadAsStringAsync();
            var returnedUser = JsonSerializer.Deserialize<User>(responseContent);
            // Assert                    
            Assert.IsInstanceOfType(user, returnedUser.GetType());
        }

        [TestMethod()]
        public async Task PostUserSignUpTest_IntTest()
        {
            // Act
            var response = await client.PostAsync("/api/Users/SignUp", new StringContent(JsonSerializer.Serialize(user, options),
                Encoding.UTF8, "application/json"));
            var responseContent = await response.Content.ReadAsStringAsync();
            var returnedUser = JsonSerializer.Deserialize<User>(responseContent);
            // Assert                    
            Assert.IsInstanceOfType(user, returnedUser.GetType());
        }
    }
}
