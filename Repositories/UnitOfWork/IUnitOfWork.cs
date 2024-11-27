using Microsoft.EntityFrameworkCore;

namespace Repositories.UnitOfWork
{
    public interface IUnitOfWork<out TContext> : IDisposable where TContext : DbContext, new()
    {
        /// <summary>
        /// Start a transaction 
        /// </summary>
        void Begin();
        /// <summary>
        /// Commit the transaction
        /// </summary>
        void Commit();
        /// <summary>
        /// Rollback the transaction
        /// </summary>
        void Rollback();
        /// <summary>
        /// Save the changes
        /// </summary>
        void Save();
    }
}
