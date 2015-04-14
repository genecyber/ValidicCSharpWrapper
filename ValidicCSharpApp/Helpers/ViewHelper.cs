using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ValidicCSharpApp.Helpers
{
    public class ViewHelper
    {
        public static void CopyCommandOnCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
            e.Handled = true;
        }

        public static void CopyCommandOnExecuted<T>(object sender, ExecutedRoutedEventArgs e)
        {
            var lb = e.OriginalSource as ListBox;
            if (lb == null)
                return;

            var copyContent = new StringBuilder();

            // The SelectedItems could be ListBoxItem instances or data bound objects depending on how you populate the ListBox.  
            var list = lb.SelectedItems.OfType<T>().ToList();
            foreach (var m in list)
            {
                copyContent.Append(m);
                copyContent.AppendLine();
            }
            Clipboard.SetText(copyContent.ToString());
        }
    }
}