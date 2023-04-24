namespace KndStore.Cart.Controllers;

public class CartController : Controller
{
    public CartController()
    {
        
    }
    public IActionResult Index()
    {
        return View();
    }
}

