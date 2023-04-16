using KndStore.Catalog.Core.Abstracts;
using KndStore.Catalog.Core.ViewModels;
using KndStore.Shared.Core.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KndStore.Catalog.Controllers;

public class CatalogController : Controller
{
    private readonly ICatalogRepo _repo;
    public int PageSize { get; set; } = 5;
    public CatalogController(ICatalogRepo repo)
    {
        _repo = repo;
    }

    public async Task<IActionResult> Index(int productPage = 1)
    {
        var products = await _repo.Query.OrderBy(x => x.Id).Skip((productPage - 1) * PageSize).Take(PageSize).ToArrayAsync();
        var model = new CatalogListViewModel
        {
            Products = products,
            PagingInfo = new PagingInfo
            {
                CurrentPage = productPage,
                ItemsPerPage = PageSize,
                TotalCount = _repo.Query.Count(),
            },
        };
        return View(model);
    }
}

