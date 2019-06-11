using GenAPI.DAO.Repository.Abstract;
using GenAPI.Domain.Entities;
using GenAPI.DomainServices.Abstract;
using System;
using System.Collections.Generic;
namespace GenAPI.Services.Concrete
{
    public class MecServiceService: IMecServiceService
    {
        private IMecServiceRepository mecServiceRepository;
        public MecServiceService(IMecServiceRepository _repo) {
            this.mecServiceRepository = _repo;
        }
        
        public bool Create(ref MecService mecService)
        {
            mecService.CreationDate = DateTime.Now;
            this.mecServiceRepository.Insert(ref mecService);
            return this.mecServiceRepository.Save();
        }
        
        public IEnumerable<MecService> GetMecServices(string name = "")
         => this.mecServiceRepository.Query(x=> (x.Name == name || name == ""));
             

        public bool DeleteMecService(int idMecService)
        {
            this.mecServiceRepository.Delete(idMecService);
            return this.mecServiceRepository.Save();
        }
    }
}
