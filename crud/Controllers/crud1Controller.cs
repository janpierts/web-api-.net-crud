using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using crud.Data;

namespace crud.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class crud1Controller : ControllerBase
    {
        private static List<crud1> test = new List<crud1>
        {
            new crud1 {
               Id = 0,
               Name = "Ruddy Janpierts",
               FirstName = "Correa",
               LastName = "Grillo",
               Place = "Lima" 
            }
        };

        private readonly DataContext _context;

        public crud1Controller(DataContext context)
        {
            _context = context;
        }
        
        [HttpGet("local")]
        public async Task<ActionResult<List<crud1>>> Get0All()
        {
            return Ok(test);
        }

        [HttpGet("DataConnection")]
        public async Task<ActionResult<List<crud1>>> GetAll()
        {
            return Ok(await _context.cruds.ToListAsync());
        }

        [HttpGet("local{id}")]
        public async Task<ActionResult<crud1>> Get0Id(int id)
        {
            var datos = test.Find(h => h.Id == id);
            if (datos == null)
                return BadRequest("Data not found");

            return Ok(datos);
        }

        [HttpGet("DataConnection{id}")]
        public async Task<ActionResult<crud1>> GetId(int id)
        {
            var datos = await _context.cruds.FindAsync(id);
            if (datos == null)
                return BadRequest("Data not found");
 
            return Ok(datos);
        }

        [HttpPost("local")]
        public async Task<ActionResult<List<crud1>>> Add0Crud(crud1 datos)
        {
            test.Add(datos);
            return Ok(test);
        }


        [HttpPost("DataConnection")]
        public async Task<ActionResult<List<crud1>>> AddCrud(crud1 datos)
        {
            _context.cruds.Add(datos);
            await _context.SaveChangesAsync();
            return Ok(await _context.cruds.ToListAsync());
        }

        [HttpPut("local")]
        public async Task<ActionResult<List<crud1>>> Update0Crud(crud1 request)
        {
            var datos = test.Find(h => h.Id == request.Id);
            if (datos == null)
                return BadRequest("Data not found");

            datos.Name = request.Name;
            datos.FirstName = request.FirstName;
            datos.LastName = request.LastName;
            datos.Place = request.Place;
            return Ok(test);
        }

        [HttpPut("DataConnection")]
        public async Task<ActionResult<List<crud1>>> UpdateCrud(crud1 request)
        {
            var datos = await _context.cruds.FindAsync(request.Id);
            if (datos == null)
                return BadRequest("Data not found");

            datos.Name = request.Name;
            datos.FirstName = request.FirstName;
            datos.LastName = request.LastName;
            datos.Place = request.Place;

            await _context.SaveChangesAsync();
            return Ok(await _context.cruds.ToListAsync());
        }

        [HttpDelete("local{id}")]
        public async Task<ActionResult<List<crud1>>> Delete0Id(int id)
        {
            var datos = test.Find(h => h.Id == id);
            if (datos == null)
                return BadRequest("Data not found");

            test.Remove(datos);
            return Ok(datos);
        }


        [HttpDelete("DataConnection{id}")]
        public async Task<ActionResult<List<crud1>>> DeleteId(int id)
        {
            var datos = await _context.cruds.FindAsync(id);
            if (datos == null)
                return BadRequest("Data not found");

            _context.cruds.Remove(datos);
            await _context.SaveChangesAsync();
            return Ok(await _context.cruds.ToListAsync());
        }
    }
}
