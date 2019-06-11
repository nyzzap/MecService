using System;

namespace GenAPI.Domain.Entities
{
    public class MecService : BaseEntity<int>
    {        
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
