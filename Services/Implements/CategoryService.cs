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

        public override void Delete(object id)
        {
            UnitOfWork.Begin();
            UnitOfWork.CategoryRepository.Delete(id);
            UnitOfWork.Save();
            UnitOfWork.Commit();
        }

        public override IEnumerable<Category> GetAll() => UnitOfWork.CategoryRepository.GetAll();

        public override Category GetById(object id) => UnitOfWork.CategoryRepository.GetById(id);

        public override void Insert(Category entity)
        {
            UnitOfWork.Begin();
            UnitOfWork.CategoryRepository.Insert(entity);
            UnitOfWork.Save();
            UnitOfWork.Commit();
        }

        public override void Update(Category entity)
        {
            UnitOfWork.Begin();
            UnitOfWork.CategoryRepository.Update(entity);
            UnitOfWork.Save();
            UnitOfWork.Commit();
        }
    }
}