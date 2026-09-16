using capitulo01.Data;
using capitulo01.Data.DAL.Cadastros;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Modelo.Cadastros;

namespace capitulo01.Areas.Cadastros.Controllers
{
   
    public class InstituicaoController : Controller
    {
        private readonly IESContext _context;
        private readonly InstituicaoDAL instituicaoDAL;

        public InstituicaoController(IESContext context)
        {
            _context = context;
            instituicaoDAL = new InstituicaoDAL(context);
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
            return View(await instituicaoDAL
            .ObterInstituicoesClassificadasPorNome()
            .ToListAsync());
        }


        private async Task<IActionResult> ObterVisaoInstituicaoPorId(long? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var instituicao = await instituicaoDAL.ObterInstituicaoPorId((long) id);
            
            if(instituicao == null)
            {
                return NotFound();
            }
    

             return View(instituicao);
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
                    await instituicaoDAL.GravarInstituicao(instituicao);
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
        public async Task<IActionResult> Edit(long? id)
        {
            return await ObterVisaoInstituicaoPorId(id);
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
                try { 
             
                    await  instituicaoDAL.GravarInstituicao(instituicao);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await InstituicaoExists(instituicao.InstituicaoID))
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
            return await ObterVisaoInstituicaoPorId(id);
        }


        //GET: Instituicao/Delete
        public async Task<IActionResult> Delete(long? id)
        {
            return await ObterVisaoInstituicaoPorId(id);
        }


        // POST: Instituicao/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long? id)
        {
            var instituicao = await instituicaoDAL.EliminarInstituicaoPorId((long) id);
            TempData["Message"] = "Instituição	" +
                instituicao.Nome.ToUpper() +
                "	foi	removida";

            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> InstituicaoExists(long? id)
        {
            return await instituicaoDAL.ObterInstituicaoPorId((long)id) != null;
        }

    }
}
