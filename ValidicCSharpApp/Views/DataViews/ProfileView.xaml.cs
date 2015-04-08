using System.Windows.Controls;
using System.Windows.Input;
using ValidicCSharp.Model;
using ValidicCSharpApp.Helpers;

namespace ValidicCSharpApp.Views.DataViews
{
    /// <summary>
    /// Interaction logic for ProfileView.xaml
    /// </summary>
    public partial class ProfileView : UserControl
    {
        public ProfileView()
        {
            InitializeComponent();
        }
        private void CommandBinding_OnCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            ViewHelper.CopyCommandOnCanExecute(sender, e);
        }

        private void CommandBinding_OnExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            ViewHelper.CopyCommandOnExecuted<Profile>(sender, e);
        }

    }
}
