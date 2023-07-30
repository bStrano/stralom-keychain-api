using Keychain.Application.Common.Interfaces.Persistence;
using Keychain.Contracts.Responses.ShareableSecret;
using MediatR;
using ErrorOr;

namespace Keychain.Application.ShareableSecret.Commands.Register;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, ErrorOr<RegisterTemporarySecretResponse>>
{
    private readonly IShareableSecretRepository _repository;

    public RegisterCommandHandler(IShareableSecretRepository repository)
    {
        _repository = repository;
    }

    public async Task<ErrorOr<RegisterTemporarySecretResponse>> Handle(RegisterCommand command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        var shareableSecret = new Domain.ShareableSecret.ShareableSecret
        {
            Id = Guid.NewGuid(),
            Secret = command.Secret,
            Password = command.Password,
            ExpirationDate = DateTime.Now,
            ViewCount = command.ViewCount,
        };
        this._repository.Register(shareableSecret);
        return new RegisterTemporarySecretResponse(shareableSecret.Id, shareableSecret.ExpirationDate, command.ViewCount, command.Secret, command.Password );
    }
}