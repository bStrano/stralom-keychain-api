using Keychain.Application.ShareableSecret.Commands.Register;
using Keychain.Application.ShareableSecret.Queries.Detail;
using Keychain.Contracts.DTOs.ShareableSecret;
using Keychain.Contracts.Responses.ShareableSecret;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ErrorOr;

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


    [HttpPost("detail/{id:guid}")]
    public async Task<IActionResult> GetDetail(Guid id, string? password)
    {
        var query = new DetailQuery(id, password);
        var commandResponse = await _mediator.Send(query);
        return commandResponse.Match(
            responseResult => Ok(_mapper.Map<DetailSecretResponse>(responseResult)),
            errors => Problem(errors));
    }
}
