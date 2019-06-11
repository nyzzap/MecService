using GenAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using GenAPI.DataLayer.Abstract;
using GenAPI.DataLayer;
using GenAPI.DAO.Repository.Abstract;
using System;

namespace GenAPI.DAO.Repository.Concrete
{

    public class ClientRepository : BaseRepository<Client, Guid>, IClientRepository
    {
        private readonly DbSet<Client> _dbSet;
        public ClientRepository(IGenUoW unitOfWork) : base(unitOfWork)
        {
            _dbSet = unitOfWork.DatabaseContext.Set<Client>();
        }
    }
}