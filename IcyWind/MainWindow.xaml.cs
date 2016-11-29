﻿using IcyWind.HostViews;
using System;
using System.AddIn.Hosting;
using System.Linq;
using System.Windows;
using IcyWind.Core;
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
            LanguageHelper.SetResource("English");
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
                var msg = warnings.Aggregate(LanguageHelper.ShortNameToString("PipelineRebuildFail"), 
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
                MessageBox.Show(LanguageHelper.ShortNameToString("MoreOneCore"), 
                    "IcyWind Error", MessageBoxButton.OK, MessageBoxImage.Error);
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
