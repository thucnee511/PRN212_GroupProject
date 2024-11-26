using Microsoft.EntityFrameworkCore;

namespace Repositories.UnitOfWork
{
    public interface IUnitOfWork<out TContext> where TContext : DbContext, new()
    {
        TContext Context { get; }
        void Begin();
        void Commit();
        void Rollback();
        void Save();
    }
}
