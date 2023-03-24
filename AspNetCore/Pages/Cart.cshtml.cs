namespace AspNetCore.Pages;

public class CartModel : PageModel
{
    private IStoreRepo _repo;
    public CartModel(IStoreRepo repo)
    {
        _repo = repo;
    }
    public Cart? Cart { get; set; }
    public string ReturnUrl { get; set; } = "/";
    public void OnGet(string returnUrl)
    {
        ReturnUrl = returnUrl ?? "/";
        Cart = HttpContext.Session.GetJson<Cart>("cart");
        if (Cart is null)
        {
            Cart = new Cart();
        };
    }
    public IActionResult OnPost(int id, string returnUrl)
    {
        var product = _repo.Products.FirstOrDefault(x => x.Id == id);
        if (product != null)
        {
            Cart = HttpContext.Session.GetJson<Cart>("cart");
            if (Cart is null)
            {
                Cart = new Cart();
            };
            Cart.AddItem(product, 1);
            HttpContext.Session.SetJson("cart", Cart);
        }
        return RedirectToPage(new { returnUrl = returnUrl });
    }
}