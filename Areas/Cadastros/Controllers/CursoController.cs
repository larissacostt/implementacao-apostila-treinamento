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
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var disciplina = await _context.Disciplinas
                .Include(d => d.CursosDisciplinas)
                    .ThenInclude(cd => cd.Curso)
                .FirstOrDefaultAsync(d => d.DisciplinaID == id);

            if (disciplina == null)
            {
                return NotFound();
            }

            return View(disciplina);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Curso curso, long[] disciplinaIDs)
        {
            if (ModelState.IsValid)
            {
                await cursoDAL.GravarCurso(curso);

                foreach (var disciplinaID in disciplinaIDs)
                {
                    var cursoDisciplina = new CursoDisciplina
                    {
                        CursoID = curso.CursoID,
                        DisciplinaID = disciplinaID
                    };

                    _context.Set<CursoDisciplina>().Add(cursoDisciplina);
                }

                await _context.SaveChangesAsync();

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

            ViewBag.Disciplinas = _context.Disciplinas
                .OrderBy(d => d.Nome)
                .ToList();

            return View(curso);
        }
    }
}
