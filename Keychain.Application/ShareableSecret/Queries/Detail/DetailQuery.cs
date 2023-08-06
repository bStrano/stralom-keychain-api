using Keychain.Contracts.Responses.ShareableSecret;
using MediatR;
using ErrorOr;

namespace Keychain.Application.ShareableSecret.Queries.Detail;

public record DetailQuery(Guid Id) : IRequest<ErrorOr<DetailSecretResponse>>;
