using KndStore.Catalog.Core.Abstracts;
using KndStore.Shared.Core.Abstracts;
using Microsoft.AspNetCore.Mvc;

namespace KndStore.Catalog.Components;

public class NavigationMenuViewComponent : ViewComponent
{
    private readonly ICatalogRepo _repo;
    public NavigationMenuViewComponent(ICatalogRepo repo)
    {
        _repo = repo;
    }

    public IViewComponentResult Invoke(string? category)
    {
        var products = _repo.Query.Select(x => x.Category).Distinct().OrderBy(x => x);
        ViewBag.SelectedCategory = category;
        return View(products);
    }
}

