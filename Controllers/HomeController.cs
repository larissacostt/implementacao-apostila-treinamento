using capitulo01.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace capitulo01.Controllers
{
    public class HomeController : Controller
    {
        //Definição	de	uma	action	chamada	Index
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        [Route("Home/Error/{id?}")]
        public IActionResult Error(int? id)
        {
            if (id == 404)
            {
                ViewBag.ErrorMessage = "A página ou recurso solicitado não foi encontrado.";
                ViewBag.StatusCode = 404;
                return View("NotFound"); // Vai procurar a View NotFound.cshtml
            }
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
