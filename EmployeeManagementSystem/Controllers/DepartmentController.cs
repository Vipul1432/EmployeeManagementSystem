using EmployeeManagementSystem.Domain.Dtos;
using EmployeeManagementSystem.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace EmployeeManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        /// <summary>
        /// Retrieves a list of all departments.
        /// </summary>
        /// <returns>A list of departments.</returns>
        /// <response code="200">Returns the list of departments.</response>
        /// <response code="500">If an error occurs while retrieving the departments.</response>
        [HttpGet]
        public async Task<IActionResult> GetAllDepartmentsAsync()
        {
            try
            {
                var departments = await _departmentService.GetAllDepartmentsAsync();
                return Ok(departments);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error retrieving departments: {ex.Message}");
            }
        }

        /// <summary>
        /// Retrieves a specific department by its ID.
        /// </summary>
        /// <param name="id">The ID of the department to retrieve.</param>
        /// <returns>The department with the specified ID.</returns>
        /// <response code="200">Returns the requested department.</response>
        /// <response code="404">If the department with the given ID is not found.</response>
        /// <response code="500">If an error occurs while retrieving the department.</response>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDepartmentByIdAsync(int id)
        {
            try
            {
                var department = await _departmentService.GetDepartmentByIdAsync(id);
                if (department == null)
                {
                    return NotFound($"Department with ID {id} not found.");
                }
                return Ok(department);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error retrieving department: {ex.Message}");
            }
        }

        /// <summary>
        /// Adds a new department.
        /// </summary>
        /// <param name="department">The data of the department to be added.</param>
        /// <returns>A success message if the department is added successfully.</returns>
        /// <response code="200">Returns a success message.</response>
        /// <response code="400">If the provided department data is invalid.</response>
        /// <response code="500">If an error occurs while adding the department.</response>
        [HttpPost]
        public async Task<IActionResult> AddDepartmentAsync([FromBody] DepartmentDto department)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                await _departmentService.AddDepartmentAsync(department);
                return Ok("Department added successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error adding department: {ex.Message}");
            }
        }

        /// <summary>
        /// Updates the name of a department by its ID.
        /// </summary>
        /// <param name="id">The ID of the department to update.</param>
        /// <param name="departmentName">The new name for the department.</param>
        /// <returns>A success message if the department is updated successfully.</returns>
        /// <response code="200">Returns a success message.</response>
        /// <response code="400">If the provided department data is invalid.</response>
        /// <response code="404">If the department with the given ID is not found.</response>
        /// <response code="500">If an error occurs while updating the department.</response>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDepartmentAsync(int id, [FromBody] string departmentName)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                await _departmentService.UpdateDepartmentAsync(id, departmentName);
                return Ok($"Department with ID {id} updated successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error updating department: {ex.Message}");
            }
        }

        /// <summary>
        /// Deletes a department by its ID.
        /// </summary>
        /// <param name="id">The ID of the department to delete.</param>
        /// <returns>A success message if the department is deleted successfully.</returns>
        /// <response code="200">Returns a success message.</response>
        /// <response code="404">If the department with the given ID is not found.</response>
        /// <response code="500">If an error occurs while deleting the department.</response>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartmentAsync(int id)
        {
            try
            {
                var existingDepartment = await _departmentService.GetDepartmentByIdAsync(id);
                if (existingDepartment == null)
                {
                    return NotFound($"Department with ID {id} not found.");
                }

                await _departmentService.DeleteDepartmentAsync(id);
                return Ok($"Department with ID {id} deleted successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error deleting department: {ex.Message}");
            }
        }
    }
}
