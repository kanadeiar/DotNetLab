using KndStore.Catalog.Core.Entites;
using KndStore.Shared.Core.ViewModels;

namespace KndStore.Catalog.Core.ViewModels;

public class CatalogListViewModel
{
    public IEnumerable<Product> Products { get; set; } = Array.Empty<Product>();
    public PagingInfo? PagingInfo { get; set; }
}

