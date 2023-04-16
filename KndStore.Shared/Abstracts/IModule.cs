using Microsoft.Extensions.DependencyInjection;

namespace KndStore.Shared.Abstracts;

public interface IModule
{
    IMvcBuilder RegisterModule(IMvcBuilder builder);
}

