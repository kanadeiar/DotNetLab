﻿using KndStore.Catalog.Core.Abstracts;
using KndStore.Catalog.Core.Entites;

namespace KndStore.Catalog.Core.Sources;

public class CatalogRepo : ICatalogRepo
{
    private readonly ICatalogDbContext _context;
    public CatalogRepo(ICatalogDbContext context)
    {
        _context = context;
    }

    public IQueryable<Product> Query => _context.Products;
    public void CreateProduct(Product p)
    {
        _context.Products.Add(p);
        _context.SaveChanges();
    }

    public void UpdateProduct(Product p)
    {
        _context.SaveChanges();
    }

    public void DeleteProduct(Product p)
    {
        _context.Products.Remove(p);
        _context.SaveChanges();
    }
}

