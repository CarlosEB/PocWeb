using Poc.App.Dto.Maps;
using Poc.App.Dto.Output;
using Poc.App.Interfaces;
using Poc.Data.Repositories;
using Poc.Domain.Entities;
using Poc.Domain.Interfaces;
using System.Collections.Generic;

namespace Poc.App
{
    public class UserApp : IUserApp
    {
        private readonly IUserRepository _userRepo;
        private readonly IUnitOfWork _uow;

        public UserApp(IUserRepository userRepo, IUnitOfWork uow)
        {
            _userRepo = userRepo;
            _uow = uow;
        }

        public void Create(User user)
        {
            _userRepo.Create(user);
            _uow.Commit();
        }

        public IEnumerable<UserOutput> GetUsers()
        {
            return _userRepo.GetAll().ToOutput();
        }

    }
}
