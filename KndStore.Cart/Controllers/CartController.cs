using KndStore.Cart.Core.ViewModels;
using KndStore.Shared.Core.Abstracts;
using KndStore.Shared.Extensions;

namespace KndStore.Cart.Controllers;

public class CartController : Controller
{
    private readonly ICatalogRepo _repo;
    public CartController(ICatalogRepo repo)
    {
        _repo = repo;
    }

    public IActionResult Index(string? returnUrl)
    {
        var cart = HttpContext.Session.GetJson<Core.Models.Cart>("cart") ?? new Core.Models.Cart();
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
        var product = _repo.Query.FirstOrDefault(x => x.Id == id);
        if (product is { })
        {
            var cart = HttpContext.Session.GetJson<Core.Models.Cart>("cart") ?? new Core.Models.Cart();
            cart.AddItem(product, 1);
            HttpContext.Session.SetJson("cart", cart);
        }
        return RedirectToAction("Index", "Cart", new { returnUrl = returnUrl });
    }
}

