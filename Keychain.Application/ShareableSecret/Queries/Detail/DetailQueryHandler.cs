using Keychain.Application.Common.Interfaces.Persistence;
using Keychain.Contracts.Responses.ShareableSecret;
using ErrorOr;
using Keychain.Application.ShareableSecret.Commands.Register;
using Keychain.Domain.Common.DomainErrors;
using MediatR;

namespace Keychain.Application.ShareableSecret.Queries.Detail;

public class DetailQueryHandler : IRequestHandler<DetailQuery, ErrorOr<DetailSecretResponse>>
{
    private readonly IShareableSecretRepository _repository;

    public DetailQueryHandler(IShareableSecretRepository repository)
    {
        _repository = repository;
    }

    public async Task<ErrorOr<DetailSecretResponse>> Handle(DetailQuery command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        var response = await this._repository.Detail(command.Id);

        if (response == null)
        {
            return Errors.ShareableSecret.NotFound(command.Id);
        }

        return new DetailSecretResponse(response.Id, response.ExpirationDate, response.MaxViewCount, response.Secret);
    }
}
