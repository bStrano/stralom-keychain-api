namespace Keychain.Application.Common.Interfaces.Persistence;

public interface IShareableSecretRepository
{
    Domain.ShareableSecret.ShareableSecret Detail(Guid id);
    void Register(Domain.ShareableSecret.ShareableSecret shareableSecret);
}