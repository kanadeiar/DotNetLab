namespace AspNetCore.Controllers;

public class HomeController : Controller
{
    private readonly IStoreRepository _repository;
    public HomeController(IStoreRepository repository)
    {
        _repository = repository;
    }
    public IActionResult Index() 
    {
        return View(_repository.Products);
    }
}