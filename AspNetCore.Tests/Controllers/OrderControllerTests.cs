namespace AspNetCore.Tests.Controllers;

public class OrderControllerTests
{
    [Fact]
    public void Cannot_Checkout_Empty_Cart()
    {
        var mock = new Mock<IOrderRepo>();
        var cart = new Cart();
        var order = new Order();
        var controller = new OrderController(mock.Object, cart);

        var result = controller.Checkout(order) as ViewResult;

        mock.Verify(x => x.SaveOrder(It.IsAny<Order>()), Times.Never);
        Assert.True(string.IsNullOrEmpty(result.ViewName));
        Assert.False(result.ViewData.ModelState.IsValid);
    }
    [Fact]
    public void Cannot_Checkout_Invalid_ShippingDetails()
    {
        var mock = new Mock<IOrderRepo>();
        var cart = new Cart();
        cart.AddItem(new Product(), 1);
        var controller = new OrderController(mock.Object, cart);
        controller.ModelState.AddModelError("", "error");

        var result = controller.Checkout(new Order()) as ViewResult;

        mock.Verify(x => x.SaveOrder(It.IsAny<Order>()), Times.Never);
        Assert.True(string.IsNullOrEmpty(result.ViewName));
        Assert.False(result.ViewData.ModelState.IsValid);
    }
    [Fact]
    public void Can_Checkout_And_Submit_Order()
    {
        var mock = new Mock<IOrderRepo>();
        var cart = new Cart();
        cart.AddItem(new Product(), 1);
        var controller = new OrderController(mock.Object, cart);

        var result = controller.Checkout(new Order()) as RedirectToActionResult;

        mock.Verify(x => x.SaveOrder(It.IsAny<Order>()), Times.Once);
        Assert.Equal("Complete", result.ActionName);
    }
}