using iTunesLib;

namespace iTunesRichPresence_Rewrite.Tokens {
    public class TrackToken : IToken {
        public string DisplayName => "Track";
        public string Token => "%track";
        public bool ShowInToolbox => true;
        public string GetText(IiTunes iTunes) {
            return iTunes.CurrentTrack.Name;
        }
    }
}