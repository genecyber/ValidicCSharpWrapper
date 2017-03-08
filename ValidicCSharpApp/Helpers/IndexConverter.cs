using System;
using System.Globalization;
using System.Windows.Controls;
using System.Windows.Data;

namespace ValidicCSharpApp.Helpers
{
    public class IndexConverter : BaseConverter, IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var item = (ListViewItem) value;
            var listView = ItemsControl.ItemsControlFromItemContainer(item) as ListView;
            if (listView == null)
                return "0";


            var index = listView.ItemContainerGenerator.IndexFromContainer(item);
            return index.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}