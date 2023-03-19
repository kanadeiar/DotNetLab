using AspNetCore.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCore.Tests.Controllers;

public class HomeControllerTests
{
    [Fact]
    public void Can_Use_Repository()
    {
        var expecteds = new Product[] {
            new Product { Id = 1, Name = "Имя1" },
            new Product { Id = 2, Name = "Имя2" },
        };
        var mock = new Mock<IStoreRepo>();
        mock.Setup(x => x.Products).Returns(expecteds.AsQueryable<Product>());
        var controller = new HomeController(mock.Object);
        
        var model = (controller.Index() as ViewResult)?.ViewData.Model as ProductsListViewModel ?? new();

        var products = model.Products.ToArray();
        Assert.True(products.Length == 2);
        Assert.Equal(expecteds[0].Name, products[0].Name);
        Assert.Equal(expecteds[1].Name, products[1].Name);
    }
    [Fact]
    public void Can_Paginate()
    {
        var expecteds = new Product[] {
            new Product { Id = 1, Name = "Имя1" },
            new Product { Id = 2, Name = "Имя2" },
            new Product { Id = 3, Name = "Имя3" },
            new Product { Id = 4, Name = "Имя4" },
        };
        var mock = new Mock<IStoreRepo>();
        mock.Setup(x => x.Products).Returns(expecteds.AsQueryable<Product>());
        var controller = new HomeController(mock.Object) { PageSize = 2 };
        
        var model = (controller.Index(2) as ViewResult)?.ViewData.Model as ProductsListViewModel ?? new();

        var products = model.Products.ToArray();
        Assert.True(products.Length == 2);
        Assert.Equal(expecteds[2].Name, products[0].Name);
        Assert.Equal(expecteds[3].Name, products[1].Name);
    }
    [Fact]
    public void Can_Send_Pagination_ViewModel()
    {
        var mock = new Mock<IStoreRepo>();
        mock.Setup(x => x.Products).Returns((new Product[] { 
            new Product { Id = 1, Name = "Good1" },
            new Product { Id = 2, Name = "Good2" },
            new Product { Id = 3, Name = "Good3" },
            new Product { Id = 4, Name = "Good4" },
            new Product { Id = 5, Name = "Good5" },
        }).AsQueryable());
        var controller = new HomeController(mock.Object) { PageSize = 3 };

        var model = (controller.Index(2) as ViewResult)?.ViewData.Model as ProductsListViewModel ?? new();

        var pagingInfo = model.PagingInfo;
        Assert.Equal(2, pagingInfo.CurrentPage);
        Assert.Equal(3, pagingInfo.ItemsPerPage);
        Assert.Equal(5, pagingInfo.TotalCount);
        Assert.Equal(2, pagingInfo.TotalPages);
    }
}