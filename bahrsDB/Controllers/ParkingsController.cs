using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using bahrsDB.Data;
using bahrsDB.Models;

namespace bahrsDB.Controllers
{
    public class ParkingsController : Controller
    {
        private readonly bahrsDBContext _context;

        public ParkingsController(bahrsDBContext context)
        {
            _context = context;
        }

        // GET: Parkings
        public async Task<IActionResult> Index()
        {
            var bahrsDBContext = _context.Parking.Include(p => p.Funcionario).Include(p => p.Vaga).Include(p => p.Veiculo);
            return View(await bahrsDBContext.ToListAsync());
        }

        // GET: Parkings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parking = await _context.Parking
                .Include(p => p.Funcionario)
                .Include(p => p.Vaga)
                .Include(p => p.Veiculo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (parking == null)
            {
                return NotFound();
            }

            return View(parking);
        }

        // GET: Parkings/Create
        public IActionResult Create()
        {
            ViewData["FuncionarioId"] = new SelectList(_context.Employee, "Id", "Nome");
            ViewData["VagaId"] = new SelectList(_context.Vacancy, "Id", "Nome");
            ViewData["VeiculoId"] = new SelectList(_context.Vehicle, "Id", "Nome");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Entrada,Vencimento,Valor,VeiculoId,FuncionarioId,VagaId")] Parking parking)
        {
            if (ModelState.IsValid)
            {
                _context.Add(parking);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["FuncionarioId"] = new SelectList(_context.Employee, "Id", "Nome", parking.FuncionarioId);
            ViewData["VagaId"] = new SelectList(_context.Vacancy, "Id", "Nome", parking.VagaId);
            ViewData["VeiculoId"] = new SelectList(_context.Vehicle, "Id", "Nome", parking.VeiculoId);
            return View(parking);
        }

        // GET: Parkings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parking = await _context.Parking.FindAsync(id);
            if (parking == null)
            {
                return NotFound();
            }
            ViewData["FuncionarioId"] = new SelectList(_context.Employee, "Id", "Nome", parking.FuncionarioId);
            ViewData["VagaId"] = new SelectList(_context.Vacancy, "Id", "Nome", parking.VagaId);
            ViewData["VeiculoId"] = new SelectList(_context.Vehicle, "Id", "Nome", parking.VeiculoId);
            return View(parking);
        }

        // POST: Parkings/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Entrada,Vencimento,Valor,VeiculoId,FuncionarioId,VagaId")] Parking parking)
        {
            if (id != parking.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(parking);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ParkingExists(parking.Id))
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
            ViewData["FuncionarioId"] = new SelectList(_context.Employee, "Id", "Nome", parking.FuncionarioId);
            ViewData["VagaId"] = new SelectList(_context.Vacancy, "Id", "Nome", parking.VagaId);
            ViewData["VeiculoId"] = new SelectList(_context.Vehicle, "Id", "Nome", parking.VeiculoId);
            return View(parking);
        }

        // GET: Parkings/Delete/ID
        public async Task<IActionResult> Delete(int? id, int? verificarSeEstaAssociado = null)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parking = await _context.Parking
                .Include(p => p.Funcionario)
                .Include(p => p.Vaga)
                .Include(p => p.Veiculo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (parking == null)
            {
                return NotFound();
            }

            if (verificarSeEstaAssociado.HasValue)
            {
                return View();
            }

            return View(parking);
        }

        // POST: Parkings/Delete/ID
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var parking = await _context.Parking.FindAsync(id);
            _context.Parking.Remove(parking);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private bool ParkingExists(int id)
        {
            return _context.Parking.Any(e => e.Id == id);
        }
    }
}
