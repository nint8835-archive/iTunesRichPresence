using System;
using System.Windows.Forms;
using iTunesLib;

namespace iTunesRichPresence {
    public partial class MainForm : Form {
        private IiTunes _iTunes;
        private string _currentArtist;
        private string _currentTitle;
        private ITPlayerState _currentState;
        private int _currentPosition;
        public MainForm() {
            _currentArtist = "";
            _currentTitle = "";
            _currentPosition = 0;
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e) {
            InitializeDiscord();
            InitializeiTunes();
            pollTimer.Enabled = true;
        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);
            this.Visible = false;
            TrayIcon.ShowBalloonTip(300, "Application Minimized to Tray", "Right-click icon to close.", ToolTipIcon.Info);
        }

        private void InitializeDiscord() {
            DiscordRPC.EventHandlers handlers = new DiscordRPC.EventHandlers {
                readyCallback = HandleReadyCallback,
                errorCallback = HandleErrorCallback,
                disconnectedCallback = HandleDisconnectedCallback
            };
            DiscordRPC.Initialize("383816327850360843", ref handlers, true, null);
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
                presence.state = ((IITUserPlaylist) _iTunes.CurrentPlaylist).SpecialKind == ITUserPlaylistSpecialKind.ITUserPlaylistSpecialKindMusic
                    ? $"Album: {_iTunes.CurrentTrack.Album}"
                    : $"Playlist: {_iTunes.CurrentPlaylist.Name}";
            }
            else {
                presence.state = $"Album: {_iTunes.CurrentTrack.Album}";
            }

            if (_currentState != ITPlayerState.ITPlayerStatePlaying) {
                presence.state = "Paused";
            }
            else {
                presence.startTimestamp = DateTimeOffset.Now.ToUnixTimeSeconds() - _iTunes.PlayerPosition;
                presence.endTimestamp = DateTimeOffset.Now.ToUnixTimeSeconds() + (_iTunes.CurrentTrack.Duration - _iTunes.PlayerPosition);
            }

            DiscordRPC.UpdatePresence(presence);
        }

        private void pollTimer_Tick(object sender, EventArgs e) {
            if (_iTunes.CurrentTrack == null) return;
            if (_currentArtist == _iTunes.CurrentTrack.Artist && _currentTitle == _iTunes.CurrentTrack.Name && _currentState == _iTunes.PlayerState && _currentPosition == _iTunes.PlayerPosition) return;
            _currentArtist = _iTunes.CurrentTrack.Artist;
            _currentTitle = _iTunes.CurrentTrack.Name;
            _currentState = _iTunes.PlayerState;
            _currentPosition = _iTunes.PlayerPosition;
            
            UpdatePresence();
        }

        

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TrayIcon.Dispose();
            Application.Exit();
        }
    }
}
