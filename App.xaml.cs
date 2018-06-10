using System;
using System.Windows;
using System.Windows.Threading;
using MahApps.Metro;
using SharpRaven;
using SharpRaven.Data;

namespace iTunesRichPresence_Rewrite {

    public static class Globals {
        public static RavenClient RavenClient;
    }

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App {
        protected override void OnStartup(StartupEventArgs e) {

            Globals.RavenClient = new RavenClient("https://f5c5c3b871814c92bc0103ce3bdfca4a@sentry.io/1223024");

            AppDomain.CurrentDomain.UnhandledException += CurrentDomainOnUnhandledException;
            Application.Current.DispatcherUnhandledException += CurrentOnDispatcherUnhandledException;

            ThemeManager.ChangeAppStyle(Current,
                                        ThemeManager.GetAccent("Orange"),
                                        ThemeManager.GetAppTheme("BaseLight"));

            base.OnStartup(e);
        }

        private static void CurrentOnDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e) {
            Globals.RavenClient.Capture(new SentryEvent(e.Exception));
        }

        private static void CurrentDomainOnUnhandledException(object sender, UnhandledExceptionEventArgs e) {
            Globals.RavenClient.Capture(new SentryEvent(e.ExceptionObject as Exception));
        }
    }
}
