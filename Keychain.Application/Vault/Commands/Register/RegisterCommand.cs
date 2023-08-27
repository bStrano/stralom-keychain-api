using ErrorOr;
using Keychain.Contracts.Responses.Vault;
using MediatR;

namespace Keychain.Application.Vault.Commands.Register;

public record RegisterCommand
(
    string UserName,
    string Password,
    string Title,
    string Subtitle,
    int UserId
): IRequest<ErrorOr<RegisterSecretResponse>>;
