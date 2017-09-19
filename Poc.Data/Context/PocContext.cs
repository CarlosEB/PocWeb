using System.Data.Entity;
using Poc.Domain.Entities;

namespace Poc.Data.Context
{
    public class PocContext : DbContext
    {
        public PocContext(string conn) : base(conn) { }        

        public IDbSet<User> Users { get; set; }
         
    }
}
