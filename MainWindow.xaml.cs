using System;
using System.Reflection;
using System.Windows;
using System.Windows.Forms;
using iTunesLib;
using iTunesRichPresence_Rewrite.Properties;
using MahApps.Metro.Controls.Dialogs;
using Microsoft.Win32;

namespace iTunesRichPresence_Rewrite {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow {

        private readonly NotifyIcon _notifyIcon;
        private IiTunes _iTunes;

        public MainWindow() {
            InitializeComponent();
            _iTunes = new iTunesApp();
            _notifyIcon = new NotifyIcon {Text = "iTunesRichPresence", Visible = false, Icon = System.Drawing.Icon.ExtractAssociatedIcon(Assembly.GetExecutingAssembly().Location)};
            _notifyIcon.MouseDoubleClick += (sender, args) => { WindowState = WindowState.Normal; };

            RunOnStartupCheckbox.IsChecked = Settings.Default.RunOnStartup;
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

        private void DiagnosticsButton_OnClick(object sender, RoutedEventArgs e) {
            throw new NotImplementedException();
        }

        private void RunOnStartupCheckbox_OnClick(object sender, RoutedEventArgs e) {
            if (RunOnStartupCheckbox.IsChecked ?? false) {
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
            await this.ShowMessageAsync("",$"iTunesRichPresence v{Assembly.GetExecutingAssembly().GetName().Version}\n\nDeveloped by nint8835 (Riley Flynn)\n\niTunesRichPresence uses portions of DiscordRpc by Discord, Inc. licensed under the MIT license. A copy of this license can be found in the program directory.");
        }
    }
}
