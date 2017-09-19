using Poc.Data.Context;
using Poc.Domain.Entities;
using Poc.Domain.Interfaces;

namespace Poc.Data.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(PocContext bd) : base(bd)
        {
        }
    }
}