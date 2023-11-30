using EmployeeManagementSystem.Domain.Dtos;
using EmployeeManagementSystem.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Domain.Interfaces
{
    public interface IEmployeeService
    {
        /// <summary>
        /// Retrieves all employees from the repository.
        /// </summary>
        /// <returns>A task representing the asynchronous operation with a collection of employee DTOs.</returns>
        Task<IEnumerable<EmployeeDto>> GetAllEmployeesAsync();

        /// <summary>
        /// Retrieves an employee by their unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the employee to retrieve.</param>
        /// <returns>A task representing the asynchronous operation with the retrieved employee DTO.</returns>
        Task<EmployeeDto> GetEmployeeByIdAsync(int id);

        /// <summary>
        /// Adds a new employee to the repository.
        /// </summary>
        /// <param name="employee">The employee DTO to be added.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task AddEmployeeAsync(EmployeeDto employee);

        /// <summary>
        /// Updates an existing employee in the repository.
        /// </summary>
        /// <param name="id">The unique identifier of the employee to update.</param>
        /// <param name="employee">The updated employee DTO.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task UpdateEmployeeAsync(int id, EmployeeDto employee);

        /// <summary>
        /// Deletes an employee from the repository by their unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the employee to delete.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task DeleteEmployeeAsync(int id);
    }
}
