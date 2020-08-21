using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuisnessLogics.Repository;
using DataLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Employee_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }


        // GET: api/<EmployeeController>
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult> Get()
        {
            try
            {
                var employees = await _employeeService.GetEmployees();
                if (employees == null)
                {
                    return NotFound();
                }

                return Ok(employees);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        // GET: api/<EmployeeController>/1
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult> Get(int? id)
        {
            if (id == null)
            {
                return BadRequest();

            }

            try
            {
                var employeeData = await _employeeService.GetEmployeeById((int)id);
                if (employeeData == null)
                {
                    return NotFound();
                }
                return Ok(employeeData);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Employee employee)
        {
            try
            {
                if (employee == null)
                    return BadRequest();

                return Ok(await _employeeService.AddEmployee(employee));
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }


        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int? id)
        {
            int result = 0;

            if (id == null)
            {
                return BadRequest();

            }

            try
            {
                result = await _employeeService.DeleteEmployee((int)id);
                if (result == 0)
                {
                    return NotFound();
                }

                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
