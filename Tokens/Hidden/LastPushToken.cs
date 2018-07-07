using System;
using iTunesLib;

namespace iTunesRichPresence_Rewrite.Tokens.Hidden {
    public class LastPushToken : IToken {
        public string DisplayName => "Last push";
        public string Token => "%last_push";
        public bool ShowInToolbox => false;
        private long _lastPush = 0;
        public string GetText(IiTunes iTunes) {
            if (_lastPush == 0) {
                _lastPush = DateTimeOffset.Now.ToUnixTimeSeconds();
                return "Never";
            }

            var now = DateTimeOffset.Now.ToUnixTimeSeconds();
            var diff = now - _lastPush;

            _lastPush = now;
            return $"{diff} seconds ago";
        }
    }
}