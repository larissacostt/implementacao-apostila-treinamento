using capitulo01.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Modelo.Cadastros;

namespace capitulo01.Areas.Cadastros.Controllers
{
    [Area("Cadastros")]
    public class DisciplinaController : Controller
    {
        private readonly IESContext _context;

        public DisciplinaController(IESContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Disciplinas
                .OrderBy(d => d.Nome)
                .ToListAsync());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Disciplina disciplina)
        {
            if (ModelState.IsValid)
            {
                _context.Disciplinas.Add(disciplina);

                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(disciplina);
        }
    }
}
