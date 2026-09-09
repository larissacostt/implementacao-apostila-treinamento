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
        private static IList<Instituicao> instituicoes =
            new List<Instituicao>()
            {
                new Instituicao()
                {
                    InstituicaoID = 1,
                    Nome = "UniParaná",
                    Endereco = "Paraná"
                },

                new Instituicao()
                {
                    InstituicaoID = 2,
                    Nome = "UniSanta",
                    Endereco = "Santa Catarina"
                },
                new Instituicao() {
                    InstituicaoID = 3,
                    Nome = "UniSãoPaulo",
                    Endereco = "São Paulo"
                },
                new Instituicao() {
                    InstituicaoID= 4,
                    Nome = "UniSulgrandense",
                    Endereco = "Rio Grande do Sul"
                },
                new Instituicao() {
                    InstituicaoID = 5,
                    Nome = "UniCarioca",
                    Endereco = "Rio de Janeiro"
                }
            };
             
 
        //Definição	de uma	action	chamada	Index
        public IActionResult Index()
        {
            return View(instituicoes);
        }

        public ActionResult Create()
        {
            return View();
        }

        //Get - abre a tela de ediçao
        public ActionResult Edit(long id) //cria a action
        {
            return View(instituicoes.Where(i => i.InstituicaoID == id).First()); //busca e compara, e envia pra view
        }

        [HttpPost] //executada quando o formulário for enviado usando POST
        [ValidateAntiForgeryToken] //termo de segurança
        public ActionResult Create(Instituicao instituicao) //passa os parametros
        {
            instituicoes.Add(instituicao); //adiciona na lista
            instituicao.InstituicaoID = instituicoes.Select(i => i.InstituicaoID).Max() + 1;
            return RedirectToAction("Index");
        }

        // POST - recebe os dados alterados
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit (Instituicao instituicao)
        {
            instituicoes.Remove(instituicoes.Where(i => i.InstituicaoID == instituicao.InstituicaoID).First());
            instituicoes.Add(instituicao);
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            return View(instituicoes.Where(i => i.InstituicaoID == id).First());
        }

        public ActionResult Delete(int id)
        {
            return View(instituicoes.Where(i => i.InstituicaoID == id).First());
        }

        // POST: Instituicao/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var instituicao = await _context.Instituicoes.
                SingleOrDefaultAsync(m => m.InstituicaoID == id);

            _context.Instituicoes.Remove(instituicao);
            await _context.SaveChangesAsync();

            TempData["Message"] = "Instituição	" + 
                instituicao.Nome.ToUpper() + 
                "	foi	removida";

            return RedirectToAction(nameof(Index));
        }

        public ActionResult Delete(Instituicao instituicao)
        {
            instituicoes.Remove(instituicoes.Where(i => i.InstituicaoID == instituicao.InstituicaoID).First());
            return RedirectToAction("Index");
        }


        public IActionResult CriarInstituicao()
        {
            return View();
        }

        public IActionResult AlterarIntituicao(int id)
        {
            return View();
        }

        public IActionResult RemoverIntituicao(int id)
        {
            return View();
        }
    }
}
