using Keychain.Application.Vault.Commands.Register;
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
        var userName = User.Identity; // Gets the user's name

        var command = _mapper.Map<RegisterCommand>(registerTemporarySecretDto);
        var commandResponse = await _mediator.Send(command);
        return commandResponse.Match(
            responseResult => Ok(responseResult),
            errors => Problem(errors));
    }

}
