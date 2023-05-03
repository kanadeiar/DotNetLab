namespace KndStore.Shared.Core.Abstracts;

public interface ISharedCart
{
    IEnumerable<ICartLine> GetLines();
    void Clear();
}