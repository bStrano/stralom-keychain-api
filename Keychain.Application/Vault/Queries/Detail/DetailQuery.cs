using MediatR;
using ErrorOr;
using Keychain.Contracts.Responses.Vault;

namespace Keychain.Application.Vault.Queries.Detail;

public record DetailQuery(Guid Id, int UserId) : IRequest<ErrorOr<DetailResponse>>;
