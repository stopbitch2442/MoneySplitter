using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoneySplitterApi.Models;

namespace MoneySplitterApi.Controllers
{
    [ApiController]
    public class DebtsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DebtsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Debts
        [HttpGet]
        [Route("api/Debts")]
        public async Task<IActionResult> Index()
        {
            var debts = await _context.Debts.ToListAsync();
            return Ok(debts);
        }

        // GET: api/Debts/5
        [HttpGet]
        [Route("api/Debts/{id}")]
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Debts == null)
            {
                return NoContent();
            }

            var debts = await _context.Debts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (debts == null)
            {
                return NoContent();
            }

            return Ok(debts);
        }

        // POST: api/Debts/create
        [HttpPost]
        [Route("api/Debts/create")]
        
        public async Task<IActionResult> Create([Bind("Id,Description,Amount,DateOwed,DeadLine,IsPaid,Creditor,Debtor")] Debts debts)
        {
            if (ModelState.IsValid)
            {
                debts.Id = Guid.NewGuid();
                _context.Add(debts);
                await _context.SaveChangesAsync();
                return Ok(debts);
            }
            return BadRequest(ModelState);
        }

        // PUT: api/Debts/edit/5
        [HttpPut]
        [Route("api/Debts/edit/{id}")]
        public async Task<IActionResult> Edit(Guid? id, [Bind("Id,Description,Amount,DateOwed,DeadLine,IsPaid,Creditor,Debtor")] Debts debts)
        {
            if (id == null || _context.Debts == null)
            {
                return NotFound();
            }

            if (id != debts.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(debts);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DebtsExists(debts.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return Ok(debts);
            }
            return BadRequest(ModelState);
        }

        // DELETE: api/delete/5
        [HttpDelete]
        [Route("api/delete/{id}")]
        public async Task<IActionResult> DeleteConfirmed(Guid? id)
        {
            var debts = await _context.Debts.FindAsync(id);
            if (debts != null)
            {
                _context.Debts.Remove(debts);
                await _context.SaveChangesAsync();
                return Ok();
            }
            return NotFound();
        }

        private bool DebtsExists(Guid id)
        {
            return _context.Debts.Any(e => e.Id == id);
        }
    }
}