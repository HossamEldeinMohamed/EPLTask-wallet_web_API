using DataAccessLayer.Data;
using Repositories.Interface;
using Repositories.Repositories;
using RepositoryLayer.Interface;
using UnitOfWorkLayer.Interface;

namespace UnitOfWorkLayer.Service
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Wallet = new WalletRepository(_context);
            Log = new LogRepository(_context);
        }

        public IWallet Wallet { get; private set; }
        public ILog Log { get; private set; }
        
        public void Dispose()
        {
            _context.Dispose();
        }
        public void Save()
        {
            try
            {
                _context.SaveChanges();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
