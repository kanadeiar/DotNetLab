namespace AspNetCore.Components;

public class CartSummaryViewComponent : ViewComponent
{
    private Cart _cart;
    public CartSummaryViewComponent(Cart service)
    {
        _cart = service;
    }
    public IViewComponentResult Invoke()
    {
        return View(_cart);
    }
}