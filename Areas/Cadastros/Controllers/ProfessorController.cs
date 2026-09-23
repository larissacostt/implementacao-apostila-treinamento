using capitulo01.Data;
using capitulo01.Data.DAL.Cadastros;
using capitulo01.Data.DAL.Docente;
using Microsoft.AspNetCore.Mvc;

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

        public IActionResult Create()
        {
            return View();
        }

        public ProfessorController (IESContext context)
        {
            _context = context;
            instituicaoDAL = new InstituicaoDAL(context);
            departamentoDAL = new DepartamentoDAL(context);
            cursoDAL = new CursoDAL(context);
            professorDAL = new ProfessorDAL(context);
        }


    }

}
