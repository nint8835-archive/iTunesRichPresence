using System;
using System.Diagnostics;
using System.Reflection;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Navigation;
using iTunesRichPresence_Rewrite.Properties;
using MahApps.Metro.Controls.Dialogs;
using Microsoft.Win32;
using TextBox = System.Windows.Controls.TextBox;
using Octokit;

namespace iTunesRichPresence_Rewrite {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow {

        private readonly NotifyIcon _notifyIcon;
        private readonly DiscordBridge _bridge;

        private GitHubClient _gitHubClient;
        private Release _latestRelease;

        private TextBox _lastFocusedTextBox;

        public MainWindow() {
            InitializeComponent();

            _lastFocusedTextBox = PlayingTopLineFormatTextBox;

            _bridge = new DiscordBridge("383816327850360843");

            _notifyIcon = new NotifyIcon {Text = "iTunesRichPresence", Visible = false, Icon = System.Drawing.Icon.ExtractAssociatedIcon(Assembly.GetExecutingAssembly().Location)};
            _notifyIcon.MouseDoubleClick += (sender, args) => { WindowState = WindowState.Normal; };

            RunOnStartupCheckBox.IsChecked = Settings.Default.RunOnStartup;
            PlayingTopLineFormatTextBox.Text = Settings.Default.PlayingTopLine;
            PlayingBottomLineFormatTextBox.Text = Settings.Default.PlayingBottomLine;
            PausedTopLineFormatTextBox.Text = Settings.Default.PausedTopLine;
            PausedBottomLineFormatTextBox.Text = Settings.Default.PausedBottomLine;
            PlaybackDurationCheckBox.IsChecked = Settings.Default.DisplayPlaybackDuration;

            _gitHubClient = new GitHubClient(new ProductHeaderValue("iTunesRichPresence"));
            _latestRelease = _gitHubClient.Repository.Release.GetLatest("nint8835", "iTunesRichPresence").Result;
            if (!Assembly.GetExecutingAssembly().GetName().Version.ToString().StartsWith(_latestRelease.Name.Substring(1))) {
                UpdateButton.Visibility = Visibility.Visible;
            }

        }

        private void MetroWindow_StateChanged(object sender, EventArgs e) {
            if (WindowState == WindowState.Minimized) {
                ShowInTaskbar = false;
                _notifyIcon.Visible = true;
                _notifyIcon.ShowBalloonTip(5000, "iTunesRichPresence hidden to tray", "iTunesRichPresence has been minimized to the system tray. Double click the icon to show the window again.", ToolTipIcon.None);
            }
            else {
                ShowInTaskbar = true;
                _notifyIcon.Visible = false;
            }
        }

        private void RunOnStartupCheckBox_OnClick(object sender, RoutedEventArgs e) {
            if (RunOnStartupCheckBox.IsChecked ?? false) {
                Settings.Default.RunOnStartup = true;
                Settings.Default.Save();

                Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true)?.SetValue("iTunesRichPresence", Assembly.GetExecutingAssembly().Location);

            }
            else {
                Settings.Default.RunOnStartup = false;
                Settings.Default.Save();

                Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true)?.DeleteValue("iTunesRichPresence");
            }
        }

        private async void AboutButton_OnClick(object sender, RoutedEventArgs e) {
            await this.ShowMessageAsync("",$"iTunesRichPresence v{Assembly.GetExecutingAssembly().GetName().Version}\n\nDeveloped by nint8835 (Riley Flynn)\n\niTunesRichPresence includes portions of a number of open source projects. The licenses of these projects can be found in this program's installation directory.");
        }

        private void MetroWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e) {
            _bridge.Shutdown();
        }

        private void TrackButton_Click(object sender, RoutedEventArgs e) {
            _lastFocusedTextBox.Text += "%track";
        }

        private void ArtistButton_Click(object sender, RoutedEventArgs e) {
            _lastFocusedTextBox.Text += "%artist";
        }

        private void PlaylistTypeButton_Click(object sender, RoutedEventArgs e) {
            _lastFocusedTextBox.Text += "%playlist_type";
        }

        private void PlaylistNameButton_Click(object sender, RoutedEventArgs e) {
            _lastFocusedTextBox.Text += "%playlist_name";
        }

        private void PlayingTopLineFormatTextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e) {
            Settings.Default.PlayingTopLine = PlayingTopLineFormatTextBox.Text;
            Settings.Default.Save();
        }

        private void PlayingBottomLineFormatTextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e) {
            Settings.Default.PlayingBottomLine = PlayingBottomLineFormatTextBox.Text;
            Settings.Default.Save();
        }

        private void PausedTopLineFormatTextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e) {
            Settings.Default.PausedTopLine = PausedTopLineFormatTextBox.Text;
            Settings.Default.Save();
        }

        private void PausedBottomLineFormatTextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e) {
            Settings.Default.PausedBottomLine = PausedBottomLineFormatTextBox.Text;
            Settings.Default.Save();
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e) {
            _lastFocusedTextBox = e.Source as TextBox;
        }

        private void PlaybackDurationCheckBox_Click(object sender, RoutedEventArgs e) {
            Settings.Default.DisplayPlaybackDuration = PlaybackDurationCheckBox.IsChecked ?? true;
            Settings.Default.Save();
        }

        private async void UpdateButton_OnClick(object sender, RoutedEventArgs e) {
            var result = await this.ShowMessageAsync("New version available!", "A new version of iTunesRichPresence is available. Would you like to download it now?", MessageDialogStyle.AffirmativeAndNegative);
            if (result == MessageDialogResult.Affirmative) {
                Process.Start(_latestRelease.HtmlUrl);
            }
        }
    }
}
