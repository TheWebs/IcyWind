using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace IcyWind.Core.Logic
{
    public static class UserInterfaceCore
    {
        public static ContentControl MainView;

        private static readonly Dictionary<Type, UserControl> TypeControls = new Dictionary<Type, UserControl>();

        public static void ChangeView(Type control)
        {
            if (!TypeControls.ContainsKey(control))
            {
                TypeControls.Add(control, (UserControl)Activator.CreateInstance(control));
            }
            MainView.Content = TypeControls[control];
#if DEBUG
            MessageBox.Show($"DBG MSG: {control}");
#endif
        }
    }
}
