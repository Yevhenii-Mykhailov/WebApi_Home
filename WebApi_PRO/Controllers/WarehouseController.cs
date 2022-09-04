using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApi_BL.WarehouseService;
using WebApi_DAL.Entities;

namespace WebApi_PRO.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WarehouseController : ControllerBase
    {
        private readonly IWarehouseService _warehouseService;

        public WarehouseController(IWarehouseService warehouseService)
        {
            _warehouseService = warehouseService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var warehouses = await _warehouseService.GetAll();

            return Ok(warehouses);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var warehouse = await _warehouseService.GetById(id);

            return warehouse != null ? Ok(warehouse) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Warehouse item)
        {
            var warehouse = await _warehouseService.Create(item);

            return Ok(warehouse);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateById(Guid id, Warehouse item)
        {
            var warehouse = await _warehouseService.UpdateById(id, item);

            return warehouse != null ? Ok(warehouse) : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById(Guid id)
        {
            try
            {
                var warehouse = await _warehouseService.DeleteById(id);

                return warehouse == null ? Ok() : NotFound();
            }
            catch (KeyNotFoundException)
            {
                return BadRequest("Entity not found in DB");
            }
        }
    }
}

