using BuisnessLogics.Repository;
using DataLayer.Models;
using Employee_Api;
using Employee_Api.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using System;
using System.Net;
using System.Net.Http;
using Xunit;

namespace EmployeeUnitTesting
{
    public class EmployeeTest
    {
        private readonly HttpClient _client;
        private IEmployeeService _empService;
        public static DbContextOptions<EmployeeContext> dbContextOptions { get; }
        public static string connectionString = "Server=BMHE1099149\\SQLEXPRESS;Database=Employee;Integrated Security=True";

        static EmployeeTest()
        {
            dbContextOptions = new DbContextOptionsBuilder<EmployeeContext>()
               .UseSqlServer(connectionString)
               .Options;
        }
        public EmployeeTest()
        {
            var context = new EmployeeContext(dbContextOptions);

            var appFactory = new WebApplicationFactory<Startup>();
            _client = appFactory.CreateClient();
            _empService = new EmployeeService(context);
        }
        
        #region Get By Id

        [Fact]
        public async void Task_GetEmployeeById_Return_OkResult()
        {
            //Arrange
            var controller = new EmployeeController(_empService);
            var postId = 2;

            //Act
            var data = await controller.Get(postId);

            //Assert
            Assert.IsType<OkObjectResult>(data);
        }

        [Fact]
        public async void Task_GetEmployeeById_Return_NotFoundResult()
        {
            //Arrange
            var controller = new EmployeeController(_empService);
            var postId = 3;

            //Act
            var data = await controller.Get(postId);

            //Assert
            Assert.IsType<NotFoundResult>(data);
        }

        [Fact]
        public async void Task_GetEmployeeById_Return_BadRequestResult()
        {
            //Arrange
            var controller = new EmployeeController(_empService);
            int? postId = null;

            //Act
            var data = await controller.Get((int)postId);

            //Assert
            Assert.IsType<BadRequestResult>(data);
        }

        #endregion

        #region Add New Employee

        [Fact]
        public async void Task_Add_ValidData_Return_OkResult()
        {
            //Arrange
            var controller = new EmployeeController(_empService);
            var employee = new Employee() { Name = "Test 3", City = "Trichy", State = "TN", Mobile = "9090909090" };

            //Act
            var data = await controller.Post(employee);

            //Assert
            Assert.IsType<OkObjectResult>(data);
        }

        [Fact]
        public async void Task_Add_InvalidData_Return_BadRequest()
        {
            //Arrange
            var controller = new EmployeeController(_empService);
            var employee = new Employee() { Name = "Test 3", City = "Trichy", State = "TN", Mobile = "90909090909090909090000000" };

            //Act            
            var data = await controller.Post(employee);

            //Assert
            Assert.IsType<BadRequestResult>(data);
        }

        [Fact]
        public async void Task_Add_ValidData_MatchResult()
        {
            //Arrange
            var controller = new EmployeeController(_empService);
            var employee = new Employee() { Name = "Test 3", City = "Test 3", State = "TN", Mobile = "9090909090" };

            //Act
            var data = await controller.Post(employee);

            //Assert
            Assert.IsType<OkObjectResult>(data);

            //var okResult = data.Should().BeOfType<OkObjectResult>().Subject;
            // var result = okResult.Value.Should().BeAssignableTo<PostViewModel>().Subject;

            Assert.Equal(3, data);
        }

        #endregion

        #region Delete Employee

        [Fact]
        public void Task_Delete_Post_Return_OkResult()
        {
            //Arrange
            var controller = new EmployeeController(_empService);
            var postId = 2;

            //Act
            var data =  controller.Delete(postId);

            //Assert
            Assert.IsType<OkResult>(data);
        }

        [Fact]
        public void Task_Delete_Post_Return_NotFoundResult()
        {
            //Arrange
            var controller = new EmployeeController(_empService);
            var postId = 5;

            //Act
            var data = controller.Delete(postId);

            //Assert
            Assert.IsType<NotFoundResult>(data);
        }

        [Fact]
        public void Task_Delete_Return_BadRequestResult()
        {
            //Arrange
            var controller = new EmployeeController(_empService);
            int? postId = null;

            //Act
            var data = controller.Delete((int)postId);

            //Assert
            Assert.IsType<BadRequestResult>(data);
        }

        #endregion

    }
}
