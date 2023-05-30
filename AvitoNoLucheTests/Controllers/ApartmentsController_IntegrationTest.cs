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
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Text.Json;
using AvitoNoLuche;

namespace AvitoNoLucheTests.Controllers
{
    [TestClass()]
    public class ApartmentsController_IntegrationTest
    {
        WebApplicationFactory<Program> _factory;
        HttpClient client;
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
        private user05_3Context _context = new user05_3Context();
        public Apartment app { get; set; } = new Apartment
        {
            Id = 99,
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
        public Apartment app1 { get; set; } = new Apartment
        {
            Id = 109,
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
        public Apartment? appp { get; set; }

        [TestMethod]
        public async Task GetApartmentsPost_IntTest()
        { 
            // Act
            var response = await client.PostAsync("/api/Apartments/get", null);
            response.EnsureSuccessStatusCode();
            // Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }
        [TestMethod]
        public async Task GetApartmentPost_IntTest()
        {
            // Arrange           
            var id = 7;
            var json = JsonSerializer.Serialize(id, id.GetType(), options);           
            // Act
            var response = await client.PostAsync("/api/Apartments/getone", new StringContent(json, Encoding.UTF8, "application/json"));
            response.EnsureSuccessStatusCode();
            // Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }
        [TestMethod()]
        public async Task PostApartmentPost_IntTest()
        {
            // Act
            var response = await client.PostAsync("/api/Apartments/postapp", new StringContent(JsonSerializer.Serialize(app1), 
                Encoding.UTF8, "application/json"));           
            var responseContent = await response.Content.ReadAsStringAsync();
            var returnedApartment = JsonSerializer.Deserialize<Apartment>(responseContent);
            // Assert                    
            Assert.IsInstanceOfType(app1, returnedApartment.GetType());
        }
        [TestMethod()]
        public async Task PutApartmentPost_IntTest()
        {
            // Arrange
            appp = _context.Apartments.FirstOrDefault();
            // Act
            var response = await client.PostAsync("/api/Apartments/PutApp", new StringContent(JsonSerializer.Serialize(appp),
                Encoding.UTF8, "application/json"));
            // Assert
            Assert.AreEqual(HttpStatusCode.NoContent, response.StatusCode);
        }
        [TestMethod()]
        public async Task DeleteApartmentsPost_IntTest()//интеграционный тест :))))
        {
            _context.Apartments.Add(app1);
            _context.SaveChanges();
            // Arrange
            var json = JsonSerializer.Serialize(app1.Id, app1.Id.GetType(), options);
            // Act
            var response = await client.PostAsync("/api/Apartments/delete", new StringContent(json, Encoding.UTF8, "application/json"));
            // Assert
            Assert.AreEqual(HttpStatusCode.NoContent, response.StatusCode);      
        }
    }
}
