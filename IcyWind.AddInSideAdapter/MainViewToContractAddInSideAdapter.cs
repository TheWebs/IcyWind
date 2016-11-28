using System;
using System.AddIn.Contract;
using System.AddIn.Pipeline;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using IcyWind.AddInViews;
using IcyWind.Contract;

namespace IcyWind.AddInSideAdapter
{
    [AddInAdapter]
    public class MainViewToContractAddInSideAdapter : ContractBase, IMainContract
    {
        private readonly IMain _view;

        public MainViewToContractAddInSideAdapter(IMain view)
        {
            _view = view;
        }

        public virtual INativeHandleContract Run(params object[] para)
        {
            return FrameworkElementAdapters.ViewToContractAdapter(_view.Run());
        }
    }
}
