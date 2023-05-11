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
using OpenWinClash.Models;
using OpenWinClash.ViewModels;

namespace OpenWinClash
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(
            MainViewModel viewModel,
            AppGlobalData appGlobalData)
        {
            ViewModel = viewModel;
            AppGlobalData = appGlobalData;

            DataContext = this;
            InitializeComponent();
        }

        public MainViewModel ViewModel { get; }
        public AppGlobalData AppGlobalData { get; }
    }
}
