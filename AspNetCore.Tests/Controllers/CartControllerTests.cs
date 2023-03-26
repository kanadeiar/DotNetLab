namespace AspNetCore.Tests;

public class CartControllerTests
{
    [Fact]
    public void Can_Load_Cart()
    {
        var p1 = new Product { Id = 1, Name = "P1" };
        var p2 = new Product { Id = 2, Name = "P2" };
        var mockRepo = new Mock<IStoreRepo>();
        mockRepo.Setup(x => x.Products).Returns((new Product[] { p1, p2 }).AsQueryable());
        var testCart = new Cart();
        testCart.AddItem(p1, 2);
        testCart.AddItem(p2, 1);
        var controller = new CartController(mockRepo.Object, testCart);

        var model = (controller.Index("myUrl") as ViewResult)?.ViewData.Model as CartViewModel ?? new();

        Assert.Equal(2, model.Cart.Lines.Count());
        Assert.Equal("myUrl", model.ReturnUrl);
    }    
    [Fact]
    public void Can_Add_Item()
    {
        var mockRepo = new Mock<IStoreRepo>();
        mockRepo.Setup(x => x.Products).Returns((new Product[] { new Product { Id = 1, Name = "P1" } }).AsQueryable());
        var testCart = new Cart();
        var controller = new CartController(mockRepo.Object, testCart);

        var redirect = (controller.Add(1, "myUrl") as RedirectToActionResult);

        Assert.Equal("Index", redirect.ActionName);
        Assert.Equal("myUrl", redirect.RouteValues.FirstOrDefault().Value);
        Assert.Single(testCart.Lines);
        Assert.Equal("P1", testCart.Lines.First().Product.Name);
        Assert.Equal(1, testCart.Lines.First().Quantity);
    }
    [Fact]
    public void Can_Remove_Item()
    {
        var p1 = new Product { Id = 1, Name = "P1" };
        var p2 = new Product { Id = 2, Name = "P2" };
        var mockRepo = new Mock<IStoreRepo>();
        mockRepo.Setup(x => x.Products).Returns((new Product[] { p1, p2 }).AsQueryable());
        var testCart = new Cart();
        testCart.AddItem(p1, 2);
        testCart.AddItem(p2, 1);
        var controller = new CartController(mockRepo.Object, testCart);

        var redirect = (controller.Remove(1, "myUrl") as RedirectToActionResult);

        Assert.Equal("Index", redirect.ActionName);
        Assert.Equal("myUrl", redirect.RouteValues.FirstOrDefault().Value);
        Assert.Single(testCart.Lines);
        Assert.Equal("P2", testCart.Lines.First().Product.Name);
        Assert.Equal(1, testCart.Lines.First().Quantity);
    }
    [Fact]
    public void Can_Clear_Items()
    {
        var p1 = new Product { Id = 1, Name = "P1" };
        var p2 = new Product { Id = 2, Name = "P2" };
        var mockRepo = new Mock<IStoreRepo>();
        mockRepo.Setup(x => x.Products).Returns((new Product[] { p1, p2 }).AsQueryable());
        var testCart = new Cart();
        testCart.AddItem(p1, 2);
        testCart.AddItem(p2, 1);
        var controller = new CartController(mockRepo.Object, testCart);

        var redirect = (controller.Clear("myUrl") as RedirectToActionResult);

        Assert.Equal("Index", redirect.ActionName);
        Assert.Equal("myUrl", redirect.RouteValues.FirstOrDefault().Value);
        Assert.Empty(testCart.Lines);
    }
}