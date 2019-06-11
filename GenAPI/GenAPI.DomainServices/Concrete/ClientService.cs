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
    public class ClientService: IClientService
    {
        private IClientRepository clientRepository;
        public ClientService(IClientRepository _repo) {
            this.clientRepository = _repo;
        }
        
        public bool Create(ref Client Client)
        {
            Client.ID = Guid.NewGuid();
            Client.CreationDate = DateTime.Now;
            Client.Code = Client.ID.ToString("N");
            this.clientRepository.Insert(ref Client);
            return this.clientRepository.Save();
        }
        
        public IEnumerable<Client> GetClients(string lastName = "", string firstName = "")
            => this.clientRepository.Query(x=> (x.FirstName == firstName || firstName == "")
                                            && (x.LastName == lastName || lastName == ""));
        
        public Client GetClientByCode(string code) 
            => this.clientRepository.Query(x => x.Code == code).FirstOrDefault();
       
        public bool DeleteClient(Guid idClient)
        {
            this.clientRepository.Delete(idClient);
            return this.clientRepository.Save();
        }
    }
}
