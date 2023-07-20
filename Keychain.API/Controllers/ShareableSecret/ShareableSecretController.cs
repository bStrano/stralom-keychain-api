using Keychain.Application.Services.ShareableSecret;
using Keychain.Contracts.DTOs.ShareableSecret;

namespace Keychain_API.Controllers.ShareableSecret;

using Keychain_API.Contracts.Responses.ShareableSecret;
using Microsoft.AspNetCore.Mvc;


[ApiController]
[Route("secrets")]
public class ShareableSecretController: ControllerBase
{
    private readonly IShareableSecretService _shareableSecretService;

    public ShareableSecretController(IShareableSecretService shareableSecretService)
    {
        _shareableSecretService = shareableSecretService;
    }

    [HttpPost("register")]
    public RegisterTemporarySecretResponse RegisterSecret(RegisterTemporarySecretDto registerTemporarySecretDto)
    {
        return this._shareableSecretService.RegisterTemporarySecret(registerTemporarySecretDto);
    }
}