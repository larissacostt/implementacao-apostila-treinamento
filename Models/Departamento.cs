using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace capitulo01.Models
{
    public class Departamento
    {
        public long? DepartamentoID {  get; set; }
        public string Nome {  get; set; }

        public long? InstiuicaoID {  get; set; }
        public Instituicao Instituicao { get; set; }

    public async Task<IActionResult> Index()
        {
            return View(await _context.Departamentos.Include(i => i.Instituicao).OrderBy(c => c.Nome).ToListAsync());
        }


    }
}
