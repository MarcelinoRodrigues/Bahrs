using System.Linq;
using System.Threading.Tasks;
using bahrsDB.Data;
using bahrsDB.Data.Base;
using bahrsDB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace bahrsDB.Controllers
{
    public class VehiclesController : BaseController<Vehicle>
    {
        public VehiclesController(bahrsDBContext context): base(context)
        {           
        }
       
        // Recebe o delete via javascript
        [HttpGet]
        public override async Task<IActionResult> Delete(string id)
        {
            var vehicle = await _context.Vehicle.FindAsync(int.Parse(id));
            _context.Vehicle.Remove(vehicle);

            //Verifica se existe a vaga informada na aplicação de estacionamento
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
