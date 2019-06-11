using System;

namespace GenAPI.Domain.Entities
{
    public class Vehicle : BaseEntity<Guid>
    {        
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Patent { get; set; }
        public short Year { get; set; }
        public virtual Client Client { get; set; }
    }
}
