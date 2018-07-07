using iTunesLib;

namespace iTunesRichPresence_Rewrite.Tokens {
    public class PlaylistTypeToken : IToken {
        public string DisplayName => "Playlist type";
        public string Token => "%playlist_type";
        public string GetText(IiTunes iTunes) {
            if (iTunes.CurrentPlaylist.Kind == ITPlaylistKind.ITPlaylistKindUser) {
                return ((IITUserPlaylist) iTunes.CurrentPlaylist).SpecialKind == ITUserPlaylistSpecialKind.ITUserPlaylistSpecialKindMusic ? "Album" : "Playlist";
            }

            return "Album";
        }
    }
}