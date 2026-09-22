using capitulo01.Data;
using capitulo01.Data.DAL.Discente;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Modelo.Discente;

namespace capitulo01.Areas.Discente.Controllers
{
<<<<<<< HEAD:Controllers/AcademicoController.cs
    [Area("Discente")]
=======

    [Area("Discente")]
    [Authorize]
>>>>>>> origin/capitulo07:Areas/Discente/Controllers/AcademicoController.cs
    public class AcademicoController : Controller
    {
        private readonly IESContext _context;
        private readonly AcademicoDAL academicoDAL;
        private IWebHostEnvironment _env;
        public AcademicoController(IESContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
            academicoDAL = new AcademicoDAL(context);
        }

        public async Task<IActionResult> Index()
        {
            return View(await academicoDAL
                .ObterAcademicosClassificadosPorNome()
                .ToListAsync());
        }

        public async Task<IActionResult> ObterVisaoAcademicoPorId(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var academico = await academicoDAL
                .ObterAcademicoPorId((long)id);

            if (academico == null)
            {
                return NotFound();
            }

            return View(academico);
        }

        public async Task<IActionResult> Details(long? id)
        {
            return await ObterVisaoAcademicoPorId(id);
        }

        public async Task<IActionResult> Edit(long? id)
        {
            return await ObterVisaoAcademicoPorId(id);
        }

        public async Task<IActionResult> Delete(long? id)
        {
            return await ObterVisaoAcademicoPorId(id);
        }

        // GET: Academico/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nome,RegistroAcademico,Nascimento")] Academico academico)
        {
            try
            {
                 if (ModelState.IsValid)
                {
                    await academicoDAL.GravarAcademico(academico);

                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    foreach (var item in ModelState)
                    {
                        foreach (var erro in item.Value.Errors)
                        {
                            Console.WriteLine(
                                $"{item.Key}: {erro.ErrorMessage}"
                            );
                        }
                    }
                }
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.InnerException?.Message);

                ModelState.AddModelError(
                    "",
                    "Não foi possível inserir os dados."
                );
            }

            return View(academico);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(
            long? id,
            [Bind("AcademicoID,Nome,RegistroAcademico,Nascimento")]
            Academico academico, IFormFile foto)
        {
            if (id != academico.AcademicoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var stream = new MemoryStream();
                    await foto.CopyToAsync(stream);
                    academico.FotoMimeType = foto.ContentType;
                    academico.Foto = stream.ToArray();

                    await academicoDAL.GravarAcademico(academico);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await AcademicoExists(academico.AcademicoID))
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

            return View(academico);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long? id)
        {
            var academico =
                await academicoDAL.EliminarAcademicoPorId((long)id);

            TempData["Message"] =
                "Acadêmico " + academico.Nome.ToUpper() + " foi removido";

            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> AcademicoExists(long? id)
        {
            return await academicoDAL
                .ObterAcademicoPorId((long)id) != null;
        }

        public async Task<FileContentResult> GetFoto(long id)
        {
            Academico academico = await academicoDAL.ObterAcademicoPorId(id);
            if (academico != null)
            {
                return File(academico.Foto, academico.FotoMimeType);
            }
            return null;
        }

        public async Task<FileResult> DownloadFoto(long id)
        {
            Academico academico = await academicoDAL.ObterAcademicoPorId(id);
            
            string nomeArquivo = "Foto" + academico.AcademicoID.ToString().Trim() + ".jpg";
            FileStream fileStream = new FileStream(System.IO.Path.Combine(_env.WebRootPath, nomeArquivo), FileMode.Create, FileAccess.Write);
            fileStream.Write(academico.Foto, 0, academico.Foto.Length);
            fileStream.Close();
            IFileProvider provider = new PhysicalFileProvider(_env.WebRootPath);
            IFileInfo fileInfo = provider.GetFileInfo(nomeArquivo);
            var readStream = fileInfo.CreateReadStream();
            return File(readStream, academico.FotoMimeType, nomeArquivo);
        }
    }
}