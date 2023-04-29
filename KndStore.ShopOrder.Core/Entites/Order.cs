using KndStore.Shared.Core.Abstracts;
using System.ComponentModel.DataAnnotations;

namespace KndStore.ShopOrder.Core.Entites;

public class Order : IEntity
{
    public int Id { get; set; }
    public ICollection<OrderLine> Lines { get; set; } = new List<OrderLine>();
    [Required]
    public string? Name { get; set; }
    [Required]
    public string? Line1 { get; set; }
    public string? Line2 { get; set; }
    public string? Line3 { get; set; }
    [Required]
    public string? City { get; set; }
    [Required]
    public string? State { get; set; }
    [Required]
    public string? Country { get; set; }
    public string? Zip { get; set; }
    public bool GiftWrap { get; set; }
}