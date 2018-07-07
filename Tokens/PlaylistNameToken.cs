using iTunesLib;

namespace iTunesRichPresence_Rewrite.Tokens {
    public class PlaylistNameToken : IToken {
        public string DisplayName => "Playlist name";
        public string Token => "%playlist_name";
        public string GetText(IiTunes iTunes) {
            return iTunes.CurrentPlaylist.Name;
        }
    }
}