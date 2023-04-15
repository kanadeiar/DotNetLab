using MediatR;
using Microsoft.EntityFrameworkCore;
using Module.Catalog.Core.Abstracts;

namespace Module.Catalog.Core.Commands;

public class AddBrandCommand : IRequest<int>
{
    public string Name { get; set; }
    public string Detail { get; set; }
}

internal class AddBrandCommandHandler : IRequestHandler<AddBrandCommand, int>
{
    private readonly ICatalogDbContext _context;
    public AddBrandCommandHandler(ICatalogDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(AddBrandCommand request, CancellationToken cancellationToken)
    {
        if (await _context.Brands.AnyAsync(c => c.Name == request.Name, cancellationToken))
        {
            throw new Exception("Brand with the same name already exists.");
        }
        var brand = new Brand { Detail = request.Detail, Name = request.Name };
        await _context.Brands.AddAsync(brand, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return brand.Id;
    }
}

