using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MoneySplitterApi.Models;

namespace MoneySplitterApi.Controllers
{
    [ApiController]
    public class LedgersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public LedgersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Ledgers
        [HttpGet]
        [Route("api/Ledgers")]
        public async Task<IActionResult> Index()
        {
            var ledgers = await _context.Ledgers.ToListAsync();
            return Ok(ledgers);
        }

        // POST: api/Debts/create
        [HttpPost]
        [Route("api/Ledgers/create")]
        public async Task<IActionResult> Create([Bind("Id,Description,Amount,Sign")] Ledgers ledgers)
        {
            if (ModelState.IsValid)
            {
                ledgers.Id = Guid.NewGuid();
                _context.Add(ledgers);
                await _context.SaveChangesAsync();
                return Ok(ledgers);
            }
            return BadRequest(ModelState);
        }

        // DELETE: api/Ledgers/delete/5
        [HttpDelete]
        [Route("api/Ledgers/delete/{id}")]
        public async Task<IActionResult> DeleteConfirmed(Guid? id)
        {
            var ledgers = await _context.Ledgers.FindAsync(id);
            if (ledgers != null)
            {
                _context.Ledgers.Remove(ledgers);
                await _context.SaveChangesAsync();
                return Ok();
            }
            return NotFound();
        }

        private bool LedgersExists(Guid id)
        {
            return _context.Ledgers.Any(e => e.Id == id);
        }
    }
}
