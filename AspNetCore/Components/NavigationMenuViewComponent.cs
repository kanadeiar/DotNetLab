namespace AspNetCore.Components;

public class NavigationMenuViewComponent : ViewComponent
{
    private readonly IStoreRepo _repo;
    public NavigationMenuViewComponent(IStoreRepo repo)
    {
        _repo = repo;
    }
    public IViewComponentResult Invoke()
    {
        var products = _repo.Products.Select(x => x.Category).Distinct().OrderBy(x => x);
        ViewBag.SelectedCategory = RouteData?.Values["category"];
        return View(products);
    }
}