using capitulo01.Areas.Cadastros.Docente;
using capitulo01.Data;
using capitulo01.Data.DAL.Cadastros;
using capitulo01.Data.DAL.Docente;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Modelo.Cadastros;
using Modelo.Docente;
using Departamento = Modelo.Cadastros.Departamento;
using Instituicao = Modelo.Cadastros.Instituicao;

namespace capitulo01.Areas.Controllers
{
    [Area("Docente")]
    public class ProfessorController : Controller
    {
        private readonly IESContext _context;
        private readonly InstituicaoDAL instituicaoDAL;
        private readonly DepartamentoDAL departamentoDAL;
        private readonly CursoDAL cursoDAL;
        private readonly ProfessorDAL professorDAL;

        public long DepartamentoID { get; private set; }

        public ProfessorController (IESContext context)
        {
            _context = context;
            instituicaoDAL = new InstituicaoDAL(context);
            departamentoDAL = new DepartamentoDAL(context);
            cursoDAL = new CursoDAL(context);
            professorDAL = new ProfessorDAL(context);
        }

        public IActionResult Create()
        {
            return View();
        }
        
        public void PrepararViewBags(List<Instituicao>instituicoes, List<Departamento> departamentos, List<Curso> cursos, List<Professor>professores)
        {
            instituicoes.Insert(0, new Instituicao() { InstituicaoID = 0, Nome = "Selecione a Instituicao" });
            ViewBag.Instituicoes = instituicoes;

            departamentos.Insert(0, new Departamento() { DepartamentoID = 0, Nome = "Selecione o Departamento" });
            ViewBag.Departamentos = departamentos;

            cursos.Insert(0, new Curso() { CursoID = 0, Nome = "Selecione o Curso" });
            ViewBag.Cursos = cursos;

            professores.Insert(0, new Professor() { ProfessorID = 0, Nome = "Selecione Professor" });
            ViewBag.Professores = professores;
        }

        [HttpGet]
        public IActionResult AdicionarProfessor()
        {
            PrepararViewBags(instituicaoDAL.ObterInstituicoesClassificadasPorNome().ToList(),
                new List<Departamento>().ToList(), new List<Curso>().ToList(), new List<Professor>().ToList());
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AdicionarProfessor([Bind("InstituicaoID, DepartamentoID, CursoID, ProfessorID" )] AdicionarProfessorViewModel model)
        {
            if(model.InstituicaoID == 0 || model.DepartamentoID == 0 || model.CursoID == 0 || model.ProfessorID == 0)
            {
                ModelState.AddModelError(" ", "É preciso selecionar todos os dados");
            }
            else
            {
                cursoDAL.RegistrarProfessor((long)model.CursoID, (long)model.ProfessorID);
                PrepararViewBags(instituicaoDAL.ObterInstituicoesClassificadasPorNome().ToList(),
                    departamentoDAL.ObterDepartamentoPorIntsituicao((long)model.InstituicaoID),
                    cursoDAL.ObterCursosPorDepartamento((long)model.DepartamentoID).ToList(),
                    cursoDAL.ObterProfessoresForaDoCurso((long)model.CursoID).ToList());
            }
            return View(model);
        }
        public void RegistrarProfessor(long cursoID, long professorID)
        {
            var curso = _context.Cursos.Where(c => c.CursoID == cursoID).Include(cp => cp.CursosProfessores).First();
            var professor = _context.Professores.Find(professorID);
            curso.CursosProfessores.Add(new CursoProfessor()
            {
                Curso = curso,
                Professor = professor
            });
            _context.SaveChanges();
        }
    }
}
