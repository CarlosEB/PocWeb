using Poc.Domain.Base;

namespace Poc.Domain.Entities
{
    public class User : Entity
    {
        public string Name { get; set; }
        public string Address { get; set; }
    }
}
