using System.ComponentModel.DataAnnotations.Schema;

namespace KndStore.ShopCart.Core.WebModels;

public class ProductWebModel
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    [Column(TypeName = "decimal(8, 2)")]
    public decimal Price { get; set; }
    public int Quantity { get; set; }
}