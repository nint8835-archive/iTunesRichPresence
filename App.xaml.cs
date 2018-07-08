using System;
using System.Globalization;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using SharpRaven;
using SharpRaven.Data;

namespace iTunesRichPresence_Rewrite {

    public static class Globals {
        public static RavenClient RavenClient;
        public static TextBox LogBox;

        public static void Log(string message) {
            LogBox.Text += $"[{DateTime.Now.ToString(CultureInfo.CurrentCulture)}] {message}\n";
        }
    }

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App {
        protected override void OnStartup(StartupEventArgs e) {

            Globals.RavenClient = new RavenClient("https://f5c5c3b871814c92bc0103ce3bdfca4a@sentry.io/1223024") {
                Release = Assembly.GetExecutingAssembly().GetName().Version.ToString()
            };

            AppDomain.CurrentDomain.UnhandledException += CurrentDomainOnUnhandledException;

            base.OnStartup(e);
        }

        private void CurrentOnDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e) {
            Globals.RavenClient.Capture(new SentryEvent(e.Exception));
            Globals.Log($"An unhandled exception has occurred and been reported to Sentry: {e.Exception.Message}");
        }

        private static void CurrentDomainOnUnhandledException(object sender, UnhandledExceptionEventArgs e) {
            Globals.RavenClient.Capture(new SentryEvent(e.ExceptionObject as Exception));
            Globals.Log($"An unhandled exception has occurred and been reported to Sentry: {((Exception)e.ExceptionObject).Message}");
        }
    }
}
