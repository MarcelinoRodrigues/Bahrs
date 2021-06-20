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
       
        // GET: Vehicles/Delete/5
        public override async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicle = await _context.Vehicle
                .FirstOrDefaultAsync(m => m.Id == int.Parse(id));
            if (vehicle == null)
            {
                return NotFound();
            }

            return View(vehicle);
        }

        // POST: Vehicles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vehicle = await _context.Vehicle.FindAsync(id);
            _context.Vehicle.Remove(vehicle);

            //Verifica se existe a vaga informada na aplicação de estacionamento
            var verificaSeEstarAssociado = _context.Parking.Any(v => v.VeiculoId == id);
            //se estiver associada retorna a pagina
            if (verificaSeEstarAssociado)
            {

                TempData["Mensagem"] = "O veículo ainda está vinculado a uma vaga.";
                return RedirectToAction(nameof(Index));
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VehicleExists(int id)
        {
            return _context.Vehicle.Any(e => e.Id == id);
        }
    }
}
