using KndStore.Cart.Core.WebModels;
using KndStore.Shared.Core.Abstracts;

namespace KndStore.Cart.Controllers;

public class CartController : Controller
{
    private readonly IRepo<IProduct> _repo;
    private readonly Core.Models.Cart _cart;
    public CartController(IRepo<IProduct> repo, Core.Models.Cart cart)
    {
        _repo = repo;
        _cart = cart;
    }

    public IActionResult Index(string? returnUrl)
    {
        var products = _cart.Lines.Select(x =>
        {
            var product = _repo.Query.First(p => p.Id == x.ProductId);
            return new ProductWebModel
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Quantity = x.Quantity,
            };
        });
        var model = new CartWebModel
        {
            Products = products,
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
            _cart.AddItem(product.Id, 1);
        }
        return RedirectToAction("Index", "Cart", new { returnUrl });
    }

    [HttpPost]
    public IActionResult Remove(int id, string? returnUrl)
    {
        var product = _repo.Query.FirstOrDefault(x => x.Id == id);
        if (product is { })
        {
            _cart.RemoveLine(product.Id);
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

