using GenAPI.DAO.Repository.Abstract;
using GenAPI.DataLayer.Abstract;
using GenAPI.Domain.Entities;
using GenAPI.DomainServices.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GenAPI.Services.Concrete
{
    public class VehicleService: IVehicleService
    {
        private IVehicleRepository vehicleRepository;
        public VehicleService(IVehicleRepository _repo) {
            this.vehicleRepository = _repo;
        }
        
        public bool Create(ref Vehicle Vehicle)
        {
            Vehicle.ID = Guid.NewGuid();
            Vehicle.CreationDate = DateTime.Now;
            this.vehicleRepository.Insert(ref Vehicle);
            return this.vehicleRepository.Save();
        }
        
        public IEnumerable<Vehicle> GetVehicles(string clientCode = "")
        {
            return this.vehicleRepository.Query(x=> (x.Client.Code == clientCode || clientCode == ""));
        }

        public bool DeleteVehicle(Guid idVehicle)
        {
            this.vehicleRepository.Delete(idVehicle);
            return this.vehicleRepository.Save();
        }
    }
}
