namespace AspNetCore.Controllers;

public class OrderController : Controller
{
    private readonly IOrderRepo _repo;
    private readonly Cart _cart;
    public OrderController(IOrderRepo repo, Cart cart)
    {
        _repo = repo;
        _cart = cart;
    }
    public IActionResult Checkout()
    {
        return View(new Order());
    }
    [HttpPost]
    public IActionResult Checkout(Order order)
    {
        if (_cart.Lines.Count() == 0)
        {
            ModelState.AddModelError("", "Корзина пуста!");
        }
        if (ModelState.IsValid)
        {
            order.Lines = _cart.Lines.ToArray();
            _repo.SaveOrder(order);
            _cart.Clear();
            return RedirectToAction("Complete", new { Id = order.Id });
        }
        else
        {
            return View(order);
        }
    }
    public IActionResult Complete(int id)
    {
        var order = _repo.Orders.FirstOrDefault(x => x.Id == id);
        return View(order);
    }
}