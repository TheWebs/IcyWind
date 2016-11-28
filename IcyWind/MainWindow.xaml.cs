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

namespace IcyWind
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
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
                MessageBox.Show("Extreme Danger, more than one core detected. Please reinstall IcyWind");
            }
            var wpfAddInToken = addInTokens.First();
            var hostview = wpfAddInToken.Activate<IMainHostView>(AddInSecurityLevel.FullTrust);

            // Get and display add-in UI
            FrameworkElement addInUi = hostview.Run();
            MainContent.Content = addInUi;
        }
    }
}
