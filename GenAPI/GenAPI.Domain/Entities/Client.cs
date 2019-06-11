using System;
using System.Collections.Generic;

namespace GenAPI.Domain.Entities
{
    public class Client : BaseEntity<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Code { get; set; }
        public virtual IEnumerable<Vehicle> Vehicles { get; set; }
    }
}
