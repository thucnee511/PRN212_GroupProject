using Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repositories.Interfaces
{
    public interface IAccountRepository : IGenericRepository<Account>, IDisposable
    {
        Account GetByUsername(string username);
    }
}
