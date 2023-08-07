using ErrorOr;

namespace Keychain.Domain.Common.DomainErrors;

public static partial class Errors
{
    public static class ShareableSecret
    {
        public static Error NotFound(Guid id) =>
            Error.NotFound(
                "ShareableSecret.NotFound",
                $"Shareable secret with id {id} was not found."
            );
        public static Error PasswordRequired(Guid id) =>
            Error.Validation(
                "ShareableSecret.PasswordRequired",
                $"Shareable secret with id {id} requires a password."
            );
        public static Error PasswordNotMatch(Guid id) =>
            Error.Validation(
                "ShareableSecret.PasswordNotMatch",
                $"Invalid Password for shareable secret with id {id}."
            );
    }
}
