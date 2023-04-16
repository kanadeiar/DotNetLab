using KndStore.Catalog.Core.Abstracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KndStore.Catalog.Controllers;

public class CatalogController : Controller
{
    private readonly ICatalogRepo _repo;
    public CatalogController(ICatalogRepo repo)
    {
        _repo = repo;
    }

    public async Task<IActionResult> Index()
    {
        var products = await _repo.Query.ToArrayAsync();
        return View(products);
    }
}

