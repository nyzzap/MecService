using GenAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using GenAPI.DataLayer.Abstract;
using GenAPI.DataLayer;
using GenAPI.DAO.Repository.Abstract;
using System;

namespace GenAPI.DAO.Repository.Concrete
{

    public class VehicleOrderServiceRepository : BaseRepository<VehicleOrderService, Guid>, IVehicleOrderServiceRepository
    {
        private readonly DbSet<VehicleOrderService> _dbSet;
        public VehicleOrderServiceRepository(IGenUoW unitOfWork) : base(unitOfWork)
        {
            _dbSet = unitOfWork.DatabaseContext.Set<VehicleOrderService>();
        }
    }
}