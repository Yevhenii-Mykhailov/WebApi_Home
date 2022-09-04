using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi_DAL.Entities;

namespace WebApi_DAL.WarehouseRepository
{
    public interface IWarehouseRepository
    {
        Task<IEnumerable<Warehouse>> GetAll();
        Task<Warehouse> GetById(Guid id);
        Task<Warehouse> DeleteById(Guid id);
        Task<Warehouse> UpdateById(Guid id, Warehouse warehouse);
        Task<Warehouse> Create(Warehouse warehouse);
    }
}

