namespace KndStore.Cart.Components;

public class CartSummaryViewComponent : ViewComponent
{
    private readonly Core.Models.Cart _cart;
    public CartSummaryViewComponent(Core.Models.Cart cart)
    {
        _cart = cart;
    }

    public IViewComponentResult Invoke()
    {
        return View(_cart);
    }
}