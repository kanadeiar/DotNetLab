using Microsoft.Extensions.DependencyInjection;

namespace KndStore.Shared.Abstracts;

public abstract class Module<T> : IModule where T : IModule
{
    public IMvcBuilder RegisterModule(IMvcBuilder builder)
    {
        var assembly = typeof(T).Assembly;
        builder.AddApplicationPart(assembly);
        return builder;
    }
}

