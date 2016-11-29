using System;
using System.Collections.Generic;
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
using IcyWind.Core.Logic;

namespace IcyWind.Core
{
    /// <summary>
    /// Interaction logic for LoginControl.xaml
    /// </summary>
    public partial class LoginControl
    {
        public LoginControl()
        {
            InitializeComponent();
        }

        public LoginControl(params object[] data)
        {
            //Get the language
            UserInterfaceCore.SetResource(data[0].ToString());
            //Remove resource dictionaries
            Resources.Clear();
            Resources.MergedDictionaries.Clear();
            //Set the correct resource dictionary
            Resources.MergedDictionaries.Add(UserInterfaceCore.MainLanguage);
        }
    }
}
