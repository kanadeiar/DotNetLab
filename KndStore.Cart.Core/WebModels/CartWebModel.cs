using KndStore.Shared.Core.Abstracts;

namespace KndStore.Cart.Core.WebModels;

public class CartWebModel
{
    public Models.Cart? Cart { get; set; }
    public IEnumerable<ProductWebModel> Products { get; set; } = Enumerable.Empty<ProductWebModel>();
    public string? ReturnUrl { get; set; }
    public decimal ComputeTotalSum()
    {
        return Products.Sum(x => x.Price * x.Quantity);
    }
}

