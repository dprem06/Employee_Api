using BuisnessLogics.Repository;
using DataLayer.Models;
using Employee_Api.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace MsUnitTest
{
    [TestClass]
    public class EmployeeTest
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeTest(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [TestMethod]
        public void TestGetAllEmployees()
        {
            // Arrange
            var controller = new EmployeeController(_employeeService);
            
            // Act
            var response = controller.Get(10);

            var okResult = response as OkNegotiatedContentResult<Employee>;



            //Act

            //var mockEmps = new List<Employee>();
            //mockEmps.Add(new Employee
            //{ Id = 1, Name = "F1", City = "Trichy", State = "TN",Mobile = "994500338", IsActive = true });
            //mockEmps.Add(new Employee
            //{ Id = 2, Name = "F2", City = "Trichy", State = "TN", Mobile = "994500338", IsActive = true });

            //var employeeRepositoryMock = TestInitializer.MockEmployeeRepository;
            //employeeRepositoryMock.Setup
            //      (x => x.GetEmployees()).Returns(Task.FromResult(mockEmps));

            //var response = TestInitializer.TestHttpClient.GetAsync("api/Employees").Result;

            //var resp = response.Content.ReadAsStringAsync().Result;
            //var responseData = JsonConvert.DeserializeObject<List<Employee>>(resp);
            //Assert.AreEqual(3, responseData.Count);
            //Assert.AreEqual(mockEmps[0].EmpId, responseData[0].EmpId);
        }
    }
}
