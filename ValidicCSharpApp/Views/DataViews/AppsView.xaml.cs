using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ValidicCSharp.Model;
using ValidicCSharpApp.Helpers;

namespace ValidicCSharpApp.Views.DataViews
{
    /// <summary>
    /// Interaction logic for AppsView.xaml
    /// </summary>
    public partial class AppsView : UserControl
    {
        public AppsView()
        {
            InitializeComponent();
        }
        private void Hyperlink_OnRequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
        }

        private void CommandBinding_OnCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            ViewHelper.CopyCommandOnCanExecute(sender, e);
        }

        private void CommandBinding_OnExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            ViewHelper.CopyCommandOnExecuted<ValidicCSharp.Model.App>(sender, e);
        }

    }
}
