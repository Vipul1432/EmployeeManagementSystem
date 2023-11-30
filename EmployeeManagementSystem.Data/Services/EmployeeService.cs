using AutoMapper;
using EmployeeManagementSystem.Domain.Dtos;
using EmployeeManagementSystem.Domain.Interfaces;
using EmployeeManagementSystem.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Data.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IRepository<Employee> _employeeRepository;
        private readonly IMapper _mapper;

        public EmployeeService(IRepository<Employee> employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Retrieves all employees from the repository.
        /// </summary>
        /// <returns>A task representing the asynchronous operation with a collection of employee DTOs.</returns>
        public async Task<IEnumerable<EmployeeDto>> GetAllEmployeesAsync()
        {
            var employees = await _employeeRepository.GetAll();
            return _mapper.Map<IEnumerable<EmployeeDto>>(employees);
        }

        /// <summary>
        /// Retrieves an employee by their unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the employee to retrieve.</param>
        /// <returns>A task representing the asynchronous operation with the retrieved employee DTO.</returns>
        public async Task<EmployeeDto> GetEmployeeByIdAsync(int id)
        {
            var employee = await _employeeRepository.GetById(id);
            return _mapper.Map<EmployeeDto>(employee);
        }

        /// <summary>
        /// Adds a new employee to the repository.
        /// </summary>
        /// <param name="employee">The employee DTO to be added.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task AddEmployeeAsync(EmployeeDto employeeDto)
        {
            var employee = _mapper.Map<Employee>(employeeDto);
            await _employeeRepository.Add(employee);
        }

        /// <summary>
        /// Updates an existing employee in the repository.
        /// </summary>
        /// <param name="id">The unique identifier of the employee to update.</param>
        /// <param name="employee">The updated employee DTO.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task UpdateEmployeeAsync(int id, EmployeeDto employeeDto)
        {
            var existingEmployee = await _employeeRepository.GetById(id);

            if (existingEmployee == null)
            {
                return;
            }

            // Use AutoMapper to map EmployeeDto properties to existingEmployee
            employeeDto.Id = id;
            var employee = _mapper.Map(employeeDto, existingEmployee);

            // Update the entity in the repository
            await _employeeRepository.Update(employee);
        }

        /// <summary>
        /// Deletes an employee from the repository by their unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the employee to delete.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task DeleteEmployeeAsync(int id)
        {
            await _employeeRepository.Delete(id);
        }
    }
}
