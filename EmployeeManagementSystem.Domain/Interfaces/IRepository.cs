using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Domain.Interfaces
{
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// Retrieves all entities of type T from the repository.
        /// </summary>
        /// <returns>A task representing the asynchronous operation with a collection of entities.</returns>
        Task<IEnumerable<T>> GetAll();

        /// <summary>
        /// Retrieves an entity of type T by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the entity to retrieve.</param>
        /// <returns>A task representing the asynchronous operation with the retrieved entity.</returns>
        Task<T> GetById(int id);

        /// <summary>
        /// Adds a new entity of type T to the repository.
        /// </summary>
        /// <param name="entity">The entity of type T to be added.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task Add(T entity);

        /// <summary>
        /// Updates an existing entity of type T in the repository.
        /// </summary>
        /// <param name="entity">The entity of type T with updated data.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task Update(T entity);

        /// <summary>
        /// Deletes an entity of type T from the repository by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the entity to delete.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task Delete(int id);
    }
}
