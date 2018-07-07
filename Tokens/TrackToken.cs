using iTunesLib;

namespace iTunesRichPresence_Rewrite.Tokens {
    public class TrackToken : IToken {
        public string DisplayName => "Track";
        public string Token => "%track";
        public string GetText(IiTunes iTunes) {
            return iTunes.CurrentTrack.Name;
        }
    }
}