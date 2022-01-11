using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductAPI.Data;
using ProductAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IApplicationDbContext _context;

        public ProductController(IApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok("Product Gateway");
        }
        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChanges();
            return Ok(product);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _context.Products.Where(a => a.Id == id).FirstOrDefaultAsync();
            if (product == null) return NotFound();
            return Ok(product);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _context.Products.Where(a => a.Id == id).FirstOrDefaultAsync();
            if (product == null) return NotFound();
            _context.Products.Remove(product);
            await _context.SaveChanges();
            return Ok(product.Id);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Product productData)
        {
            var product = _context.Products.Where(a => a.Id == id).FirstOrDefault();
            if (product == null) return NotFound();
            else
            {
                product.Name = productData.Name;
                product.Rate = productData.Rate;
                await _context.SaveChanges();
                return Ok(product.Id);
            }
        }
    }
}
