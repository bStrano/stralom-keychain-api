using Keychain.Application.ShareableSecret.Commands.Register;
using Keychain.Contracts.DTOs.ShareableSecret;
using Keychain.Contracts.Responses.ShareableSecret;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ErrorOr;
using Keychain.Application.ShareableSecret.Commands.Visualize;

namespace Keychain_API.Controllers;

[ApiController]
[Route("shareable-secrets")]
public class ShareableSecretController: ApiController
{
    private readonly ISender _mediator;
    private readonly IMapper _mapper;

    public ShareableSecretController(ISender mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost("register")]
    public async Task<IActionResult> RegisterSecret(RegisterTemporarySecretDto registerTemporarySecretDto)
    {
        var command = _mapper.Map<RegisterCommand>(registerTemporarySecretDto);
        var commandResponse = await _mediator.Send(command);
        return commandResponse.Match(
            responseResult => Ok(responseResult),
            errors => Problem(errors));
    }


    [HttpPost("visualize/{id:guid}")]
    public async Task<IActionResult> GetDetail(Guid id, string? password)
    {
        var query = new VisualizeCommand(id, password);
        var commandResponse = await _mediator.Send(query);
        return commandResponse.Match(
            responseResult => Ok(_mapper.Map<VisualizeSecretResponse>(responseResult)),
            errors => Problem(errors));
    }
}
