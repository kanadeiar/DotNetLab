namespace AspNetCore.Abstracts;

public interface IOrderRepo
{
    IQueryable<Order> Orders { get; }
    void SaveOrder(Order order);
}