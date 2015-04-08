using System.Windows.Controls;
using System.Windows.Input;
using ValidicCSharp.Model;
using ValidicCSharpApp.Helpers;

namespace ValidicCSharpApp.Views.DataViews
{
    /// <summary>
    /// Interaction logic for WeightView.xaml
    /// </summary>
    public partial class WeightView : UserControl
    {
        public WeightView()
        {
            InitializeComponent();
        }
        private void CommandBinding_OnCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            ViewHelper.CopyCommandOnCanExecute(sender, e);
        }

        private void CommandBinding_OnExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            ViewHelper.CopyCommandOnExecuted<Weight>(sender, e);
        }
    }
}
