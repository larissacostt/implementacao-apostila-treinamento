using Microsoft.EntityFrameworkCore;
using Modelo.Cadastros;

namespace capitulo01.Data.DAL.Cadastros
{
    public class DisciplinaDAL
    {
        private IESContext _context;

        public DisciplinaDAL(IESContext context)
        {
            _context = context;
        }

        public IQueryable<Disciplina> ObterDisciplinasClassificadasPorNome()
        {
            return _context.Disciplinas
                .OrderBy(d => d.Nome);
        }

        public async Task<Disciplina> GravarDisciplina(Disciplina disciplina)
        {
            if (disciplina.DisciplinaID == null)
            {
                _context.Disciplinas.Add(disciplina);
            }
            else
            {
                _context.Disciplinas.Update(disciplina);
            }

            await _context.SaveChangesAsync();

            return disciplina;
        }
    }
}
