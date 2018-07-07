using iTunesLib;

namespace iTunesRichPresence_Rewrite.Tokens {
    public class ArtistToken : IToken {
        public string DisplayName => "Artist";
        public string Token => "%artist";
        public bool ShowInToolbox => true;
        public string GetText(IiTunes iTunes) {
            return iTunes.CurrentTrack.Artist;
        }
    }
}