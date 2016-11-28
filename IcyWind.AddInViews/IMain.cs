using System;
using System.AddIn.Pipeline;
using System.Windows;

namespace IcyWind.AddInViews
{
    [AddInBase]
    public interface IMain
    {
        FrameworkElement Run(params object[] args);
    }
}
