using GenAPI.DataLayer;
using GenAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GenAPI.DomainServices.Abstract
{
    public interface IMecServiceService
    {
        bool Create(ref MecService mecService);
        IEnumerable<MecService> GetMecServices(string name="");
        bool DeleteMecService(int idMecService);
    }
}
