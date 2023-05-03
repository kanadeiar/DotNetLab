using KndStore.Shared.Core.Abstracts;
using KndStore.Shared.Core.WebModels;

namespace KndStore.Catalog.Core.ViewModels;

public class CatalogListViewModel
{
    public IEnumerable<IProduct> Products { get; set; } = Array.Empty<IProduct>();
    public PagingInfo? PagingInfo { get; set; }
    public string? CurrentCategory { get; set; }
}

