using System;
using System.AddIn.Contract;
using System.AddIn.Pipeline;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using IcyWind.Contract;
using IcyWind.HostViews;

namespace IcyWind.HostSideAdapters
{
    [HostAdapter]
    public class MainContractToViewHostSideAdapter : IMainHostView
    {
        readonly IMainContract _mainContract;
        ContractHandle _mainContractHandle;

        public MainContractToViewHostSideAdapter(IMainContract mainContract)
        {
            _mainContract = mainContract;
            _mainContractHandle = new ContractHandle(mainContract);
        }

        public FrameworkElement Run(params object[] data)
        {
            return FrameworkElementAdapters.ContractToViewAdapter(_mainContract.Run());
        }
    }
}
