using System.Diagnostics;
using System.Windows.Controls;
using System.Windows.Navigation;
using ValidicCSharp;

namespace ValidicCSharpApp.Views
{
    /// <summary>
    ///     Interaction logic for LogView.xaml
    /// </summary>
    public partial class LogView : UserControl
    {
        public LogView()
        {
            InitializeComponent();
        }

        private void List_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var lv = sender as ListView;
            if (lv == null)
                return;

            var logItem = lv.SelectedItem as LogItem;
            if (logItem == null)
                return;

            rtbMsgBox.Document.Blocks.Clear();
            rtbMsgBox.AppendText(logItem.Json);
        }

        private void Hyperlink_OnRequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
        }
    }
}