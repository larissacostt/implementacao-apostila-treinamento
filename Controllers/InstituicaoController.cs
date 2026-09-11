using capitulo01.Data;
using capitulo01.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace capitulo01.Controllers
{
   
    public class InstituicaoController : Controller
    {
        private readonly IESContext _context;

        public InstituicaoController(IESContext context)
        {
            this._context = context;
        }

        public static IList<Instituicao> instituicoes =
            new List<Instituicao>()
            {
                new Instituicao() {
                    InstituicaoID = 1,
                    Nome = "UniCampi",
                    Endereco = "São Paulo"
            },
                new Instituicao()
                {
                    InstituicaoID = 2,
                    Nome = "UniSanta",
                    Endereco = "Santa Catarina"
                },

                new Instituicao()
                {
                    InstituicaoID = 3,
                    Nome = "UniSul",
                    Endereco = "Rio Grande do Sul"
                }
            };
        public async Task<IActionResult> Index()
        {

            return View(await _context.Instituicoes.OrderBy(i => i.Nome).ToListAsync());
        }

        //GET: Instituicao/Create
        
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }



        //POST: Instituicao/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nome,Endereco")] Instituicao instituicao)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(instituicao);
                    await _context.SaveChangesAsync();

                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Não foi possível inserir os dados");
            }
            return View(instituicao);
        }


        //GET: Instituicao/Edit
        public async Task<IActionResult>Edit(long? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var instituicao = await _context.Instituicoes.SingleOrDefaultAsync(i => i.InstituicaoID == id);

            if(instituicao == null)
            {
                return NotFound();
            }
            return View(instituicao);
        }

        //POST: Instituicao/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit (long? id, [Bind("InstituicaoID,Nome,Endereco")] Instituicao instituicao)
        {
            if (id != instituicao.InstituicaoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(instituicao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateException)
                {
                    if (!InstituicaoExists(instituicao.InstituicaoID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            return View(instituicao);
        }

        // GET: Details
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instituicao = await _context.Instituicoes.SingleOrDefaultAsync(i => i.InstituicaoID == id);

            if (instituicao == null)
            {
                return NotFound();
            }

            return View(instituicao);
        }


        //GET: Instituicao/Delete
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instituicao = await _context.Instituicoes.SingleOrDefaultAsync(i => i.InstituicaoID == id);
            if (instituicao == null)
            {
                return NotFound();
            }

            return View(instituicao);
        }


        // POST: Instituicao/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long? id)
        {
            var instituicao = await _context.Instituicoes.
                SingleOrDefaultAsync(m => m.InstituicaoID == id);

            if(instituicao == null)
            {
                return NotFound();
            }

            _context.Instituicoes.Remove(instituicao);

            await _context.SaveChangesAsync();

            TempData["Message"] = "Instituição	" +
                instituicao.Nome.ToUpper() +
                "	foi	removida";

            return RedirectToAction(nameof(Index));
        }
        private bool InstituicaoExists(long? id)
        {
            return _context.Instituicoes.Any(e => e.InstituicaoID == id);
        }

    }
}
