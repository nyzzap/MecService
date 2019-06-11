using System;
using System.Collections.Generic;

namespace GenAPI.Domain.Entities
{
    public class VehicleOrderService : BaseEntity<Guid>
    {
        public DateTime CompletionDate { get; set; }
        public decimal TotalPrice { get; set; }

        public virtual IEnumerable<MecService> MecServices { get; set; }
        public virtual Vehicle Vehicle { get; set; }
    }
}