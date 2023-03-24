namespace AspNetCore.Controllers;

public class CartController : Controller
{
    private readonly IStoreRepo _repo;
    public CartController(IStoreRepo repo)
    {
        _repo = repo;
    }
    public IActionResult Index(string? returnUrl)
    {
        var cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
        var model = new CartViewModel
        {
            Cart = cart,
            ReturnUrl = returnUrl,
        };
        return View(model);
    }
    [HttpPost]
    public IActionResult Add(int id, string? returnUrl)
    {
        var product = _repo.Products.FirstOrDefault(x => x.Id == id);
        if (product is { })
        {
            var cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
            cart.AddItem(product, 1);
            HttpContext.Session.SetJson("cart", cart);
        }
        return RedirectToAction("Index", "Cart", new { returnUrl = returnUrl });
    }
}