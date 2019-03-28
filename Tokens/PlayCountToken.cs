using iTunesLib;

namespace iTunesRichPresence_Rewrite.Tokens
{
    class PlayCountToken : IToken {
        public string DisplayName => "Play count";
        public string Token => "%play_count";
        public bool ShowInToolbox => true;
        public string GetText(IiTunes iTunes) {
            return iTunes.CurrentTrack.PlayedCount.ToString();
        }
    }
}
