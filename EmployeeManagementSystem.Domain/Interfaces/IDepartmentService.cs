using EmployeeManagementSystem.Domain.Dtos;
using EmployeeManagementSystem.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Domain.Interfaces
{
    public interface IDepartmentService
    {
        /// <summary>
        /// Retrieves all departments from the repository.
        /// </summary>
        /// <returns>A task representing the asynchronous operation with a collection of department DTOs.</returns>
        Task<IEnumerable<DepartmentDto>> GetAllDepartmentsAsync();

        /// <summary>
        /// Retrieves a department by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the department to retrieve.</param>
        /// <returns>A task representing the asynchronous operation with the retrieved department DTO.</returns>
        Task<DepartmentDto> GetDepartmentByIdAsync(int id);

        /// <summary>
        /// Adds a new department to the repository.
        /// </summary>
        /// <param name="department">The department DTO to be added.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task AddDepartmentAsync(DepartmentDto department);

        /// <summary>
        /// Updates the name of an existing department in the repository.
        /// </summary>
        /// <param name="id">The unique identifier of the department to update.</param>
        /// <param name="departmentName">The new name for the department.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task UpdateDepartmentAsync(int id, string departmentName);

        /// <summary>
        /// Deletes a department from the repository by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the department to delete.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task DeleteDepartmentAsync(int id);
    }
}
