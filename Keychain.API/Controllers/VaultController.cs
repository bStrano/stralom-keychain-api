using Keychain.Application.Vault.Commands.Register;
using Keychain.Application.Vault.Queries.Detail;
using Keychain.Application.Vault.Queries.FindAllBaseInfo;
using Keychain.Contracts.DTOs.Vault;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Keychain_API.Controllers;

[ApiController]
[Route("vault")]
public class VaultController: ApiController
{
    private readonly ISender _mediator;
    private readonly IMapper _mapper;

    public VaultController(ISender mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost("secrets")]
    public async Task<IActionResult> RegisterSecret(RegisterSecretDto registerTemporarySecretDto)
    {
        var userId = GetUserId();

        var command = new RegisterCommand(
            registerTemporarySecretDto.UserName,
            registerTemporarySecretDto.Password,
            registerTemporarySecretDto.Title,
            registerTemporarySecretDto.Subtitle,
            userId
            );
        var commandResponse = await _mediator.Send(command);
        return commandResponse.Match(
            responseResult => Ok(responseResult),
            errors => Problem(errors));
    }

    [HttpGet("secrets")]
    public async Task<IActionResult> FindAllSecrets()
    {
        var userId = GetUserId();

        var query = new FindAllBaseInfoQuery(
            userId
        );
        var commandResponse = await _mediator.Send(query);
        return commandResponse.Match(
            responseResult => Ok(responseResult),
            errors => Problem(errors));
    }

    [HttpGet("secrets/detail/{id:guid}")]
    public async Task<IActionResult> Detail(Guid id)
    {
        var userId = GetUserId();

        var query = new DetailQuery(
            id,
            userId
        );
        var commandResponse = await _mediator.Send(query);
        return commandResponse.Match(
            responseResult => Ok(responseResult),
            errors => Problem(errors));
    }
}
