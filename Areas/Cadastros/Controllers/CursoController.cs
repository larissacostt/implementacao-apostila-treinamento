using capitulo01.Data;
using capitulo01.Data.DAL.Cadastros;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Modelo.Cadastros;
using Departamento = Modelo.Cadastros.Departamento;

namespace capitulo01.Areas.Cadastros.Controllers
{

    [Area("Cadastros")]
    public class CursoController : Controller
    {
        private readonly IESContext _context;
        private readonly CursoDAL cursoDAL;
        private readonly DepartamentoDAL departamentoDAL;
        public CursoController(IESContext context)
        {
            _context = context;
            cursoDAL = new CursoDAL(context);
            departamentoDAL = new DepartamentoDAL(context);
        }
        public async Task<IActionResult> Index(long? departamentoID)
        {
            var cursos = cursoDAL
                .ObterCursosClassificadosPorNome();

            if (departamentoID.HasValue)
            {
                cursos = cursos
                    .Where(c => c.DepartamentoID == departamentoID.Value);
            }

            ViewBag.Departamentos = departamentoDAL
                   .ObterDepartamentosClassificadosPorNome()
                   .ToList();

            return View(await cursos.ToListAsync());
        }

        [HttpGet]
        public IActionResult Create()
        {
            var departamentos = departamentoDAL
                .ObterDepartamentosClassificadosPorNome()
                .ToList();

            departamentos.Insert(0, new Departamento()
            {
                DepartamentoID = 0,
                Nome = "Selecione o departamento"
            });

            ViewBag.Departamentos = departamentos;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Curso curso)
        {
            if (ModelState.IsValid)
            {
                await cursoDAL.GravarCurso(curso);
                return RedirectToAction(nameof(Index));
            }

            var departamentos = departamentoDAL
                .ObterDepartamentosClassificadosPorNome()
                .ToList();

            departamentos.Insert(0, new Departamento()
            {
                DepartamentoID = 0,
                Nome = "Selecione o departamento"
            });

            ViewBag.Departamentos = departamentos;

            return View(curso);
        }
    }
}
