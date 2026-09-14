using Microsoft.EntityFrameworkCore;
using Modelo.Cadastros;

namespace capitulo01.Data.DAL.Cadastros
{
    public class InstituicaoDAL
    {
        private readonly IESContext _context;

        public InstituicaoDAL(IESContext context)
        {
            _context = context;
        }


        public async Task<Instituicao> ObterInstituicaoPorId(long id)
        {
            return await _context.Instituicoes
                .Include(d => d.Departamentos)
                .SingleOrDefaultAsync(m => m.InstituicaoID == id);
        }

        public IQueryable<Instituicao> ObterInstituicoesClassificadasPorNome()
        {
            return _context.Instituicoes.OrderBy(i => i.Nome);
        }

        public async Task<Instituicao> GravarInstituicao(Instituicao instituicao)
        {
            if (instituicao.InstituicaoID == null) {
                _context.Instituicoes.Add(instituicao);
            }
            else
            {
                _context.Update(instituicao);
            }

            await _context.SaveChangesAsync();
            return instituicao;
        }

        public async Task<Instituicao> EliminarInstituicaoPorId(long id)
        {
            Instituicao instituicao = await ObterInstituicaoPorId(id);
            _context.Instituicoes.Remove(instituicao);
            await _context.SaveChangesAsync();
            return instituicao;
        }
    }
}