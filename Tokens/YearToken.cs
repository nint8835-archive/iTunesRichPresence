using iTunesLib;

namespace iTunesRichPresence_Rewrite.Tokens {
    public class YearToken : IToken {
        public string DisplayName => "Year";
        public string Token => "%year";
        public bool ShowInToolbox => true;
        public string GetText(IiTunes iTunes) {
            return iTunes.CurrentTrack.Year.ToString();
        }
    }
}