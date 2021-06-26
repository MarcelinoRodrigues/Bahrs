using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using bahrsDB.Data;
using bahrsDB.Models;
using bahrsDB.Services.Enum;
using Sitecore.FakeDb;

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
            // seleção de todos os funcionarios
            ViewData["FuncionarioId"] = new SelectList(_context.Employee, "Id", "Nome");
            // seleção das vagas onde o status esteja ativo
            ViewData["VagaId"] = new SelectList(_context.Vacancy.Where(x => x.Status == Status.Ativo), "Id", "Nome");
            // seleção dos veiculos onde o status esteja ativo
            ViewData["VeiculoId"] = new SelectList(_context.Vehicle.Where(x => x.Status == Status.Ativo), "Id", "Nome");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Entrada,Vencimento,Valor,VeiculoId,FuncionarioId,VagaId")] Parking parking)
        {
            if (ModelState.IsValid)
            {
                //Pegando A VagaID
                var vaga = await _context.Vacancy.FindAsync(parking.VagaId);

                //Ao ser incluido um estacionamento a vaga altera seu Status para Desativado
                if( _context.Vacancy.Any(e => e.Id == parking.VagaId))
                {
                    vaga.Status = Status.Desativado;
                    _context.Vacancy.Update(vaga);
                }

                //a Entrada do veiculo no estacionamento não pode ter um horário maior que a saída.
                if (parking.Entrada > parking.Vencimento)
                {
                    TempData["Mensagem"] = "O vencimento não pode ser menor que a entrada";
                    return RedirectToAction(nameof(Index));
                }

                _context.Add(parking);
                await _context.SaveChangesAsync();
                TempData["Mensagem"] = "Operação realizada com sucesso.";
                return RedirectToAction(nameof(Index));
            }

            ViewData["FuncionarioId"] = new SelectList(_context.Employee, "Id", "Nome", parking.FuncionarioId);
            ViewData["VagaId"] = new SelectList(_context.Vacancy, "Id", "Nome", parking.VagaId);
            ViewData["VeiculoId"] = new SelectList(_context.Vehicle, "Id", "Status", parking.VeiculoId);

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
                //a Entrada do veiculo no estacionamento não pode ter um horário maior que a saída.
                if (parking.Entrada > parking.Vencimento)
                {
                    TempData["Mensagem"] = "O vencimento não pode ser menor que a entrada";
                    return RedirectToAction(nameof(Index));
                }
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
                TempData["Mensagem"] = "Operação realizada com sucesso.";
                return RedirectToAction(nameof(Index));
            }
            ViewData["FuncionarioId"] = new SelectList(_context.Employee, "Id", "Nome", parking.FuncionarioId);
            ViewData["VagaId"] = new SelectList(_context.Vacancy, "Id", "Nome", parking.VagaId);
            ViewData["VeiculoId"] = new SelectList(_context.Vehicle, "Id", "Nome", parking.VeiculoId);
            return View(parking);
        }

        // GET: Parkings/Delete/ID
        public async Task<IActionResult> Delete(int? id)
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

        // POST: Parkings/Delete/ID
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var parking = await _context.Parking.FindAsync(id);
            _context.Parking.Remove(parking);

            //Pegando A VagaID
            var vaga = await _context.Vacancy.FindAsync(parking.VagaId);

            //Ao ser excluido um estacionamento a vaga altera seu Status para Ativo
            if (_context.Vacancy.Any(v => v.Id == parking.VagaId))
            {
                vaga.Status = Status.Ativo;
                _context.Vacancy.Update(vaga);
            }

            await _context.SaveChangesAsync();
            TempData["Mensagem"] = "Operação realizada com sucesso.";
            return RedirectToAction(nameof(Index));
        }

        private bool ParkingExists(int id)
        {
            return _context.Parking.Any(e => e.Id == id);
        }
    }
}
