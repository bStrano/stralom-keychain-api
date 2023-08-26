namespace Keychain.Application.Common.Interfaces.Persistence;
using Domain.Secret;

public interface ISecretRepository
{
    Task Register(Secret secret);
}
