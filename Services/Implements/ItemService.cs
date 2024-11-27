using Repositories.Entities;
using Repositories.UnitOfWork;
using Services.Interfaces;

namespace Services.Implements
{
    public class ItemService : GenericService<Item>, IItemService
    {
        public ItemService(IUnitOfWork<TheCoffeeStoreContext> unitOfWork) : base(unitOfWork)
        {
        }

        public override void Delete(object id)
        {
            UnitOfWork.Begin();
            UnitOfWork.ItemRepository.Delete(id);
            UnitOfWork.Save();
            UnitOfWork.Commit();
            UnitOfWork.Dispose();
        }

        public override IEnumerable<Item> GetAll() => UnitOfWork.ItemRepository.GetAll();

        public override Item GetById(object id) => UnitOfWork.ItemRepository.GetById(id);

        public override void Insert(Item entity)
        {
            UnitOfWork.Begin();
            UnitOfWork.ItemRepository.Insert(entity);
            UnitOfWork.Save();
            UnitOfWork.Commit();
            UnitOfWork.Dispose();
        }

        public override void Update(Item entity)
        {
            UnitOfWork.Begin();
            UnitOfWork.ItemRepository.Update(entity);
            UnitOfWork.Save();
            UnitOfWork.Commit();
            UnitOfWork.Dispose();
        }
    }
}