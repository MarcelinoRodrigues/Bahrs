using bahrsDB.Data;
using bahrsDB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace bahrsDB.Controllers
{
    public class AccountController : Controller
    {
        private readonly bahrsDBContext _context;

        public AccountController(bahrsDBContext context)
        {
            _context = context;
        }

        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        void connectionString()
        {
            con.ConnectionString = "Server=LAPTOP-D2CCMIVK\\SQLEXPRESS;Database=SystemMRN;Trusted_Connection=True";
        }
        [HttpPost]
        public IActionResult Verify(Account acc)
        {
            connectionString();
            con.Open();
            com.Connection = con;
            com.CommandText = "select * from Account where Nome='" + acc.Nome + "' and Senha='" + acc.Senha + "'";
            dr = com.ExecuteReader();
            if (dr.Read())
            {
                con.Close();
                return View("Create");
            }
            else
            {
                con.Close();
                return View("Error");
            }
        }

        [HttpGet]
        public async Task<IActionResult> VerifyPassword(string nome)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> VerifyPassword(string nome, [Bind("Nome,Senha")] Account acc)
        {
            var nomeChamador = _context.Account.Any(a => a.Nome == nome);
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(acc);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AccountExists(acc.Nome))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                TempData["Mensagem"] = "Operação realizada com sucesso.";
                return RedirectToAction(nameof(VerifyPassword));
            }
            return View(acc);
        }

        private bool AccountExists(string nome)
        {
            return _context.Account.Any(e => e.Nome == nome);
        }
    }
}
