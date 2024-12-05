using Repositories.Entities;
using Repositories.UnitOfWork;
using Services.Interfaces;
using Services;

namespace Services.Implements
{
    public class CategoryService : GenericService<Category>, ICategoryService
    {
        public CategoryService(IUnitOfWork<TheCoffeeStoreContext> unitOfWork) : base(unitOfWork)
        {
        }

        public override Category Delete(object id)
        {
            UnitOfWork.Begin();
            Category entity = UnitOfWork.CategoryRepository.Delete(id);
            UnitOfWork.Save();
            UnitOfWork.Commit();
            UnitOfWork.Dispose();
            return entity;
        }

        public override IEnumerable<Category> GetAll() => UnitOfWork.CategoryRepository.GetAll();

        public override Category GetById(object id) => UnitOfWork.CategoryRepository.GetById(id);

        public override Category Insert(Category entity)
        {
            UnitOfWork.Begin();
            Category ct = UnitOfWork.CategoryRepository.Insert(entity);
            UnitOfWork.Save();
            UnitOfWork.Commit();
            UnitOfWork.Dispose();
            return ct;
        }

        public override Category Update(Category entity)
        {
            UnitOfWork.Begin();
            Category ct = UnitOfWork.CategoryRepository.Update(entity);
            UnitOfWork.Save();
            UnitOfWork.Commit();
            UnitOfWork.Dispose();
            return ct;
        }
    }
}