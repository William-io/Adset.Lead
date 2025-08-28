using Adset.Lead.Application.Automobiles.CreateAutomobile;
using Adset.Lead.Domain.Automobiles;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Adset.Lead.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AutomobilesController : ControllerBase
{
    private readonly ISender _sender;

    public AutomobilesController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAutomobile(
        [FromBody] CreateAutomobileRequest request,
        CancellationToken cancellationToken)
    {
        var command = new CreateAutomobileCommand(
            Brand: request.Brand,
            Model: request.Model,
            Year: request.Year,
            Plate: request.Plate,
            Color: request.Color,
            Price: request.Price,
            Km: request.Km,
            Portal: request.Portal,
            Package: request.Package,
            OptionalFeatures: request.OptionalFeatures,
            PhotoUrls: request.PhotoUrls);

        var result = await _sender.Send(command, cancellationToken);

        if (result.IsFailure)
        {
            return BadRequest(new
            {
                Error = result.Error.Code,
                Message = result.Error.Name
            });
        }

        return CreatedAtAction(
            nameof(GetAutomobile),
            new { id = result.Value },
            new { Id = result.Value });
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetAutomobile(Guid id)
    {
        // Placeholder para implementação futura do Query
        return Ok(new { Id = id, Message = "Get automobile implementation pending" });
    }
}
