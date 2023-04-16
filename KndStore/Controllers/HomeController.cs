using Microsoft.AspNetCore.Mvc;

namespace KndStore.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}

