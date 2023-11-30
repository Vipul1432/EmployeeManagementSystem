using EmployeeManagementSystem.Domain.Dtos;
using EmployeeManagementSystem.Domain.Interfaces;
using EmployeeManagementSystem.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace EmployeeManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        /// <summary>
        /// Retrieves a list of all employees.
        /// </summary>
        /// <returns>A list of employees.</returns>
        /// <response code="200">Returns the list of employees.</response>
        /// <response code="500">If an error occurs while retrieving the employees.</response>
        [HttpGet]
        public async Task<IActionResult> GetAllEmployeesAsync()
        {
            try
            {
                var employees = await _employeeService.GetAllEmployeesAsync();
                return Ok(employees);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
        }

        /// <summary>
        /// Retrieves a specific employee by their ID.
        /// </summary>
        /// <param name="id">The ID of the employee to retrieve.</param>
        /// <returns>The employee with the specified ID.</returns>
        /// <response code="200">Returns the requested employee.</response>
        /// <response code="404">If the employee with the given ID is not found.</response>
        /// <response code="500">If an error occurs while retrieving the employee.</response>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeByIdAsync(int id)
        {
            try
            {
                var employee = await _employeeService.GetEmployeeByIdAsync(id);
                if (employee == null)
                {
                    return NotFound($"Employee with ID {id} not found.");
                }
                return Ok(employee);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
        }

        /// <summary>
        /// Adds a new employee.
        /// </summary>
        /// <param name="employee">The data of the employee to be added.</param>
        /// <returns>A success message if the employee is added successfully.</returns>
        /// <response code="200">Returns a success message.</response>
        /// <response code="400">If the provided employee data is invalid.</response>
        /// <response code="500">If an error occurs while adding the employee.</response>
        [HttpPost]
        public async Task<IActionResult> AddEmployeeAsync([FromBody] EmployeeDto employee)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                await _employeeService.AddEmployeeAsync(employee);
                return Ok("Employee added successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
        }

        /// <summary>
        /// Updates the information of an employee by their ID.
        /// </summary>
        /// <param name="id">The ID of the employee to update.</param>
        /// <param name="employee">The new data for the employee.</param>
        /// <returns>A success message if the employee is updated successfully.</returns>
        /// <response code="200">Returns a success message.</response>
        /// <response code="400">If the provided employee data is invalid.</response>
        /// <response code="404">If the employee with the given ID is not found.</response>
        /// <response code="500">If an error occurs while updating the employee.</response>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployeeAsync(int id, [FromBody] EmployeeDto employee)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                await _employeeService.UpdateEmployeeAsync(id, employee);
                return Ok($"Employee with ID {id} updated successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
        }

        /// <summary>
        /// Deletes an employee by their ID.
        /// </summary>
        /// <param name="id">The ID of the employee to delete.</param>
        /// <returns>A success message if the employee is deleted successfully.</returns>
        /// <response code="200">Returns a success message.</response>
        /// <response code="404">If the employee with the given ID is not found.</response>
        /// <response code="500">If an error occurs while deleting the employee.</response>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployeeAsync(int id)
        {
            try
            {
                var existingEmployee = await _employeeService.GetEmployeeByIdAsync(id);
                if (existingEmployee == null)
                {
                    return NotFound($"Employee with ID {id} not found.");
                }

                await _employeeService.DeleteEmployeeAsync(id);
                return Ok($"Employee with ID {id} deleted successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
        }
    }
}
