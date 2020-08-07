using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Empresa2;
using Empresa2.Models;

namespace Empresa2.Controllers
{
    public class MotorsController : Controller
    {
        private readonly DataMainContext _context;

        public MotorsController(DataMainContext context)
        {
            _context = context;
        }

        // GET: Motors
        public async Task<IActionResult> Index()
        {
            return View(await _context.Motor.ToListAsync());
        }

        // GET: Motors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var motor = await _context.Motor
                .FirstOrDefaultAsync(m => m.IdMotor == id);
            if (motor == null)
            {
                return NotFound();
            }

            return View(motor);
        }

        // GET: Motors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Motors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdMotor,Marca,TipoDeMotor")] Motor motor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(motor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(motor);
        }

        // GET: Motors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var motor = await _context.Motor.FindAsync(id);
            if (motor == null)
            {
                return NotFound();
            }
            return View(motor);
        }

        // POST: Motors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdMotor,Marca,TipoDeMotor")] Motor motor)
        {
            if (id != motor.IdMotor)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(motor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MotorExists(motor.IdMotor))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(motor);
        }

        // GET: Motors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var motor = await _context.Motor
                .FirstOrDefaultAsync(m => m.IdMotor == id);
            if (motor == null)
            {
                return NotFound();
            }

            return View(motor);
        }

        // POST: Motors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var motor = await _context.Motor.FindAsync(id);
            _context.Motor.Remove(motor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MotorExists(int id)
        {
            return _context.Motor.Any(e => e.IdMotor == id);
        }
    }
}
