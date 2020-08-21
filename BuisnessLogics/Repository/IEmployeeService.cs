using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLogics.Repository
{
    public interface IEmployeeService
    {
        /// <summary>
        /// Get All Employees
        /// </summary>
        /// <returns>List of Employes</returns>
        Task<IEnumerable<Employee>> GetEmployees();

        /// <summary>
        /// Get All Employees
        /// </summary>
        /// <returns>List of Employes</returns>
        Task<Employee> GetEmployeeById(int id);


        /// <summary>
        /// Add new employee
        /// </summary>
        /// <returns>New Employee id</returns>
        Task<int> AddEmployee(Employee employee);

        /// <summary>
        /// Delete Employee
        /// </summary>
        /// <returns>Deleted status</returns>
        Task<int> DeleteEmployee(int id);
    }
}
