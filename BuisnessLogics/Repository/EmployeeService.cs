using DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLogics.Repository
{
    public class EmployeeService : IEmployeeService
    {
        private readonly EmployeeContext context;

        public EmployeeService(EmployeeContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Get All Employees
        /// </summary>
        /// <returns>List of Employes</returns>
        public async Task<int> AddEmployee(Employee employee)
        {
            var result = await context.Employee.AddAsync(employee);
            await context.SaveChangesAsync();
            return (int)result.Entity.Id;
        }

        /// <summary>
        /// Add new employee
        /// </summary>
        /// <returns>New Employee id</returns>
        public async Task<int> DeleteEmployee(int id)
        {
            int result = 0;
            var employee = context.Employee.FirstOrDefault(e => e.Id == id);
            if (employee != null)
            {
                context.Employee.Remove(employee);
                result = await context.SaveChangesAsync();
                return result;
            }

            return result;
        }

        /// <summary>
        /// Delete Employee
        /// </summary>
        /// <returns>Deleted status</returns>
        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await context.Employee.ToListAsync();
        }

        /// <summary>
        /// Get Employee by Id
        /// </summary>
        /// <param name="id">Employee Id</param>
        /// <returns>Employee</returns>
        public async Task<Employee> GetEmployeeById(int id)
        {
            return await context.Employee.FirstOrDefaultAsync(e => e.Id == id);
        }
    }
}
