using KndStore.Shared.Core.Abstracts;
using KndStore.ShopCart.Core.WebModels;

namespace KndStore.ShopCart.Components;

public class CartSummaryViewComponent : ViewComponent
{
    private readonly IRepo<IProduct> _repo;
    private readonly ShopCart.Core.Models.Cart _cart;
    public CartSummaryViewComponent(IRepo<IProduct> repo, ShopCart.Core.Models.Cart cart)
    {
        _repo = repo;
        _cart = cart;
    }

    public IViewComponentResult Invoke()
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
        };
        return View(model);
    }
}