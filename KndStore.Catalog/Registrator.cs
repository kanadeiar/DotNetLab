using System.Reflection;
using KndStore.Shared.Abstracts;
using Microsoft.Extensions.DependencyInjection;

namespace KndStore.Catalog;

public class Registrator : IModule
{
    public IMvcBuilder RegisterModule(IMvcBuilder builder)
    {
        var assembly = Assembly.GetExecutingAssembly();
        builder.AddApplicationPart(assembly);
        return builder;
    }
}

