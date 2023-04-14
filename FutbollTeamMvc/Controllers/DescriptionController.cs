using Microsoft.AspNetCore.Mvc;

namespace _21660110053NecatiKumdereli.Controllers
{
    public class DescriptionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
       public IActionResult Farkli()
        {
            return View("Farkli");
        }
    }
}
