using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interface
{
    public interface IWallet : IGenericRepository<Wallet>
    {
        Task<Wallet> GetByUserIdAsync(string id);
        Task<Wallet> GetByPhoneAsync(string Phone);

    }
}
