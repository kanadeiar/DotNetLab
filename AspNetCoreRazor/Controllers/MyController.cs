using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreRazor.Controllers;

public class MyController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}

