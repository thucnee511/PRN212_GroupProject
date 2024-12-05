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

        public override Item Delete(object id)
        {
            UnitOfWork.Begin();
            Item entity = UnitOfWork.ItemRepository.Delete(id);
            UnitOfWork.Save();
            UnitOfWork.Commit();
            UnitOfWork.Dispose();
            return entity;
        }

        public override IEnumerable<Item> GetAll() => UnitOfWork.ItemRepository.GetAll();

        public override Item GetById(object id) => UnitOfWork.ItemRepository.GetById(id);

        public override Item Insert(Item entity)
        {
            UnitOfWork.Begin();
            Item itm = UnitOfWork.ItemRepository.Insert(entity);
            UnitOfWork.Save();
            UnitOfWork.Commit();
            UnitOfWork.Dispose();
            return itm;
        }

        public override Item Update(Item entity)
        {
            UnitOfWork.Begin();
            Item itm = UnitOfWork.ItemRepository.Update(entity);
            UnitOfWork.Save();
            UnitOfWork.Commit();
            UnitOfWork.Dispose();
            return itm;
        }
    }
}