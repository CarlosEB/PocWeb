using Poc.App.Dto.Output;
using Poc.Domain.Entities;
using System.Linq;
using System.Collections.Generic;

namespace Poc.App.Dto.Maps
{
    public static class UserMap
    {
        public static IEnumerable<UserOutput> ToOutput(this IEnumerable<User> users)
        {
            return users.Select(u => new UserOutput { Id = u.Id, Address = u.Address, Name = u.Name }).ToList();
        }
    }
}
