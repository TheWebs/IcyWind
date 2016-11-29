using System.AddIn;
using System.Windows;
using IcyWind.AddInViews;
using IcyWind.Core.Logic;

namespace IcyWind.Core
{
    [AddIn("IcyWind.Core")]
    public class IcyWind : IMainView
    {
        public FrameworkElement Run(params object[] data)
        {
            UserInterfaceCore.MainView = new MainControl();
            UserInterfaceCore.ChangeView(typeof(LoginControl), data);
            return UserInterfaceCore.MainView;
        }
    }
}
