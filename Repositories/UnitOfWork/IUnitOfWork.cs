﻿using Microsoft.EntityFrameworkCore;
using Repositories.Repositories.Interfaces;

namespace Repositories.UnitOfWork
{
    public interface IUnitOfWork<out TContext> : IDisposable where TContext : DbContext, new()
    {
        TContext Context { get; }
        IAccountRepository AccountRepository { get; }
        ICategoryRepository CategoryRepository { get; }
        IDutyRepository DutyRepository { get; }
        IEmployeeRepository EmployeeRepository { get; }
        IItemRepository ItemRepository { get; }
        IOrderRepository OrderRepository { get; }
        IOrderDetailRepository OrderDetailRepository { get; }
        IVoucherRepository VoucherRepository { get; }
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
