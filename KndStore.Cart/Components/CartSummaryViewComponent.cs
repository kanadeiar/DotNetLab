using KndStore.Cart.Core.WebModels;
using KndStore.Shared.Core.Abstracts;

namespace KndStore.Cart.Components;

public class CartSummaryViewComponent : ViewComponent
{
    private readonly IRepo<IProduct> _repo;
    private readonly Core.Models.Cart _cart;
    public CartSummaryViewComponent(IRepo<IProduct> repo, Core.Models.Cart cart)
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