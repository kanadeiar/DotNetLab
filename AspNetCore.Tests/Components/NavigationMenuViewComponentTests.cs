using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewComponents;

namespace AspNetCore.Tests.Components;

public class NavigationMenuViewComponentTests
{
    [Fact]
    public void Can_Select_Categories()
    {
        var mock = new Mock<IStoreRepo>();
        mock.Setup(x => x.Products).Returns((new Product[] {
            new Product { Id = 1, Name = "Name1", Category = "Apples" },
            new Product { Id = 2, Name = "Name2", Category = "Apples" },
            new Product { Id = 3, Name = "Name3", Category = "Mini" },
            new Product { Id = 4, Name = "Name4", Category = "Violet" },
        }).AsQueryable());
        var target = new NavigationMenuViewComponent(mock.Object);
        
        var results = ((IEnumerable<string>)(target.Invoke() as ViewViewComponentResult)!.ViewData!.Model!)!.ToArray();

        Assert.True(Enumerable.SequenceEqual(new string[] { "Apples", "Mini", "Violet" }, results));
    }
    [Fact]
    public void Indicates_Selected_Category()
    {
        var categoryToSelect = "Apples";
        var mock = new Mock<IStoreRepo>();
        mock.Setup(x => x.Products).Returns((new Product[] {
            new Product { Id = 1, Name = "Name1", Category = "Apples" },
            new Product { Id = 2, Name = "Name2", Category = "Apples" },
            new Product { Id = 3, Name = "Name3", Category = "Mini" },
            new Product { Id = 4, Name = "Name4", Category = "Violet" },
        }).AsQueryable());
        var target = new NavigationMenuViewComponent(mock.Object);
        target.ViewComponentContext = new ViewComponentContext { ViewContext = new ViewContext { RouteData = new Microsoft.AspNetCore.Routing.RouteData()}};
        target.RouteData.Values["category"] = categoryToSelect;

        var result = (string)(target.Invoke() as ViewViewComponentResult)!.ViewData["SelectedCategory"];

        Assert.Equal(categoryToSelect, result);
    }
}