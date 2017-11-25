using System;
using System.Windows.Forms;
using iTunesLib;

namespace iTunesRichPresence {
    public partial class MainForm : Form {
        private IiTunes _iTunes;
        private string _currentArtist;
        private string _currentTitle;
        private ITPlayerState _currentState;
        public MainForm() {
            _currentArtist = "";
            _currentTitle = "";
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e) {
            InitializeDiscord();
            InitializeiTunes();
            pollTimer.Enabled = true;
        }

        private void InitializeDiscord() {
            DiscordRPC.EventHandlers handlers = new DiscordRPC.EventHandlers {
                readyCallback = HandleReadyCallback,
                errorCallback = HandleErrorCallback,
                disconnectedCallback = HandleDisconnectedCallback
            };
            DiscordRPC.Discord_Initialize("383816327850360843", ref handlers, true, null);
        }

        private void HandleReadyCallback() {}

        private static void HandleErrorCallback(int errorCode, string message) { }
        private static void HandleDisconnectedCallback(int errorCode, string message) { }

        private void InitializeiTunes() {
            _iTunes = new iTunesApp();
        }
        
        private void UpdatePresence() {
            var presence = new DiscordRPC.RichPresence {details = $"{_currentArtist} - {_currentTitle}"};
            if (_currentTitle == "DVNO") {
                presence.largeImageKey = "dvno";
                presence.smallImageKey = "itunes_logo";
                presence.largeImageText = "Four capital letters, printed in gold";
            }
            else {
                presence.largeImageKey = "itunes_logo_big";
            }

            if (_iTunes.CurrentPlaylist.Kind == ITPlaylistKind.ITPlaylistKindUser) {
                presence.state = _iTunes.CurrentPlaylist.Name == "Music"
                    ? $"Album: {_iTunes.CurrentTrack.Album}"
                    : $"Playlist: {_iTunes.CurrentPlaylist.Name}";
            }
            else {
                presence.state = $"Album: {_iTunes.CurrentTrack.Album}";
            }

            if (_currentState != ITPlayerState.ITPlayerStatePlaying) {
                presence.state = "Paused";
            }
            
            DiscordRPC.Discord_UpdatePresence(ref presence);
        }

        private void pollTimer_Tick(object sender, EventArgs e) {
            if (_currentArtist == _iTunes.CurrentTrack.Artist && _currentTitle == _iTunes.CurrentTrack.Name && _currentState == _iTunes.PlayerState) return;
            _currentArtist = _iTunes.CurrentTrack.Artist;
            _currentTitle = _iTunes.CurrentTrack.Name;
            _currentState = _iTunes.PlayerState;
            UpdatePresence();
        }
    }
}
