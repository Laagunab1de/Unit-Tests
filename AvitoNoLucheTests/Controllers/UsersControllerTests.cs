using Microsoft.VisualStudio.TestTools.UnitTesting;
using AvitoNoLuche.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvitoNoLuche.Models;

namespace AvitoNoLuche.Controllers.Tests
{
    [TestClass()]
    public class UsersControllerTests
    {
        private user05_3Context _context = new user05_3Context();
        public User user { get; set; } = new User { Password = "123", Number = "222" };
        public Auth auth { get; set; } = new Auth { Login = "777", Password = "777" };
        [TestMethod()]
        public async Task AuthUserTest()
        {
            var controller = new UsersController(_context);
            var result = await controller.AuthUser(auth);
            Assert.IsInstanceOfType(result, typeof(Microsoft.AspNetCore.Mvc.ActionResult<AvitoNoLuche.Models.User>));
        }

        [TestMethod()]
        public async Task PostUserSignUpTest()
        {
            var controller = new UsersController(_context);
            var result = await controller.PostUserSignUp(user);
            Assert.IsInstanceOfType(result, typeof(Microsoft.AspNetCore.Mvc.ActionResult<AvitoNoLuche.Models.User>));
            _context.Users.Remove(user);
        }
    }
}