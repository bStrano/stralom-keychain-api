using ErrorOr;
using Keychain.Contracts.Responses.ShareableSecret;
using MediatR;

namespace Keychain.Application.ShareableSecret.Commands.Register;

public record RegisterCommand(string Secret, int MaxViewCount, DateTime? ExpirationDate, string? Password) : IRequest<ErrorOr<RegisterTemporarySecretResponse>>;
