using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using ValidicCSharp.Model;

namespace ValidicCSharpApp.ViewModels
{
    public class MeViewModel : ViewModelBase
    {
        private RefreshToken _refreshToken;

        public Me Me { get; set; }
        public RefreshToken RefreshToken
        {
            get { return _refreshToken; }
            set
            {
                if (_refreshToken == value)
                    return;

                _refreshToken = value;
                RaisePropertyChanged();
            }
        }

    }
}
