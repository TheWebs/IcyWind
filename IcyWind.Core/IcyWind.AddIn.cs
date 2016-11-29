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
            //Create the main view
            UserInterfaceCore.MainView = new MainControl();
            //Change the view the main view has
            UserInterfaceCore.ChangeView(typeof(LoginControl), data);
            //Return the main view to base application
            return UserInterfaceCore.MainView;
        }
    }
}
