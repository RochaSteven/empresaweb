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
    public class VehiculosController : Controller
    {
        private readonly DataMainContext _context;

        public VehiculosController(DataMainContext context)
        {
            _context = context;
        }

        // GET: Vehiculos
        public async Task<IActionResult> Index()
        {

            var vehiculos = _context.Vehiculo
                .Include(v => v.Motor)
                .AsNoTracking();
            return View(await vehiculos.ToListAsync());
        }

        // GET: Vehiculos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehiculo = await _context.Vehiculo
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.IdVehiculo == id);
            if (vehiculo == null)
            {
                return NotFound();
            }

            return View(vehiculo);
        }

        // GET: Vehiculos/Create
        public IActionResult Create()
        {
            MotorList();
            return View();
        }

        // POST: Vehiculos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdVehiculo,Modelo,Color,IdMotor,IdEmpresa")] Vehiculo vehiculo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vehiculo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            MotorList(vehiculo.IdMotor);
            return View(vehiculo);
        }


        // GET: Vehiculos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehiculo = await _context.Vehiculo
                .AsNoTracking()
                .FirstOrDefaultAsync(v => v.IdVehiculo == id);
                
            if (vehiculo == null)
            {
                return NotFound();
            }
            MotorList(vehiculo.IdMotor);
            return View(vehiculo);
        }

        // POST: Vehiculos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
       [HttpPost, ActionName ("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var vehiculoUpdate = await _context.Vehiculo
                .FirstOrDefaultAsync(c => c.IdVehiculo==id);

            if (await TryUpdateModelAsync<Vehiculo>(vehiculoUpdate,"",
                c=>c.IdMotor, c=>c.Color, c => c.Modelo
                ))
            {
                try
                {
                   
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateException)
                {
                    //Log the error (uncomment ex variable name and write a log.)
                    ModelState.AddModelError("", "Unable to save changes. " +
                        "Try again, and if the problem persists, " +
                        "see your system administrator.");
                }
                return RedirectToAction(nameof(Index));
            }
            MotorList(vehiculoUpdate.IdMotor);
            return View(vehiculoUpdate);
        }
        private void MotorList(object selectMotor=null)
        {
            var motoresQuery = from m in _context.Motor
                               orderby m.TipoDeMotor
                               select m;
            ViewBag.IdMotor = new SelectList(motoresQuery.AsNoTracking(), "IdMotor", "TipoDeMotor", selectMotor);
        }

        // GET: Vehiculos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehiculo = await _context.Vehiculo
                .Include(c=>c.Motor)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.IdVehiculo == id);
            if (vehiculo == null)
            {
                return NotFound();
            }

            return View(vehiculo);
        }

        // POST: Vehiculos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vehiculo = await _context.Vehiculo.FindAsync(id);
            _context.Vehiculo.Remove(vehiculo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VehiculoExists(int id)
        {
            return _context.Vehiculo.Any(e => e.IdVehiculo == id);
        }
    }
}
