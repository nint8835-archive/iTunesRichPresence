using System;
using System.Windows.Threading;
using iTunesLib;

namespace iTunesRichPresence_Rewrite {
    /// <summary>
    /// Simplifies interactions between iTunes and Discord
    /// </summary>
    internal class DiscordBridge {

        private string _currentArtist;
        private string _currentTitle;
        private string _currentPlaylist;
        private ITPlaylistKind _currentPlaylistType;
        private ITPlayerState _currentState;
        private int _currentPosition;

        private readonly DispatcherTimer _timer;
        private IiTunes _iTunes;

        /// <summary>
        /// Initializes the bridge and connects it to DiscordRPC
        /// </summary>
        /// <param name="applicationId">The Discord application ID for rich presence</param>
        public DiscordBridge(string applicationId) {
            var handlers = new DiscordRpc.EventHandlers();
            DiscordRpc.Initialize(applicationId, ref handlers, true, null);

            _iTunes = new iTunesApp();

            _timer = new DispatcherTimer {Interval = TimeSpan.FromSeconds(15)};
            _timer.Tick += Timer_OnTick;
            _timer.Start();

            _currentArtist = "";
            _currentTitle = "";
            _currentPlaylist = "";
            _currentPlaylistType = ITPlaylistKind.ITPlaylistKindUnknown;
            _currentState = ITPlayerState.ITPlayerStateStopped;
            _currentPosition = 0;

        }

        /// <summary>
        /// Renders a string template using information about the currently playing song
        /// </summary>
        /// <param name="template">The template to render</param>
        /// <returns>The rendered string</returns>
        private string RenderString(string template) {
            string playlistType;
            if (_iTunes.CurrentPlaylist.Kind == ITPlaylistKind.ITPlaylistKindUser) {
                playlistType = ((IITUserPlaylist) _iTunes.CurrentPlaylist).SpecialKind == ITUserPlaylistSpecialKind.ITUserPlaylistSpecialKindMusic ? "Album" : "Playlist";
            }
            else {
                playlistType = "Album";
            }

            return template.Replace("%artist", _currentArtist).Replace("%track", _currentTitle)
                .Replace("%playlist_name", _currentPlaylist).Replace("%playlist_type", playlistType);
        }

        /// <summary>
        /// Handles checking for playing status changes and pushing out presence updates
        /// </summary>
        /// <param name="sender">Sender of this event</param>
        /// <param name="e">Args of this event</param>
        private void Timer_OnTick(object sender, EventArgs e) {
            if (_iTunes.CurrentTrack == null) {
                DiscordRpc.ClearPresence();
                return;
            }

            if (_currentArtist == _iTunes.CurrentTrack.Artist && _currentTitle == _iTunes.CurrentTrack.Name &&
                _currentState == _iTunes.PlayerState && _currentPlaylist == _iTunes.CurrentPlaylist.Name &&
                _currentPlaylistType == _iTunes.CurrentPlaylist.Kind && _currentPosition == _iTunes.PlayerPosition) return;

            _currentArtist = _iTunes.CurrentTrack.Artist;
            _currentTitle = _iTunes.CurrentTrack.Name;
            _currentState = _iTunes.PlayerState;
            _currentPlaylist = _iTunes.CurrentPlaylist.Name;
            _currentPlaylistType = _iTunes.CurrentPlaylist.Kind;
            _currentPosition = _iTunes.PlayerPosition;
        }

        /// <summary>
        /// Disconnects from DiscordRPC and shuts down the bridge
        /// </summary>
        public void Shutdown() {
            _timer.Stop();
            DiscordRpc.Shutdown();
        }
    }
}
