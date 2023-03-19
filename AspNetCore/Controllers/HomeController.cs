using AspNetCore.ViewModels;

namespace AspNetCore.Controllers;

public class HomeController : Controller
{
    private readonly IStoreRepo _repository;
    public int PageSize = 4;
    public HomeController(IStoreRepo repository)
    {
        _repository = repository;
    }
    public IActionResult Index(int productPage = 1) 
    {
        var model = new ProductsListViewModel
        {
            Products = _repository.Products
                .OrderBy(x => x.Id)
                .Skip((productPage - 1) * PageSize)
                .Take(PageSize),
            PagingInfo = new PagingInfo {
                CurrentPage = productPage,
                ItemsPerPage = PageSize,
                TotalCount = _repository.Products.Count(),
            }
        };
        return View(model);
    }
}