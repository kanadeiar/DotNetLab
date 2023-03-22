namespace AspNetCore.Controllers;

public class HomeController : Controller
{
    private readonly IStoreRepo _repository;
    public int PageSize = 4;
    public HomeController(IStoreRepo repository)
    {
        _repository = repository;
    }
    public IActionResult Index(string? category, int productPage = 1) 
    {
        var products = _repository.Products
            .Where(x => category == null || x.Category == category)
            .OrderBy(x => x.Id);
        var model = new ProductsListViewModel
        {
            Products = products
                .Skip((productPage - 1) * PageSize)
                .Take(PageSize).ToArray(),
            PagingInfo = new PagingInfo {
                CurrentPage = productPage,
                ItemsPerPage = PageSize,
                TotalCount = products.Count(),
            }
        };
        return View(model);
    }
}