using System.Collections.Generic;
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

        private string CallNaiveBayes(string input)
        {
            return "Masculino";
        }

        private void btnRun_Click(object sender, RoutedEventArgs e)
        {
            var inputs = new string[] { txtInput1.Text, txtInput2.Text, txtInput3.Text };

            var results = inputs.Select(input => CallNaiveBayes(input)).ToArray();

            lblResult1.Content = results[0];
            lblResult2.Content = results[1];
            lblResult3.Content = results[2];
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            txtInput1.Clear();
            txtInput2.Clear();
            txtInput3.Clear();

            lblResult1.Content = "";
            lblResult2.Content = "";
            lblResult3.Content = "";
        }
    }
}
