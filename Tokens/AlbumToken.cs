using iTunesLib;

namespace iTunesRichPresence_Rewrite.Tokens {
    public class AlbumToken : IToken {
        public string DisplayName => "Album";
        public string Token => "%album";
        public bool ShowInToolbox => true;
        public string GetText(IiTunes iTunes) {
            return iTunes.CurrentTrack.Album;
        }
    }
}