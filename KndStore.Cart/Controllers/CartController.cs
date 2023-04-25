using KndStore.Cart.Core.ViewModels;
using KndStore.Shared.Core.Abstracts;

namespace KndStore.Cart.Controllers;

public class CartController : Controller
{
    private readonly ICatalogRepo _repo;
    private readonly Core.Models.Cart _cart;
    public CartController(ICatalogRepo repo, Core.Models.Cart cart)
    {
        _repo = repo;
        _cart = cart;
    }

    public IActionResult Index(string? returnUrl)
    {
        var model = new CartViewModel
        {
            Cart = _cart,
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
            _cart.AddItem(product, 1);
        }
        return RedirectToAction("Index", "Cart", new { returnUrl });
    }

    [HttpPost]
    public IActionResult Remove(int id, string? returnUrl)
    {
        var product = _repo.Query.FirstOrDefault(x => x.Id == id);
        if (product is { })
        {
            _cart.RemoveLine(product);
        }
        return RedirectToAction("Index", "Cart", new { returnUrl });
    }

    [HttpPost]
    public IActionResult Clear(string? returnUrl)
    {
        _cart.Clear();
        return RedirectToAction("Index", "Cart", new { returnUrl });
    }
}

