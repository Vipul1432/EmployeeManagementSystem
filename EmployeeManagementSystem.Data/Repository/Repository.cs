using EmployeeManagementSystem.Data.Context;
using EmployeeManagementSystem.Domain.Interfaces;
using EmployeeManagementSystem.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly EmployeeDbContext _context;

        public Repository(EmployeeDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retrieves all entities of type T from the repository.
        /// </summary>
        /// <returns>A task representing the asynchronous operation with a collection of entities.</returns>
        public async Task<IEnumerable<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        /// <summary>
        /// Retrieves an entity of type T by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the entity to retrieve.</param>
        /// <returns>A task representing the asynchronous operation with the retrieved entity.</returns>
        public async Task<T> GetById(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        /// <summary>
        /// Adds a new entity of type T to the repository.
        /// </summary>
        /// <param name="entity">The entity of type T to be added.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task Add(T entity)
        {
            _context.Set<T>().Add(entity);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Updates an existing entity of type T in the repository.
        /// </summary>
        /// <param name="entity">The entity of type T with updated data.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Deletes an entity of type T from the repository by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the entity to delete.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task Delete(int id)
        {
            var entity = await GetById(id);
            if (entity != null)
            {
                _context.Set<T>().Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
