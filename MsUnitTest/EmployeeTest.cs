using DataLayer.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MsUnitTest
{
    [TestClass]
    public class EmployeeTest
    {
        [TestMethod]
        public void TestGetAllEmployees()
        {
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
