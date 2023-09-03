using ErrorOr;

namespace Keychain.Domain.Common.DomainErrors;

public static partial class Errors
{
    public static class Vault
    {
        public static Error NotFound(Guid id) =>
            Error.NotFound(
                "Vault.NotFound",
                $"Vault secret with id {id} was not found."
            );
    }
}
