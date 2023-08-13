using ErrorOr;
using Keychain.Contracts.Responses.ShareableSecret;
using MediatR;

namespace Keychain.Application.ShareableSecret.Queries.BaseInfo;

public record BaseInfoQuery(Guid Id) : IRequest<ErrorOr<BaseInfoSecretResponse>>;
