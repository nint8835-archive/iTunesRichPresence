using iTunesLib;

namespace iTunesRichPresence_Rewrite.Tokens {
    /// <summary>
    /// Interface that represents a formatting token.
    /// </summary>
    public interface IToken {
        /// <summary>
        /// The display name for the token. Used for the token toolbox.
        /// </summary>
        string DisplayName { get; }
        /// <summary>
        /// The token to be used in format strings.
        /// </summary>
        string Token { get; }
        /// <summary>
        /// Whether or not this token should be included in the toolbox.
        /// </summary>
        bool ShowInToolbox { get; }
        /// <summary>
        /// Gets the text that this token should be replaced with.
        /// </summary>
        /// <param name="iTunes">The iTunes instance to retrieve information from</param>
        /// <returns>The text to replace the token with.</returns>
        string GetText(IiTunes iTunes);
    }
}