using Keychain.Application.Common.Interfaces.Persistence;
using Keychain.Domain.ShareableSecret;

namespace Keychain.Infrastructure.Persistence.Repositories;

public class ShareableSecretRepository : IShareableSecretRepository
{

    public ShareableSecret Detail(Guid id)
    {
        throw new NotImplementedException();
    }

    public void Register(ShareableSecret shareableSecret)
    {
        throw new NotImplementedException();
    }
}