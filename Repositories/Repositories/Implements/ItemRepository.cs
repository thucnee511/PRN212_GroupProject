using Repositories.Entities;
using Repositories.Enums;
using Repositories.Repositories.Interfaces;
using Repositories.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repositories.Implements
{
    public class ItemRepository : GenericRepository<Item>, IItemRepository
    {
        public ItemRepository(IUnitOfWork<TheCoffeeStoreContext> unitOfWork) : base(unitOfWork)
        {
        }

        public override void Delete(object id)
        {
            Item entity = GetById(id);
            ArgumentNullException.ThrowIfNull(entity);
            entity.Status = ItemStatus.DELETED;
            Update(entity);
        }

        public override void Insert(Item entity)
        {
            ArgumentNullException.ThrowIfNull(entity);
            Guid guid = Guid.NewGuid();
            entity.Id = guid.ToString();
            Entities.Add(entity);
        }

        public override void Update(Item entity)
        {
            ArgumentNullException.ThrowIfNull(entity);
            entity.UpdatedAt = DateTime.UtcNow;
            Entities.Update(entity);
        }
    }
}
