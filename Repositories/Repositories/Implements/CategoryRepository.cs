using Repositories.Entities;
using Repositories.Enums;
using Repositories.Repositories.Interfaces;
using Repositories.UnitOfWork;

namespace Repositories.Repositories.Implements
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(IUnitOfWork<TheCoffeeStoreContext> unitOfWork) : base(unitOfWork)
        {
        }

        public override void Delete(object id)
        {
            Category entity = GetById(id);
            ArgumentNullException.ThrowIfNull(entity);
            entity.Status = CategoryStatus.REMOVED;
            Update(entity);
        }

        public override void Insert(Category entity)
        {
            ArgumentNullException.ThrowIfNull(entity);
            Guid guid = Guid.NewGuid();
            entity.Id = guid.ToString();
            Entities.Add(entity);
        }

        public override void Update(Category entity)
        {
            ArgumentNullException.ThrowIfNull(entity);
            entity.UpdatedAt = DateTime.UtcNow;
            Entities.Update(entity);
        }
    }
}
