using Poc.Data.Context;

namespace Poc.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PocContext _bd;
        public UnitOfWork(PocContext bd)
        {
            _bd = bd;
        }

        public void Commit()
        {
            _bd.SaveChanges();
        }
    }
}
