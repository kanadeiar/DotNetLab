using MediatR;
using Microsoft.EntityFrameworkCore;
using Module.Catalog.Core.Abstracts;

namespace Module.Catalog.Core.Queries;

public class GetAllBrandsQuery : IRequest<IEnumerable<Brand>>
{
}

internal class GetAllBrandsQueryHandler : IRequestHandler<GetAllBrandsQuery, IEnumerable<Brand>>
{
    private readonly ICatalogDbContext _context;
    public GetAllBrandsQueryHandler(ICatalogDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Brand>> Handle(GetAllBrandsQuery request, CancellationToken cancellationToken)
    {
        var brands = await _context.Brands.OrderBy(x => x.Id).ToArrayAsync();
        if (brands == null) throw new Exception("Brands Not Found!");
        return brands;
    }
}

