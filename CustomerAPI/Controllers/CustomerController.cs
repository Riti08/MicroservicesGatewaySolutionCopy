﻿using CustomerAPI.Data;
using CustomerAPI.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private IApplicationDbContext _context;
        public CustomerController(IApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok("Customer Gateway");
        }
        [HttpPost]
        public async Task<IActionResult> Create(Customer customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChanges();
            return Ok(customer);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _context.Customers.Where(a => a.Id == id).FirstOrDefaultAsync();
            if (product == null) return NotFound();
            return Ok(product);
        }
         [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var customer = await _context.Customers.Where(a => a.Id == id).FirstOrDefaultAsync();
            if (customer == null) return NotFound();
            _context.Customers.Remove(customer);
            await _context.SaveChanges();
            return Ok(customer.Id);
        }
 
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Customer customerData)
        {
            var customer = _context.Customers.Where(a => a.Id == id).FirstOrDefault();
            if (customer == null) return NotFound();
            else
            {
                customer.City = customerData.City;
                customer.Name = customerData.Name;
                customer.Contact = customerData.Contact;
                customer.Email= customerData.Email;
                await _context.SaveChanges();
                return Ok(customer.Id);
            }
        }
    }
}
