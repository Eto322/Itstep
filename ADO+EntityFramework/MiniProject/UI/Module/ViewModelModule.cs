using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Module;
using Ninject;
using UI.ViewModel;

namespace UI.Module
{
   
    public class ViewModelModule
    {
        private IKernel kernel;
        public ViewModelModule()
        {
            this.kernel = new StandardKernel(new ShopModule());
        }

        public MainViewModel MainViewModel => kernel.Get<MainViewModel>();

    }
}
