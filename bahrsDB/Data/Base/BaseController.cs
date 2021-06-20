/******
 * Classe base para os controllers
 * Diego Gaspar
 * ****/


using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace bahrsDB.Data.Base
{

    public abstract class BaseController<T> : Controller where T : class
    {
        protected readonly bahrsDBContext _context;

        protected BaseController(bahrsDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public virtual async Task<IActionResult> Index()
        {
            var lista = await _context.Set<T>().ToListAsync();

            return View(lista);
        }

        [HttpGet]
        public virtual async Task<IActionResult> Details(string id)
        {
            T objeto = await GetObjeto(id);

            if (objeto != null)
                return View(objeto);

            TempData["Mensagem"] = "Registro não encontrado";

            return RedirectToAction("index");
        }

        [HttpGet]
        public virtual IActionResult Create()
        {
            return View();
        }

        public virtual async Task<IActionResult> Create(T objeto)
        {
            if (objeto == null)
                TempData["Mensagem"] = "Registro não encontrado";
            else
            {
                SetProp(objeto, "Ativo", "DoubleCheck");

                await _context.AddAsync(objeto);
                await _context.SaveChangesAsync();

                TempData["Mensagem"] = "Operação realizada com sucesso.";
            }

            return RedirectToAction("index");
        }

        [HttpGet]
        public virtual async Task<IActionResult> Edit(string id)
        {
            T objeto = await GetObjeto(id);

            if (objeto != null)
                return View(objeto);


            TempData["Mensagem"] = "Registro não encontrado";


            return RedirectToAction("index");
        }

        [HttpPost]
        public virtual IActionResult Edit(T objeto)
        {
            if (objeto == null)
                TempData["Mensagem"] = "Registro não encontrado";
            else
            {
                SetProp(objeto, "Ativo", "DoubleCheck");

                _context.Update(objeto);
                _context.SaveChanges();

                TempData["Mensagem"] = "Operação realizada com sucesso.";
            }

            return RedirectToAction("index");
        }

        [HttpGet]
        public virtual async Task<IActionResult> Delete(string id)
        {

            T objeto =await GetObjeto(id);

            if (objeto == null)
                TempData["Mensagem"] = "Registro não encontrado";
            else
            {
                _context.Remove(objeto);
                _context.SaveChanges();
                TempData["Mensagem"] = "Operação realizada com sucesso.";
            }
            return RedirectToAction("index");
        }

        public virtual async Task<T> GetObjeto(string id)
        {
            int IdAux = 0;
            int.TryParse(id, out IdAux);


            T objeto = null;


            //Busca nas tabelas que tem ID tipo inteiro
            if (IdAux > 0)
                objeto = await _context.Set<T>().FindAsync(IdAux);

            //Busca nas tabelas que tem ID tipo string
            else if (!string.IsNullOrWhiteSpace(id) && id != "0")
                objeto = await _context.Set<T>().FindAsync(id);


            return objeto;
        }

        protected void SetProp(T objeto, params string[] props)
        {
            foreach (var prop in props)
            {
                var propName = objeto
                                    .GetType()
                                    .GetProperty(prop)?.Name;

                if (!string.IsNullOrWhiteSpace(propName))
                {
                    var isChecked = objeto
                                    .GetType()
                                    .GetProperty(propName)
                                    .GetValue(objeto);

                    objeto
                        .GetType()
                        .GetProperty(propName)
                        .SetValue(objeto, isChecked ?? false);
                }
            }
        }
    }
}
