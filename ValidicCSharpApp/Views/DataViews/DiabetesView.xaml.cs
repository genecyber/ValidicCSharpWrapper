using System.Windows.Controls;
using System.Windows.Input;
using ValidicCSharp.Model;
using ValidicCSharpApp.Helpers;

namespace ValidicCSharpApp.Views.DataViews
{
    /// <summary>
    /// Interaction logic for DiabetesView.xaml
    /// </summary>
    public partial class DiabetesView : UserControl
    {
        public DiabetesView()
        {
            InitializeComponent();
        }

        private void CommandBinding_OnCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            ViewHelper.CopyCommandOnCanExecute(sender, e);
        }

        private void CommandBinding_OnExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            ViewHelper.CopyCommandOnExecuted<Diabetes>(sender, e);
        }
    }
}
