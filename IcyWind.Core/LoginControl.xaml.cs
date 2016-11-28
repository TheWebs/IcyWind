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
        void TestButton(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("WE DID IT!");
        }
    }
}
