using KndStore.Catalog.Core.Abstracts;
using KndStore.Catalog.Core.ViewModels;
using KndStore.Shared.Core.Abstracts;
using KndStore.Shared.Core.WebModels;
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

    public async Task<IActionResult> Index(string? category, int productPage = 1)
    {
        var query = _repo.Query
            .Where(x => category == null || x.Category == category)
            .OrderBy(x => x.Id);
        var products = await query
            .Skip((productPage - 1) * PageSize)
            .Take(PageSize).ToArrayAsync();
        var model = new CatalogListViewModel
        {
            Products = products,
            PagingInfo = new PagingInfo
            {
                CurrentPage = productPage,
                ItemsPerPage = PageSize,
                TotalCount = query.Count(),
            },
            CurrentCategory = category,
        };
        return View(model);
    }
}

