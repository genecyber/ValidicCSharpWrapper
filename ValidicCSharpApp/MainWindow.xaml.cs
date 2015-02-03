using System;
using System.Collections.Generic;
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
using ValidicCSharpApp.Properties;
using ValidicCSharpApp.ViewModels;

namespace ValidicCSharpApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public void Start(MainViewModel model)
        {
            LoadSettings(model);
        }

        public void Stop(MainViewModel model)
        {
            SaveSettings(model);
        }

        private void LoadSettings(MainViewModel model)
        {
            var s = Settings.Default;
            // Load Window State
            WindowState = s.WindowState;
            Top = s.WindowTop;
            Left = s.WindowLeft;
            Width = s.WindowWidth;
            Height = s.WindowHeight;
        }


        private void SaveSettings(MainViewModel model)
        {
            var s = Settings.Default;
            // Save Settings

            // Save Window State
            s.WindowState = WindowState;
            s.WindowTop = Top;
            s.WindowLeft = Left;
            s.WindowWidth = Width;
            s.WindowHeight = Height;
            s.Save();
        }

    }
}
