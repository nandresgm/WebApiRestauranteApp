﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiRestauranteApp.Data;
using WebApiRestauranteApp.Models;

namespace WebApiRestauranteApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetallesController : ControllerBase
    {
        private readonly WebApiRestauranteAppContext _context;

        public DetallesController(WebApiRestauranteAppContext context)
        {
            _context = context;
        }

        // GET: api/Detalles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Detalle>>> GetDetalle()
        {
          if (_context.Detalle == null)
          {
              return NotFound();
          }
            return await _context.Detalle.ToListAsync();
        }

        // GET: api/Detalles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Detalle>> GetDetalle(int id)
        {
          if (_context.Detalle == null)
          {
              return NotFound();
          }
            var detalle = await _context.Detalle.FindAsync(id);

            if (detalle == null)
            {
                return NotFound();
            }

            return detalle;
        }

        // PUT: api/Detalles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDetalle(int id, Detalle detalle)
        {
            if (id != detalle.Id)
            {
                return BadRequest();
            }

            _context.Entry(detalle).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DetalleExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Detalles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Detalle>> PostDetalle(Detalle detalle)
        {
          if (_context.Detalle == null)
          {
              return Problem("Entity set 'WebApiRestauranteAppContext.Detalle'  is null.");
          }
            _context.Detalle.Add(detalle);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDetalle", new { id = detalle.Id }, detalle);
        }

        // DELETE: api/Detalles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDetalle(int id)
        {
            if (_context.Detalle == null)
            {
                return NotFound();
            }
            var detalle = await _context.Detalle.FindAsync(id);
            if (detalle == null)
            {
                return NotFound();
            }

            _context.Detalle.Remove(detalle);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DetalleExists(int id)
        {
            return (_context.Detalle?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
