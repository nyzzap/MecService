using GenAPI.DataLayer;
using GenAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
namespace GenAPI.DomainServices.Abstract
{
    public interface IVehicleOrderServiceService
    {
        bool Create(ref VehicleOrderService vehicleOrderService);
        IEnumerable<VehicleOrderService> GetVehicleOrderServices(string clientCode = "");
        bool DeleteVehicleOrderService(Guid idVehicleOrderService);
        bool CompleteOrderService(Guid idVehicleOrderService);
    }
}