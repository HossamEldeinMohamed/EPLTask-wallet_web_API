using Repositories;
using Repositories.Interface;
using RepositoryLayer.Interface;

namespace UnitOfWorkLayer.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        public IWallet Wallet { get; }
        public ILog Log { get; }
       

        public void Save();
    }
}
