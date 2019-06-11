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
    public class VehicleOrderServiceService: IVehicleOrderServiceService
    {
        private IVehicleOrderServiceRepository vehicleOrderServiceRepository;
        public VehicleOrderServiceService(IVehicleOrderServiceRepository _repo) {
            this.vehicleOrderServiceRepository = _repo;
        }
        
        public bool Create(ref VehicleOrderService VehicleOrderService)
        {
            VehicleOrderService.ID = Guid.NewGuid();
            VehicleOrderService.CreationDate = DateTime.Now;
            VehicleOrderService.CompletionDate = new DateTime(2100, 01, 01);
            this.vehicleOrderServiceRepository.Insert(ref VehicleOrderService);
            return this.vehicleOrderServiceRepository.Save();
        }
        
        public IEnumerable<VehicleOrderService> GetVehicleOrderServices(string clientCode = "")
            => this.vehicleOrderServiceRepository.Query(x => (x.Vehicle.Client.Code == clientCode || clientCode == ""));
        
        public bool DeleteVehicleOrderService(Guid VehicleOrderService)
        {
            this.vehicleOrderServiceRepository.Delete(VehicleOrderService);
            return this.vehicleOrderServiceRepository.Save();
        }

        public bool CompleteOrderService(Guid idVehicleOrderService)
        {
            var item = this.vehicleOrderServiceRepository.GetByID(idVehicleOrderService);
            item.CompletionDate = DateTime.Now;
            return vehicleOrderServiceRepository.Save();
        }
    }
}
