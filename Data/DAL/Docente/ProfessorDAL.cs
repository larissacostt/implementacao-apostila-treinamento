using Modelo.Docente;

namespace capitulo01.Data.DAL.Docente
{
    public class ProfessorDAL
    {
        private IESContext _context;

        public ProfessorDAL(IESContext context)
        {
            _context = context;
        }

        public IQueryable<Professor> ObterProfessoresClassificadosPorNome()
        {
            return _context.Professores
                .OrderBy(p => p.Nome);
        }

        public async Task<Professor> GravarProfessor(Professor professor)
        {
            if (professor.ProfessorID == null)
            {
                _context.Professores.Add(professor);
            }
            else
            {
                _context.Update(professor);
            }

            await _context.SaveChangesAsync();

            return professor;
        }
    }
}
