namespace KndStore.Shared.Core.Abstracts;

public interface ICartLine : IEntity
{
    int ProductId { get; set; }
    int Quantity { get; set; }
}