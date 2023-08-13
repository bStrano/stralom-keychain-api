using ErrorOr;
using Keychain.Contracts.Responses.ShareableSecret;
using MediatR;

namespace Keychain.Application.ShareableSecret.Commands.Visualize;

public record VisualizeCommand(Guid Id, string? Password) : IRequest<ErrorOr<VisualizeSecretResponse>>;
