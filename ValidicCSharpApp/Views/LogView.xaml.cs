using System.Reflection;
using System.Windows.Controls;
using ValidicCSharp;

namespace ValidicCSharpApp.Views
{
    /// <summary>
    /// Interaction logic for LogView.xaml
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
    }
}
