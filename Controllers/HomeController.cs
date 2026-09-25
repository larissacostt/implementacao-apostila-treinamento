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
        public IActionResult Error(int? statusCode = null)

        {
            if (statusCode.HasValue)
           {
               if (statusCode == 404 || statusCode == 500)
               {
                   var viewName = $"Error{statusCode.ToString()}";
                   return View(viewName);
               }
            }

           return View(new ErrorViewModel { 
               RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
