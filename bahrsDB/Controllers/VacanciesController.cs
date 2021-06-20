using bahrsDB.Data;
using bahrsDB.Data.Base;
using bahrsDB.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace bahrsDB.Controllers
{
    public class VacanciesController : BaseController<Vacancy>
    {

        public VacanciesController(bahrsDBContext context) : base(context)
        {
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public override async Task<IActionResult> Create([Bind("Id,Nome")] Vacancy vacancy)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vacancy);
                await _context.SaveChangesAsync();
                TempData["Mensagem"] = "Operação realizada com sucesso.";
                return RedirectToAction(nameof(Index));
            }
            return View(vacancy);
        }

        // Recebe o delete via javascript
        public override async Task<IActionResult> Delete(string id)
        {
            var vacancies = await _context.Vacancy.FindAsync(int.Parse(id));
            _context.Vacancy.Remove(vacancies);

            //Verifica se existe a vaga informada na aplicação de estacionamento
            var verificaSeEstarAssociado = _context.Parking.Any(e => e.VagaId == int.Parse(id));
            //se estiver associada retorna a pagina
            if (verificaSeEstarAssociado)
            {
                TempData["Mensagem"] = "A Vaga ainda está vinculado a um veículo.";
                return RedirectToAction(nameof(Index));
            }
            TempData["Mensagem"] = "Operação realizada com sucesso.";
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VacancyExists(int id)
        {
            return _context.Vacancy.Any(e => e.Id == id);
        }
    }
}
