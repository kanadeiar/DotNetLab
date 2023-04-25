using System.Text.Json.Serialization;
using KndStore.Shared.Core.Entites;
using KndStore.Shared.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace KndStore.Cart.Models;

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
    public override void AddItem(Product product, int quantity)
    {
        base.AddItem(product, quantity);
        Session?.SetJson("cart", this);
    }
    public override void RemoveLine(Product product)
    {
        base.RemoveLine(product);
        Session?.SetJson("cart", this);
    }
    public override void Clear()
    {
        base.Clear();
        Session?.Remove("cart");
    }
}

