using MediatR;
using Module.Catalog.Core.Queries;

namespace Module.Catalog.Controllers;

public class BrandController : Controller
{
    private readonly IMediator _mediator;
    public BrandController(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<IActionResult> Index()
    {
        var brands = await _mediator.Send(new GetAllBrandsQuery());
        return View(brands);
    }
}

