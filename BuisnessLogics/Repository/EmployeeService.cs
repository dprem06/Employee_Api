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
        public void DeleteEmployee(int id)
        {
            var result = context.Employee.FirstOrDefault(e => e.Id == id);
            if (result != null)
            {
                context.Employee.Remove(result);
                context.SaveChangesAsync();
            }

        }

        /// <summary>
        /// Delete Employee
        /// </summary>
        /// <returns>Deleted status</returns>
        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await context.Employee.ToListAsync();
        }

        public async Task<Employee> GetEmployeeById(int id)
        {
            return await context.Employee.FirstOrDefaultAsync(e => e.Id == id);
        }
    }
}
