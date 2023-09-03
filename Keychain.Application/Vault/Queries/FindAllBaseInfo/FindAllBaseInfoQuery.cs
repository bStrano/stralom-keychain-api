using ErrorOr;
using Keychain.Contracts.Responses.Vault;
using MediatR;

namespace Keychain.Application.Vault.Queries.FindAllBaseInfo;

public record FindAllBaseInfoQuery(int UserId) : IRequest<ErrorOr<List<FindAllBaseInfoResponse>>>;
