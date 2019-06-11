using GenAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using GenAPI.DataLayer.Abstract;
using GenAPI.DataLayer;
using GenAPI.DAO.Repository.Abstract;
using System;

namespace GenAPI.DAO.Repository.Concrete
{

    public class VehicleRepository : BaseRepository<Vehicle, Guid>, IVehicleRepository
    {
        private readonly DbSet<User> _dbSet;
        public VehicleRepository(IGenUoW unitOfWork) : base(unitOfWork)
        {
            _dbSet = unitOfWork.DatabaseContext.Set<User>();
        }
    }
}