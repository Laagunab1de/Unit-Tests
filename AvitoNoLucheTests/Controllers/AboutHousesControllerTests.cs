using Microsoft.VisualStudio.TestTools.UnitTesting;
using AvitoNoLuche.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvitoNoLuche.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace AvitoNoLuche.Controllers.Tests
{
    [TestClass()]
    public class AboutHousesControllerTests
    {
        private user05_3Context _context = new user05_3Context();
        private AboutHouse qwe { get; set; }
        private AboutHouse abHouse { get; set; } = new AboutHouse {
            YearOfConsruction = "123",         
            IdParking = 1,
            IdTypeHouse = 1,
            IdStatus = 1
        };

        [TestMethod()]
        public async Task GetAboutHouseTest()
        {
            //настройка             
            var controller = new AboutHousesController(_context);
            var abHouse = await _context.AboutHouses.FirstOrDefaultAsync(s => s.Id == 7);
            //выполнение   
            var result = await controller.GetAboutHouse(7);
            //проверка
            Assert.IsInstanceOfType(result, typeof(ActionResult<AboutHouse>));
            Assert.AreEqual(abHouse.Id, result.Value.Id);
        }

        [TestMethod()]
        public async Task PutAboutHouseTest()
        {
            //настройка                  
            var controller = new AboutHousesController(_context);
            var aboutHouses = await _context.AboutHouses.FirstOrDefaultAsync(s => s.Id == 7);
            //выполнение
            var result = await controller.PutAboutHouse(aboutHouses);
            //проверка
            Assert.IsInstanceOfType(result, typeof(NoContentResult));
        }

        [TestMethod()]
        public async Task PostAboutHouseTest()
        {
            //настройка             
            var controller = new AboutHousesController(_context);
            List<AboutHouse> aboutHouses;
            //выполнение 
            aboutHouses = _context.AboutHouses.ToList();
            var count = aboutHouses.Count;
            var result = await controller.PostAboutHouse(abHouse);
            var resList = _context.AboutHouses.ToList();
            var resCount = resList.Count;
            //проверка
            Assert.AreNotEqual(resCount, count);
            _context.AboutHouses.Remove(abHouse);
        }

        [TestMethod()]
        public async Task DeleteAboutHouseTest()
        {
            //настройка             
            var controller = new AboutHousesController(_context);
            _context.AboutHouses.Add(abHouse);
            //выполнение            
            var result = await controller.DeleteAboutHouse(abHouse.Id);
            //проверка
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }
    }
}