using System.Text.Json.Serialization;
using KndStore.Shared.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace KndStore.ShopCart.Models;

public class SessionCart : Core.Models.Cart
{
    [JsonIgnore]
    public ISession? Session { get; set; }
    public static Core.Models.Cart GetCart(IServiceProvider services)
    {
        ISession? session = services?.GetRequiredService<IHttpContextAccessor>()?.HttpContext?.Session;
        var cart = session?.GetJson<SessionCart>("cart") ?? new SessionCart();
        cart.Session = session;
        return cart;
    }
    public override void AddItem(int productId, int quantity)
    {
        base.AddItem(productId, quantity);
        Session?.SetJson("cart", this);
    }
    public override void RemoveLine(int productId)
    {
        base.RemoveLine(productId);
        Session?.SetJson("cart", this);
    }
    public override void Clear()
    {
        base.Clear();
        Session?.Remove("cart");
    }
}

