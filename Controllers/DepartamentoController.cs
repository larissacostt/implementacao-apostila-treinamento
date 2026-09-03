using capitulo01.Data;
using Microsoft.AspNetCore.Mvc;

namespace capitulo01.Controllers
{
    public class DepartamentoController : Controller
    {

        private readonly IESContext _context;

        public DepartamentoController(IESContext context)
        {
            this._context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Departamentos.OrderBy(c => c.Nome).ToListAsync());
        }
    }
}
