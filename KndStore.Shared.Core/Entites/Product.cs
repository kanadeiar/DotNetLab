using System.ComponentModel.DataAnnotations.Schema;
using KndStore.Shared.Core.Abstracts;

namespace KndStore.Shared.Core.Entites;

public class Product : IProduct, IEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    [Column(TypeName = "decimal(8, 2)")]
    public decimal Price { get; set; }
}

