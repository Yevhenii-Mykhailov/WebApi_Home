using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi_DAL.Entities;
using WebApi_DAL.GoodsRepository;
using WebApi_DAL.WarehouseRepository;

namespace WebApi_BL.WarehouseService
{
    public class WarehouseService : IWarehouseService
    {
        private readonly IWarehouseRepository _warehouseRepository;

        public WarehouseService(IWarehouseRepository warehouseRepository)
        {
            _warehouseRepository = warehouseRepository;
        }

        public Task<Warehouse> Create(Warehouse warehouse)
        {
            return _warehouseRepository.Create(warehouse);
        }

        public Task<Warehouse> DeleteById(Guid id)
        {
            return _warehouseRepository.DeleteById(id);
        }

        public Task<IEnumerable<Warehouse>> GetAll()
        {
            return _warehouseRepository.GetAll();
        }

        public Task<Warehouse> GetById(Guid id)
        {
            return _warehouseRepository.GetById(id);
        }

        public Task<Warehouse> UpdateById(Guid id, Warehouse warehouse)
        {
            return _warehouseRepository.UpdateById(id, warehouse);
        }
    }
}

