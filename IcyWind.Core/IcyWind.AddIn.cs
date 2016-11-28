using System.AddIn;
using System.Windows;
using IcyWind.AddInViews;

namespace IcyWind.Core
{
    [AddIn("IcyWind.Core")]
    public class IcyWind : IMainView
    {
        public FrameworkElement Run(params object[] data)
        {
            return new LoginControl();
        }
    }
}
