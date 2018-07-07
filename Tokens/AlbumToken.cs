using iTunesLib;

namespace iTunesRichPresence_Rewrite.Tokens {
    public class AlbumToken : IToken {
        public string DisplayName => "Album";
        public string Token => "%album";
        public string GetText(IiTunes iTunes) {
            return iTunes.CurrentTrack.Album;
        }
    }
}