namespace Keychain.Application.Common.Interfaces.Persistence;
using Domain.ShareableSecret;

public interface IShareableSecretRepository
{
    Task<ShareableSecret?> Detail(Guid id);
    Task Register(ShareableSecret shareableSecret);
    Task Update(ShareableSecret shareableSecret);

}
