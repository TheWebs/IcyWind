using IcyWind.HostViews;
using System;
using System.AddIn.Hosting;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using log4net;

namespace IcyWind
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(MainWindow));

        public MainWindow()
        {
            InitializeComponent();
            Load();
        }

        public void Load()
        {
            // Get add-in pipeline folder (the folder in which this application was launched from)
            var appPath = System.IO.Path.Combine(Environment.CurrentDirectory, "core");

            // Rebuild visual add-in pipeline
            var warnings = AddInStore.Rebuild(appPath);
            if (warnings.Length > 0)
            {
                var msg = warnings.Aggregate("Could not rebuild pipeline:", 
                    (current, warning) => current + ("\n" + warning));
                log.Error(msg);
                MessageBox.Show(msg);
                return;
            }

            // Activate add-in with Internet zone security isolation
            var addInTokens = 
                AddInStore.FindAddIn(typeof(IMainHostView), appPath,
                    System.IO.Path.Combine(appPath, "AddIns", "IcyWind.Core", "IcyWind.Core.dll"), 
                    "IcyWind.Core.IcyWind");
            if (addInTokens.Count > 1)
            {
                MessageBox.Show("Danger, more than one core detected. Please reinstall IcyWind. IcyWind will not run");
                log.Fatal("More than one IcyWind Core installed.");
                Environment.Exit(1);
            }
            else
            {
                var dirs = System.IO.Directory.GetFiles(System.IO.Path.Combine(appPath, "AddIns"));
                if (dirs.Length > 1)
                {
                    MessageBox.Show("Warning, some plugins are not installed in the correct location. IcyWind wil not run");
                    log.Warn("Plugin installed in wrong location.");
                    Environment.Exit(1);
                }
            }
            var wpfAddInToken = addInTokens.First();
            var hostview = wpfAddInToken.Activate<IMainHostView>(AddInSecurityLevel.FullTrust);

            // Get and display add-in UI
            FrameworkElement addInUi = hostview.Run();
            MainContent.Content = addInUi;
        }
    }
}
