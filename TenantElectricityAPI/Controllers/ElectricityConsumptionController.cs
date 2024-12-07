using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TenantElectricityAPI.Data;
using TenantElectricity.Shared.Models;

namespace TenantElectricityAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ElectricityConsumptionController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ElectricityConsumptionController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ElectricityConsumption>>> GetElectricityConsumptions()
        {
            return await _context.ElectricityConsumptions.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ElectricityConsumption>> GetElectricityConsumption(int id)
        {
            var consumption = await _context.ElectricityConsumptions.FindAsync(id);

            if (consumption == null) return NotFound();

            return consumption;
        }

        [HttpPost]
        public async Task<ActionResult<ElectricityConsumption>> PostElectricityConsumption(ElectricityConsumption consumption)
        {
            _context.ElectricityConsumptions.Add(consumption);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetElectricityConsumption), new { id = consumption.Id }, consumption);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutElectricityConsumption(int id, ElectricityConsumption consumption)
        {
            if (id != consumption.Id) return BadRequest();

            _context.Entry(consumption).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.ElectricityConsumptions.Any(e => e.Id == id)) return NotFound();
                throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteElectricityConsumption(int id)
        {
            var consumption = await _context.ElectricityConsumptions.FindAsync(id);
            if (consumption == null) return NotFound();

            _context.ElectricityConsumptions.Remove(consumption);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
