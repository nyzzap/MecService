using GenAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using GenAPI.DataLayer.Abstract;
using GenAPI.DataLayer;
using GenAPI.DAO.Repository.Abstract;
using System;

namespace GenAPI.DAO.Repository.Concrete
{

    public class MecServiceRepository : BaseRepository<MecService, int>, IMecServiceRepository
    {
        private readonly DbSet<MecService> _dbSet;
        public MecServiceRepository(IGenUoW unitOfWork) : base(unitOfWork)
        {
            _dbSet = unitOfWork.DatabaseContext.Set<MecService>();
        }
    }
}