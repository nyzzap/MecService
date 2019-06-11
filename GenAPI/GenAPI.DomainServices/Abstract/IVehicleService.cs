using GenAPI.Domain.Entities;
using System;
using System.Collections.Generic;
namespace GenAPI.DomainServices.Abstract
{
    public interface IVehicleService
    {
        bool Create(ref Vehicle Vehicle);
        IEnumerable<Vehicle> GetVehicles(string clientCode = "");
        bool DeleteVehicle(Guid idVehicle);
    }
}
