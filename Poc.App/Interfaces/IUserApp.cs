using Poc.App.Dto.Output;
using Poc.Domain.Entities;
using System.Collections.Generic;

namespace Poc.App.Interfaces
{
    public interface IUserApp
    {
        IEnumerable<UserOutput> GetUsers();

        void Create(User user);

    }
}
