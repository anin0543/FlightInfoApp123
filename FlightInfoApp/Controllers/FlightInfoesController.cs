using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FlightInfoApp.Model;

namespace FlightInfoApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightInfoesController : ControllerBase
    {
        private readonly FlightInfoContext _context;

        public FlightInfoesController(FlightInfoContext context)
        {
            _context = context;
        }

        // GET: api/FlightInfoes
        [HttpGet]
        public IEnumerable<FlightInfo> GetFlightInfos()
        {
            return _context.FlightInfos;
        }

        // GET: api/FlightInfoes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFlightInfo([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var flightInfo = await _context.FlightInfos.FindAsync(id);

            if (flightInfo == null)
            {
                return NotFound();
            }

            return Ok(flightInfo);
        }

        // PUT: api/FlightInfoes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFlightInfo([FromRoute] int id, [FromBody] FlightInfo flightInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != flightInfo.FlightID)
            {
                return BadRequest();
            }

            _context.Entry(flightInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FlightInfoExists(id))
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

        // POST: api/FlightInfoes
        [HttpPost]
        public async Task<IActionResult> PostFlightInfo([FromBody] FlightInfo flightInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.FlightInfos.Add(flightInfo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFlightInfo", new { id = flightInfo.FlightID }, flightInfo);
        }

        // DELETE: api/FlightInfoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFlightInfo([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var flightInfo = await _context.FlightInfos.FindAsync(id);
            if (flightInfo == null)
            {
                return NotFound();
            }

            _context.FlightInfos.Remove(flightInfo);
            await _context.SaveChangesAsync();

            return Ok(flightInfo);
        }

        private bool FlightInfoExists(int id)
        {
            return _context.FlightInfos.Any(e => e.FlightID == id);
        }
       
    }
}