using ErrorOr;

namespace Keychain.Domain.Common.DomainErrors;

public static partial class Errors
{
    public static class ShareableSecret
    {
        public static Error NotFound(Guid id) =>
            Error.Validation(
                "ShareableSecret.NotFound",
                $"Shareable secret with id {id} was not found."
            );
    }
}
