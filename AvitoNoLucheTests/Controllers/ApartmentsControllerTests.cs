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
    public class ApartmentsControllerTests : ControllerBase
    {
        private user05_3Context _context = new user05_3Context();
        public List<Apartment> apps { get; set; }
        public Apartment app { get; set; } = new Apartment
        {
            Id = 8,
            IdUser = 3,
            Cost = 1,
            Adress = "1",
            CeilingHeight = "1",
            Discription = "1",
            Square = 1,
            Technique = "1",
            Furniture = "1",
            Floor = 1,
            Rooms = 1,
            IdBalconyType = 2,
            IdBathroomtype = 1,
            Photo = "1",
            Idhouse = 7,
            IdTransactionType = 1,
            IdTypeWindows = 1,
            IdRepair = 1
        };

        [TestMethod]
        public async Task GetApartmentsPost_ReturnsListOfApartments()
        {
            // Arrange           
            var controller = new ApartmentsController(_context);
            var apartments = new List<Apartment>();
            apartments = _context.Apartments.ToList();
            // Act
            var result = await controller.GetApartmentsPost();
            // Assert
            Assert.IsInstanceOfType(result.Value, typeof(IEnumerable<Apartment>));
            Assert.AreEqual(apartments.Count, result.Value.Count());
        }

        [TestMethod()]
        public async Task GetApartmentPostTest()
        {
            //настройка             
            var controller = new ApartmentsController(_context);
            var apartment = await _context.Apartments.FirstOrDefaultAsync(s => s.Id == 1);
            //выполнение   
            var result = await controller.GetApartment(1);
            //проверка
            Assert.IsInstanceOfType(result.Value, typeof(Apartment));
            Assert.AreEqual(apartment.Id, result.Value.Id);
        }
        
        [TestMethod()]
        public async Task PutApartmentPostTest()
        {
            //настройка                  
            var controller = new ApartmentsController(_context);
            var apartment = await _context.Apartments.FirstOrDefaultAsync(s => s.Id == 1);
            //выполнение
            var result = await controller.PutApartment(apartment);
            //проверка
            Assert.IsInstanceOfType(result, typeof(NoContentResult));
        }
        [TestMethod()]
        public async Task PostApartmentPostTest()
        {
            //настройка             
            var controller = new ApartmentsController(_context);
            List<Apartment> apartments;
                        //выполнение 
           apartments = _context.Apartments.ToList();
            var count = apartments.Count;
            var result = await controller.PostApartment(app);
            var resList = _context.Apartments.ToList();
            var resCount = resList.Count;
            //проверка
            Assert.AreNotEqual(resCount, count);
        }

        [TestMethod()]
        public async Task DeleteApartmentPostTest()
        {
            //настройка             
            var controller = new ApartmentsController(_context);           
            //выполнение            
            var result = await controller.DeleteApartment(app.Id);
            //проверка
            Assert.IsInstanceOfType(result, typeof(NoContentResult));
        }
    }
}