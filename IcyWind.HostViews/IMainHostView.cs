using System.Windows;

namespace IcyWind.HostViews
{
    public interface IMainHostView
    {
        FrameworkElement Run(params object[] data);
    }
}
