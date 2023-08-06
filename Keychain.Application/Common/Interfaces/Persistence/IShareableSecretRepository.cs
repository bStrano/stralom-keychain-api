namespace Keychain.Application.Common.Interfaces.Persistence;

public interface IShareableSecretRepository
{
    Task<Domain.ShareableSecret.ShareableSecret?> Detail(Guid id);
    Task Register(Domain.ShareableSecret.ShareableSecret shareableSecret);
}
