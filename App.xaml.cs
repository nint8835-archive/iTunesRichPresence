using System.Windows;
using MahApps.Metro;

namespace iTunesRichPresence_Rewrite {
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App {
        protected override void OnStartup(StartupEventArgs e) {

            ThemeManager.ChangeAppStyle(Current,
                                        ThemeManager.GetAccent("Red"),
                                        ThemeManager.GetAppTheme("BaseDark"));

            base.OnStartup(e);
        }
    }
}
