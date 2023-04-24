using System.ComponentModel.DataAnnotations.Schema;

namespace KndStore.Shared.Core.Abstracts;

public interface IProduct
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Category { get; set; }
    [Column(TypeName = "decimal(8, 2)")]
    public decimal Price { get; set; }
}

