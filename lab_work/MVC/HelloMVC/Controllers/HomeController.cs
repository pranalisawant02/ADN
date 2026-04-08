using Microsoft.AspNetCore.Mvc;

namespace HelloMVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Message = "Welcome to ASP.NET Core MVC using VS Code!";
            return View();
        }

        
    }

    
}