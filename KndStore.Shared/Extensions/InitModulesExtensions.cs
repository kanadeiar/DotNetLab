using Microsoft.Extensions.DependencyInjection;
using KndStore.Shared.Abstracts;

namespace KndStore.Shared.Extensions;

public static class InitModulesExtensions
{
    static readonly IList<IModule> _registeredModules = new List<IModule>();

    public static IMvcBuilder RegisterModules(this IMvcBuilder services)
    {
        var modules = DiscoverModules().ToArray();
        foreach (var module in modules)
        {
            module.RegisterModule(services);
            _registeredModules.Add(module);
        }
        return services;
    }

    private static IEnumerable<IModule> DiscoverModules()
    {
        var modules = AppDomain
            .CurrentDomain
        .GetAssemblies()
        .SelectMany(a => a.GetTypes())
            .Where(x => x.IsAssignableTo(typeof(IModule)) && x is { IsClass: true, IsAbstract: false })
            .Select(Activator.CreateInstance)
            .Cast<IModule>();
        return modules;
    }
}

