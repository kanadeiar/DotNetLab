using Microsoft.AspNetCore.Mvc;

namespace KndStore.Catalog.Controllers;

public class CatalogController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}

