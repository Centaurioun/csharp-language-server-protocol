using System;
using System.Diagnostics;

namespace OmniSharp.Extensions.LanguageServer.Protocol.Models
{
    // TODO: Rename to confirm with spec OptionalVersionedTextDocumentIdentifier
    [DebuggerDisplay("{" + nameof(DebuggerDisplay) + ",nq}")]
    public class VersionedTextDocumentIdentifier : TextDocumentIdentifier, IEquatable<VersionedTextDocumentIdentifier>
    {
        /// <summary>
        /// The version number of this document.
        /// </summary>
        public int? Version { get; set; }

        private string DebuggerDisplay => $"{Uri}@({Version})";

        /// <inheritdoc />
        public override string ToString() => DebuggerDisplay;
        public bool Equals(VersionedTextDocumentIdentifier? other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && Version == other.Version;
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((VersionedTextDocumentIdentifier) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                if (Version != null) return ( base.GetHashCode() * 397 ) ^ Version.GetHashCode();
                return base.GetHashCode();
            }
        }

        public static bool operator ==(VersionedTextDocumentIdentifier? left, VersionedTextDocumentIdentifier? right) => Equals(left, right);

        public static bool operator !=(VersionedTextDocumentIdentifier? left, VersionedTextDocumentIdentifier? right) => !Equals(left, right);
    }
}
