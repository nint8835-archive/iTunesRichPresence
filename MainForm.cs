using System;
using System.Runtime.InteropServices;
using System.Text;
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
        
        string toUTF8(string toconv)
        {
            return Encoding.UTF8.GetString(Encoding.UTF8.GetBytes(toconv.Trim()));
        }

        private void UpdatePresence() {
            var presence = new DiscordRPC.RichPresence {};

            string details = toUTF8($"{_currentArtist} - {_currentTitle}");
            IntPtr details_ptr = Marshal.AllocCoTaskMem(Encoding.UTF8.GetByteCount(details));
            Marshal.Copy(Encoding.UTF8.GetBytes(details), 0, details_ptr, Encoding.UTF8.GetByteCount(details));
            presence.details = details_ptr;

            if (_currentTitle == "DVNO") {
                presence.largeImageKey = "dvno";
                presence.smallImageKey = "itunes_logo";
                presence.largeImageText = "Four capital letters, printed in gold";
            }
            else {
                presence.largeImageKey = "itunes_logo_big";
            }
            string state = "";

            if (_iTunes.CurrentPlaylist.Kind == ITPlaylistKind.ITPlaylistKindUser) {
                state = _iTunes.CurrentPlaylist.Name == "Music" || _iTunes.CurrentPlaylist.Name == "ミュージック"
                    ? toUTF8($"Album: {_iTunes.CurrentTrack.Album}")
                    : toUTF8($"Playlist: {_iTunes.CurrentPlaylist.Name}");
                IntPtr state_ptr = Marshal.AllocCoTaskMem(Encoding.UTF8.GetByteCount(state));
                Marshal.Copy(Encoding.UTF8.GetBytes(state), 0, state_ptr, Encoding.UTF8.GetByteCount(state));
                presence.state = state_ptr;
            }
            else {
                state = toUTF8($"Album: {_iTunes.CurrentTrack.Album}");
                IntPtr state_ptr = Marshal.AllocCoTaskMem(Encoding.UTF8.GetByteCount(state));
                Marshal.Copy(Encoding.UTF8.GetBytes(state), 0, state_ptr, Encoding.UTF8.GetByteCount(state));
                presence.state = state_ptr;
            }

            if (_currentState != ITPlayerState.ITPlayerStatePlaying) {
                state = toUTF8("Paused");
                IntPtr state_ptr = Marshal.AllocCoTaskMem(Encoding.UTF8.GetByteCount(state));
                Marshal.Copy(Encoding.UTF8.GetBytes(state), 0, state_ptr, Encoding.UTF8.GetByteCount(state));
                presence.state = state_ptr;
            }

            presence.startTimestamp = DateTimeOffset.Now.ToUnixTimeSeconds() - _iTunes.PlayerPosition;
            presence.endTimestamp = DateTimeOffset.Now.ToUnixTimeSeconds() + (_iTunes.CurrentTrack.Duration - _iTunes.PlayerPosition);
            
            DiscordRPC.Discord_UpdatePresence(ref presence);
        }

        private void pollTimer_Tick(object sender, EventArgs e) {
            if (_iTunes.CurrentTrack == null) return;
            if (_currentArtist == _iTunes.CurrentTrack.Artist && _currentTitle == _iTunes.CurrentTrack.Name && _currentState == _iTunes.PlayerState) return;
            _currentArtist = _iTunes.CurrentTrack.Artist;
            _currentTitle = _iTunes.CurrentTrack.Name;
            _currentState = _iTunes.PlayerState;
            
            UpdatePresence();
        }
    }
}
