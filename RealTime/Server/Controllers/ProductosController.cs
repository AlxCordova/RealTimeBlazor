using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RealTime.Shared;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RealTime.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private Conexion dbConexion;
        public ProductosController() { dbConexion = Conectar.GetConexion(); }
        // GET: api/<ProductosController>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await dbConexion.Productos.ToArrayAsync());
        }

        // GET api/<ProductosController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var productos = await dbConexion.Productos.SingleOrDefaultAsync(a => a.idProducto == id);
            if (productos != null)
            {
                return Ok(productos);
            }
            else
            {
                return NotFound();
            }
        }

        // POST api/<ProductosController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Productos productos)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            await dbConexion.Productos.AddAsync(productos);
            dbConexion.SaveChanges();
            return Created("api/productos", productos);
        }

        // PUT api/<ProductosController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Productos productos)
        {
            var v_productos = await dbConexion.Productos.SingleOrDefaultAsync(a => a.idProducto == id);
            if (v_productos != null && ModelState.IsValid)
            {
                dbConexion.Entry(v_productos).CurrentValues.SetValues(productos);
                dbConexion.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        // DELETE api/<ProductosController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var productos = await dbConexion.Productos.SingleOrDefaultAsync(a => a.idProducto == id);
            if (productos != null)
            {
                dbConexion.Productos.Remove(productos);
                dbConexion.SaveChanges();
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
