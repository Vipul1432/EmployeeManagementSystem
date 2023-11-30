using EmployeeManagementSystem.Domain.Dtos;
using EmployeeManagementSystem.Domain.Interfaces;
using EmployeeManagementSystem.Domain.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Data.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IRepository<Department> _departmentRepository;
        private readonly IMapper _mapper;

        public DepartmentService(IRepository<Department> departmentRepository, IMapper mapper)
        {
            _departmentRepository = departmentRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Retrieves all departments from the repository.
        /// </summary>
        /// <returns>A task representing the asynchronous operation with a collection of department DTOs.</returns>
        public async Task<IEnumerable<DepartmentDto>> GetAllDepartmentsAsync()
        {
            var departments = await _departmentRepository.GetAll();
            return _mapper.Map<IEnumerable<DepartmentDto>>(departments);
        }

        /// <summary>
        /// Retrieves a department by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the department to retrieve.</param>
        /// <returns>A task representing the asynchronous operation with the retrieved department DTO.</returns>
        public async Task<DepartmentDto> GetDepartmentByIdAsync(int id)
        {
            var department = await _departmentRepository.GetById(id);
            return _mapper.Map<DepartmentDto>(department);
        }

        /// <summary>
        /// Adds a new department to the repository.
        /// </summary>
        /// <param name="department">The department DTO to be added.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task AddDepartmentAsync(DepartmentDto department)
        {
            var departmentModel = _mapper.Map<Department>(department);
            await _departmentRepository.Add(departmentModel);
        }

        /// <summary>
        /// Updates the name of an existing department in the repository.
        /// </summary>
        /// <param name="id">The unique identifier of the department to update.</param>
        /// <param name="departmentName">The new name for the department.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task UpdateDepartmentAsync(int id, string departmentName)
        {
            var existingDepartment = await _departmentRepository.GetById(id);

            if (existingDepartment == null)
            {
                return;
            }

            existingDepartment.DepartmentName = departmentName;
            await _departmentRepository.Update(existingDepartment);
        }

        /// <summary>
        /// Deletes a department from the repository by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the department to delete.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task DeleteDepartmentAsync(int id)
        {
            await _departmentRepository.Delete(id);
        }
    }
}
