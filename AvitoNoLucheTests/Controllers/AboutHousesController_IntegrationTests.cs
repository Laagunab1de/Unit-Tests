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
using Newtonsoft.Json;

namespace AvitoNoLucheTests.Controllers
{
    [TestClass()]
    public class AboutHousesController_IntegrationTests
    {
        static JsonSerializerOptions options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve
        };
        private user05_3Context _context = new user05_3Context();
        private AboutHouse abHouse { get; set; } = new AboutHouse
        {
           
            YearOfConsruction = "123",
            IdParking = 1,
            IdTypeHouse = 1,
            IdStatus = 1
        };
        [TestMethod]
        public async Task GetAboutHousePost_IntTest()//интеграционный тест :))))
        {
            // Arrange
            var _factory = new WebApplicationFactory<Program>();
            var id = 7;
            var json = System.Text.Json.JsonSerializer.Serialize(id, id.GetType(), options);
            var client = _factory.CreateClient();
            // Act
            var response = await client.PostAsync("/api/AboutHouses/getone", new StringContent(json, Encoding.UTF8, "application/json"));
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var result = System.Text.Json.JsonSerializer.Deserialize<AboutHouse>(content, options);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }
        [TestMethod()]
        public async Task PostAboutHousestPost_IntTest()
        {
             AboutHouse abHouse1 = new AboutHouse
             {
                 Id = 7,
                 YearOfConsruction = "123",
                 IdParking = 1,
                 IdTypeHouse = 1,
                 IdStatus = 1
             };
            // Arrange  
            var _factory = new WebApplicationFactory<Program>();
            var client = _factory.CreateClient();
            var content = new StringContent(JsonConvert.SerializeObject(abHouse1), Encoding.UTF8, "application/json");

            // Act
            var response = await client.PostAsync("/api/AboutHouses/post", content);
            var responseContent = await response.Content.ReadAsStringAsync();
            var returnedabHouse = JsonConvert.DeserializeObject<AboutHouse>(responseContent);

            // Assert                    
            Assert.IsInstanceOfType(abHouse1, returnedabHouse.GetType());
            _factory.Dispose();
            client.Dispose();
        }      
        [TestMethod]
        public async Task PutAboutHousePost_IntTest()
        {
            // Arrange
            var body = abHouse;
            var _factory = new WebApplicationFactory<Program>();
            var client = _factory.CreateClient();
            var json = System.Text.Json.JsonSerializer.Serialize(body, body.GetType(), options);
            // Act
            var response = await client.PostAsync("/api/AboutHouses/put", new StringContent(json, Encoding.UTF8, "application/json"));        
            var content = await response.Content.ReadAsStringAsync();
            var result = System.Text.Json.JsonSerializer.Deserialize<object>(content, options);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(HttpStatusCode.NoContent, response.StatusCode);
        }
        [TestMethod]
        public async Task DeleteAboutHousePost_IntTest()//интеграционный тест :))))
        {
            _context.AboutHouses.Add(abHouse);
            _context.SaveChanges();
            // Arrange
            var _factory = new WebApplicationFactory<Program>();
            var client = _factory.CreateClient();
            var json = System.Text.Json.JsonSerializer.Serialize(abHouse.Id, abHouse.Id.GetType(), options);
            // Act
            var response = await client.PostAsync("/api/AboutHouses/delete", new StringContent(json, Encoding.UTF8, "application/json"));
            // Assert
            Assert.AreEqual(HttpStatusCode.NoContent, response.StatusCode);
        }
    }
}
