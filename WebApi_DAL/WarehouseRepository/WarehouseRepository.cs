using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApi_DAL.Entities;

namespace WebApi_DAL.WarehouseRepository
{
    public class WarehouseRepository : IWarehouseRepository
    {
        private readonly GWContext _dbContext;

        public WarehouseRepository(GWContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Warehouse> Create(Warehouse warehouse)
        {
            _dbContext.Add(warehouse);
            await _dbContext.SaveChangesAsync();

            return warehouse;
        }

        public async Task<Warehouse> DeleteById(Guid id)
        {
            var warehouse = await _dbContext.Warehouses.FindAsync(id);

            if (warehouse == null)
            {
                throw new KeyNotFoundException();
            }

            _dbContext.Warehouses.Remove(warehouse);
            await _dbContext.SaveChangesAsync();

            return null;
        }

        public async Task<IEnumerable<Warehouse>> GetAll()
        {
            return await _dbContext.Warehouses.ToListAsync();
        }

        public Task<Warehouse> GetById(Guid id)
        {
            return _dbContext.Warehouses.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Warehouse> UpdateById(Guid id, Warehouse warehouse)
        {
            warehouse.Id = id;
            _dbContext.Entry(warehouse).State = EntityState.Modified;

            await _dbContext.SaveChangesAsync();

            return warehouse;
        }
    }
}

