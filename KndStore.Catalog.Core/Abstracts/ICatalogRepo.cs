using KndStore.Catalog.Core.Entites;
using KndStore.Shared.Core.Abstracts;

namespace KndStore.Catalog.Core.Abstracts;

public interface ICatalogRepo : IRepo<Product>
{
    void CreateProduct(Product p);
    void UpdateProduct(Product p);
    void DeleteProduct(Product p);
}

