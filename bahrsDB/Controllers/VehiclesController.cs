using bahrsDB.Data;
using bahrsDB.Data.Base;
using bahrsDB.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace bahrsDB.Controllers
{
    public class VehiclesController : BaseController<Vehicle>
    {
        public VehiclesController(bahrsDBContext context): base(context)
        {           
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public override async Task<IActionResult> Create([Bind("Id,Nome,Placa")] Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vehicle);
                await _context.SaveChangesAsync();
                TempData["Mensagem"] = "Operação realizada com sucesso.";
                return RedirectToAction(nameof(Index));
            }
            return View(vehicle);
        }

        // Recebe o delete via javascript
        [HttpGet]
        public override async Task<IActionResult> Delete(string id)
        {
            var vehicle = await _context.Vehicle.FindAsync(int.Parse(id));
            _context.Vehicle.Remove(vehicle);

            //Verifica se existe um veiculo informado na aplicação de estacionamento
            var verificaSeEstarAssociado = _context.Parking.Any(v => v.VeiculoId == int.Parse(id));
            //se estiver associada retorna a pagina
            if (verificaSeEstarAssociado)
            {

                TempData["Mensagem"] = "O veículo ainda está vinculado a uma vaga.";
                return RedirectToAction(nameof(Index));
            }

            TempData["Mensagem"] = "Operação realizada com sucesso.";
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VehicleExists(int id)
        {
            return _context.Vehicle.Any(e => e.Id == id);
        }
    }
}
