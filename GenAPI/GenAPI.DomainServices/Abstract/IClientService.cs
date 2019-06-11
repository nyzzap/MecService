using GenAPI.DataLayer;
using GenAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GenAPI.DomainServices.Abstract
{
    public interface IClientService
    {
        bool Create(ref Client Client);
        IEnumerable<Client> GetClients(string lastName="", string firstName="");
        Client GetClientByCode(string code);
        bool DeleteClient(Guid idClient);
    }
}
