using System.Windows.Controls;
using System.Windows.Input;
using ValidicCSharp.Model;
using ValidicCSharpApp.Helpers;

namespace ValidicCSharpApp.Views.DataViews
{
    /// <summary>
    /// Interaction logic for MeView.xaml
    /// </summary>
    public partial class MeView : UserControl
    {
        public MeView()
        {
            InitializeComponent();
        }
        private void CommandBinding_OnCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            ViewHelper.CopyCommandOnCanExecute(sender, e);
        }

        private void CommandBinding_OnExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            ViewHelper.CopyCommandOnExecuted<Me>(sender, e);
        }
    }
}
