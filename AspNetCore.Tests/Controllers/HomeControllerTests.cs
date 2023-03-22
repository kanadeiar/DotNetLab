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
        
        var model = (controller.Index(null) as ViewResult)?.ViewData.Model as ProductsListViewModel ?? new();

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
        
        var model = (controller.Index(null, 2) as ViewResult)?.ViewData.Model as ProductsListViewModel ?? new();

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

        var model = (controller.Index(null, 2) as ViewResult)?.ViewData.Model as ProductsListViewModel ?? new();

        var pagingInfo = model.PagingInfo;
        Assert.Equal(2, pagingInfo!.CurrentPage);
        Assert.Equal(3, pagingInfo.ItemsPerPage);
        Assert.Equal(5, pagingInfo.TotalCount);
        Assert.Equal(2, pagingInfo.TotalPages);
    }
    [Fact]
    public void Can_Filter_Products()
    {
        var mock = new Mock<IStoreRepo>();
        mock.Setup(x => x.Products).Returns((new Product[] { 
            new Product { Id = 1, Name = "Good1", Category = "Cat1" },
            new Product { Id = 2, Name = "Good2", Category = "Cat1" },
            new Product { Id = 3, Name = "Good3", Category = "Cat2" },
            new Product { Id = 4, Name = "Good4", Category = "Cat3" },
            new Product { Id = 5, Name = "Good5", Category = "Cat2" },
        }).AsQueryable());
        var controller = new HomeController(mock.Object) { PageSize = 3 };

        var model = (controller.Index("Cat2", 1) as ViewResult)?.ViewData.Model as ProductsListViewModel ?? new();
        var products = model.Products.ToArray();

        Assert.Equal(2, products.Length);
        Assert.True(products[0].Name == "Good3" && products[0].Category == "Cat2");
        Assert.True(products[1].Name == "Good5" && products[0].Category == "Cat2");
    }
    [Fact]
    public void Generate_Category_Specific_Product_Count()
    {
        var mock = new Mock<IStoreRepo>();
        mock.Setup(x => x.Products).Returns((new Product[] { 
            new Product { Id = 1, Name = "Good1", Category = "Cat1" },
            new Product { Id = 2, Name = "Good2", Category = "Cat1" },
            new Product { Id = 3, Name = "Good3", Category = "Cat2" },
            new Product { Id = 4, Name = "Good4", Category = "Cat3" },
            new Product { Id = 5, Name = "Good5", Category = "Cat2" },
        }).AsQueryable());
        var controller = new HomeController(mock.Object) { PageSize = 3 };
        Func<IActionResult, ProductsListViewModel?> GetModel = x => (x as ViewResult)?.ViewData?.Model as ProductsListViewModel;

        var res1 = GetModel(controller.Index("Cat1"))?.PagingInfo?.TotalCount;
        var res2 = GetModel(controller.Index("Cat2"))?.PagingInfo?.TotalCount;
        var res3 = GetModel(controller.Index("Cat3"))?.PagingInfo?.TotalCount;
        var resAll = GetModel(controller.Index(null))?.PagingInfo?.TotalCount;

        Assert.Equal(2, res1);
        Assert.Equal(2, res2);
        Assert.Equal(1, res3);
        Assert.Equal(5, resAll);
    }
}