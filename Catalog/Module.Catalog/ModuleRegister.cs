namespace Module.Catalog;

public class ModuleRegister : IModule
{
    public IMvcBuilder RegisterModule(IMvcBuilder builder)
    {
        var assembly = Assembly.GetExecutingAssembly();
        builder.AddApplicationPart(assembly);
        return builder;
    }
}

