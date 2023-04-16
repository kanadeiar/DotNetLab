namespace KndStore.Shared.Core.Abstracts;

public interface IRepo<out T> where T : IEntity
{
    IQueryable<T> Query { get; }
}

