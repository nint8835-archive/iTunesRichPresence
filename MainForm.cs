using System;
using System.Text;
using System.Windows.Forms;
using iTunesLib;

namespace iTunesRichPresence {
    public partial class MainForm : Form {
        private IiTunes _iTunes;
        private string _currentArtist;
        private string _currentTitle;
        private string _currentPlaylist;
        private string _currentPlaylistType;
        private ITPlayerState _currentState;
        private int _currentPosition;
        public MainForm() {
            _currentArtist = "";
            _currentTitle = "";
            _currentPlaylist = "";
            _currentPlaylistType = "";
            _currentPosition = 0;
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e) {
            detailsTextBox.Text = Properties.Settings.Default.DetailsFormat;
            stateTextBox.Text = Properties.Settings.Default.StateFormat;
            pausedDetailsTextBox.Text = Properties.Settings.Default.PausedDetailsFormat;
            pausedStateTextBox.Text = Properties.Settings.Default.PausedStateFormat;
            InitializeDiscord();
            InitializeiTunes();
            pollTimer.Enabled = true;
            Hide();
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

        private static string TruncateString(string s) {
            var n = Encoding.Unicode.GetByteCount(s);
            if (n <= 127) return s;
            s = s.Substring(0, 64);

            while (Encoding.Unicode.GetByteCount(s) > 123)
                s = s.Substring(0, s.Length - 1);

            return s + "...";
        }

        private string RenderString(string template) {
            return template.Replace("%artist", _currentArtist).Replace("%track", _currentTitle)
                .Replace("%playlist_type", _currentPlaylistType).Replace("%playlist_name", _currentPlaylist);
        }

        private void UpdatePresence() {
            
            if (_iTunes.CurrentPlaylist.Kind == ITPlaylistKind.ITPlaylistKindUser) {
                if(((IITUserPlaylist) _iTunes.CurrentPlaylist).SpecialKind == ITUserPlaylistSpecialKind.ITUserPlaylistSpecialKindMusic){
                    _currentPlaylistType = "Album";
                    _currentPlaylist = _iTunes.CurrentTrack.Album;
                }
                else {
                    _currentPlaylistType = "Playlist";
                    _currentPlaylist = _iTunes.CurrentPlaylist.Name;
                }
            }
            else {
                _currentPlaylistType = "Album";
                _currentPlaylist = _iTunes.CurrentTrack.Album;
            }

            var presence = new DiscordRPC.RichPresence {largeImageKey = "itunes_logo_big"};

            if (_currentState != ITPlayerState.ITPlayerStatePlaying) {
                presence.details = TruncateString(RenderString(Properties.Settings.Default.PausedDetailsFormat));
                presence.state = TruncateString(RenderString(Properties.Settings.Default.PausedStateFormat));
            }
            else {
                presence.details = TruncateString(RenderString(Properties.Settings.Default.DetailsFormat));
                presence.state = TruncateString(RenderString(Properties.Settings.Default.StateFormat));
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

        private void TrayIcon_MouseDoubleClick(object sender, MouseEventArgs e) {
            Show();
        }

        private void hideButton_Click(object sender, EventArgs e) {
            Hide();
        }

        private void detailsTextBox_TextChanged(object sender, EventArgs e) {
            Properties.Settings.Default.DetailsFormat = detailsTextBox.Text;
            Properties.Settings.Default.Save();
        }

        private void stateTextBox_TextChanged(object sender, EventArgs e) {
            Properties.Settings.Default.StateFormat = stateTextBox.Text;
            Properties.Settings.Default.Save();
        }

        private void pausedDetailsTextBox_TextChanged(object sender, EventArgs e) {
            Properties.Settings.Default.PausedDetailsFormat = pausedDetailsTextBox.Text;
            Properties.Settings.Default.Save();
        }

        private void pausedStateTextBox_TextChanged(object sender, EventArgs e) {
            Properties.Settings.Default.PausedStateFormat = pausedStateTextBox.Text;
            Properties.Settings.Default.Save();
        }
    }
}
