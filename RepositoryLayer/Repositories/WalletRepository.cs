
using DataAccessLayer.Data;
using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repositories
{
    public class WalletRepository : GenericRepository<Wallet>, IWallet
    {
        private readonly ApplicationDbContext _context;

        public WalletRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Wallet> GetByUserIdAsync(string id)
        {
            try
            {
                return await _context.Wallet.SingleOrDefaultAsync(x => x.UserId == id);

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public async Task<Wallet> GetByPhoneAsync(string Phone)
        {
            try
            {
                var user = await _context.Users.SingleOrDefaultAsync(x => x.PhoneNumber == Phone);
                return await _context.Wallet.SingleOrDefaultAsync( c=> c.UserId==user.Id);

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
