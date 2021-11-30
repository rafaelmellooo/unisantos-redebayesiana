using RedeBayesiana.UI.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace RedeBayesiana.UI
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

        private readonly List<DataItem> Data = new();

        private string CallNaiveBayes(string input)
        {
            return "Masculino";
        }

        private void btnRun_Click(object sender, RoutedEventArgs e)
        {
            var inputs = Data.Where(item => item.Gender is null).Select(item => (item, item.Name)).ToArray();

            lstData.ItemsSource = Data;
        }

        private void btnClearData_Click(object sender, RoutedEventArgs e)
        {
            lstData.Items.Clear();
        }
    }
}
