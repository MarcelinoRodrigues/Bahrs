using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using bahrsDB.Data;
using bahrsDB.Models;
using bahrsDB.Data.Base;

namespace bahrsDB.Controllers
{
    public class EmployeesController : BaseController<Employee>
    {
        public EmployeesController(bahrsDBContext context) : base(context)
        {
        }

        // Recebe o delete via javascript
        [HttpGet]
        public override async Task<IActionResult> Delete(string id)
        {
            var employees = await _context.Employee.FindAsync(int.Parse(id));
            _context.Employee.Remove(employees);

            //Verifica se existe um veiculo informado na aplicação de estacionamento
            var verificaSeEstarAssociado = _context.Parking.Any(e => e.FuncionarioId == int.Parse(id));
            //se estiver associada retorna a pagina
            if (verificaSeEstarAssociado)
            {
                TempData["Mensagem"] = "O Funcionário ainda está vinculado a uma Estacionamento.";
                return RedirectToAction(nameof(Index));
            }

            TempData["Mensagem"] = "Operação realizada com sucesso.";
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employee.Any(e => e.Id == id);
        }
    }
}
