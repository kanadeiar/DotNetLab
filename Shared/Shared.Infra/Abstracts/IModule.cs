namespace Shared.Infra.Abstracts;

public interface IModule
{
    IMvcBuilder RegisterModule(IMvcBuilder builder);
}

