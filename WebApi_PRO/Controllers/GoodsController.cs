using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi_BL;
using WebApi_BL.GoodsService;
using WebApi_DAL.Entities;

namespace WebApi_PRO.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GoodsController : ControllerBase
    {
        private readonly IGoodsService _goodsService;

        public GoodsController(IGoodsService goodsService)
        {
            _goodsService = goodsService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var goods = await _goodsService.GetAll();

            return Ok(goods);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var good = await _goodsService.GetById(id);

            return good != null ? Ok(good) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Good item)
        {
            var good = await _goodsService.Create(item);

            return Ok(good);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateById (Guid id, Good item)
        {
            var good = await _goodsService.UpdateById(id, item);

            return good != null ? Ok(good) : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById(Guid id)
        {
            try
            {
                var good = await _goodsService.DeleteById(id);

                return good == null ? Ok() : NotFound();
            }
            catch (KeyNotFoundException)
            {
                return BadRequest("Entity not found in DB");
            }
        }
    }
}
