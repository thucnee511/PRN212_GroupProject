namespace Repositories.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        /// <summary>
        /// Retrieves all entities from the repository.
        /// </summary>
        /// <returns>
        /// An <see cref="IEnumerable{T}"/> containing all entities.
        /// </returns>
        IEnumerable<T> GetAll();
        /// <summary>
        /// Retrieves a single entity from the repository by its ID.
        /// </summary>
        /// <param name="id">
        /// The ID of the entity to retrieve.
        /// </param>
        /// <returns>
        /// The entity with the specified ID.
        /// </returns>
        T GetById(object id);
        /// <summary>
        /// Inserts a new entity into the repository.
        /// </summary>
        /// <param name="entity">
        /// The entity to insert.
        /// </param>
        void Insert(T entity);
        /// <summary>
        /// Updates an existing entity in the repository.
        /// </summary>
        /// <param name="entity">
        /// The entity to update.
        /// </param>
        void Update(T entity);
        /// <summary>
        /// Deletes an entity from the repository.
        /// </summary>
        /// <param name="id">
        /// The ID of the entity to delete.
        /// </param>
        void Delete(object id);
    }
}