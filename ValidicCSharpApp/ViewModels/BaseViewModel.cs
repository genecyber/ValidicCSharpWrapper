using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;

namespace ValidicCSharpApp.ViewModels
{
    public class BaseViewModel : ViewModelBase
    {
        public virtual Action<Action> Dispatcher { get; set; }
    }
}
