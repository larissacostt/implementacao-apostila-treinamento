using Microsoft.EntityFrameworkCore;
using Modelo.Cadastros;
using Modelo.Docente;
using Departamento = Modelo.Cadastros.Departamento;

namespace capitulo01.Data.DAL.Cadastros
{
    public class CursoDAL
    {
        private IESContext _context;

        public CursoDAL(IESContext context)
        {
            _context = context;
        }

        public IQueryable<Curso> ObterCursosPorDepartamento(long departamentoID)
        {
            var cursos = _context.Cursos.Where(c => c.DepartamentoID == departamentoID).OrderBy(d => d.Nome);
            return cursos;
        }
        public IQueryable<Professor> ObterProfessoresForaDoCurso(long cursoID)
        {
            var curso = _context.Cursos.Where(c => c.CursoID == cursoID).Include(cp => cp.CursosProfessores).First();
            var professoresDoCurso = curso.CursosProfessores.Select(cp => cp.ProfessorID).ToArray();
            var professoresForaDoCurso = _context.Professores.Where(p => !professoresDoCurso.Contains(p.ProfessorID));
            return professoresForaDoCurso;
        }

        public IQueryable<Curso> ObterCursosClassificadosPorNome()
        {
            return _context.Cursos.OrderBy(c => c.Nome);
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
        public async Task GravarCurso(Curso curso)
        {
            if (curso.CursoID == null)
            {
                _context.Cursos.Add(curso);
            }
            else
            {
                _context.Cursos.Update(curso);
            }

            await _context.SaveChangesAsync();
        }
    }
}
