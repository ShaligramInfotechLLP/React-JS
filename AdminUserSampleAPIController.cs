using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ApiProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Cors;

namespace ApiProject.Controllers
{
    [Route("api/[controller]")]
    //[DisableCors]
    [ApiController]
    public class AdminUserController : ControllerBase
    {
        

        private readonly ApiProjectContext _context;

        public AdminUserController(ApiProjectContext context)
        {
            _context = context;

            //if (_context.TodoItems.Count() == 0)
            //{
            //    // Create a new TodoItem if collection is empty,
            //    // which means you can't delete all TodoItems.
            //    _context.TodoItems.Add(new TodoItem { Name = "Item1" });
            //    _context.SaveChanges();
            //}
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Employee>> Get()
        {
            return _context.AdminUser;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Employee> Get(int id)
        {
            Employee employee = _context.AdminUser.Find(id);
            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }

        
        [HttpPost]
        public void Post([FromBody] Employee employee)
        {
            if (ModelState.IsValid)
            {
                _context.AdminUser.Add(employee);
                _context.SaveChanges();
            }
        }
        
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Employee employee)
        {
            if (ModelState.IsValid)
            {
                if (id == employee.Id)
                {
                    _context.Entry(employee).State = EntityState.Modified;
                }
            }
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                
            }    
        }
        
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Employee employee = _context.AdminUser.Find(id);
            if (employee != null)
            {
                _context.AdminUser.Remove(employee);
                _context.SaveChanges();
            }
        }

    }
}
