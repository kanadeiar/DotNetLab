using KndStore.Shared.Core.Abstracts;
using KndStore.ShopOrder.Core.Abstracts;
using KndStore.ShopOrder.Core.Entites;
using KndStore.ShopOrder.WebModels;
using Microsoft.AspNetCore.Mvc;

namespace KndStore.ShopOrder.Controllers;

public class OrderController : Controller
{
    private readonly IShopOrderRepo _repo;
    private readonly ISharedCart _cart;
    public OrderController(IShopOrderRepo repo, ISharedCart cart)
    {
        _repo = repo;
        _cart = cart;
    }

    public IActionResult Checkout()
    {
        return View(new OrderWebModel());
    }

    [HttpPost]
    public IActionResult Checkout(OrderWebModel model)
    {
        if (!_cart.GetLines().Any())
        {
            ModelState.AddModelError("", "Корзина пуста!");
        }
        if (ModelState.IsValid)
        {
            var lines = _cart.GetLines()
                .Select(x => new OrderLine
                {
                    ProductId = x.ProductId,
                    Quantity = x.Quantity,
                }).ToArray();
            var order = new Order
            {
                Lines = lines,
                Name = model.Name,
                Line1 = model.Line1,
                Line2 = model.Line2,
                Line3 = model.Line3,
                City = model.City,
                State = model.State,
                Country = model.Country,
                Zip = model.Zip,
                GiftWrap = model.GiftWrap,
            };
            _repo.AddOrder(order);
            _cart.Clear();
            return RedirectToAction("Complete", new { order.Id });
        }
        else
        {
            return View(model);
        }
    }

    public IActionResult Complete(int id)
    {
        var order = _repo.Orders.FirstOrDefault(x => x.Id == id);
        return View(order);
    }
}