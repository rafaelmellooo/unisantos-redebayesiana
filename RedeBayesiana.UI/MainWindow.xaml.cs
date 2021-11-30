using RedeBayesiana.UI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace RedeBayesiana.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly HttpClient Client = new();
        private readonly SortedSet<DataItem> Data = new();

        public MainWindow()
        {
            InitializeComponent();

            lstData.ItemsSource = Data;
        }

        private async Task<string[]> GetGenders(string[] names)
        {
            var request = new StringContent(JsonSerializer.Serialize(new FunctionRequest
            {
                Names = names
            }), Encoding.UTF8, "application/json");

            var response = await Client.PostAsync("https://unisantos-rede-bayesiana.azurewebsites.net/api/naivebayesfunctions?code=WNkFyfboJtuyaXSeeWtP5sjpsoaKLnnJiHYyfqSsj6F/qnD1ddAFJQ==", request);

            var data = JsonSerializer.Deserialize<string[]>(await response.Content.ReadAsStringAsync());

            return data;
        }

        private async void btnRun_Click(object sender, RoutedEventArgs e)
        {
            var names = Data.Where(item => item.Gender is null).Select(item => item.Name).ToArray();

            var genders = await GetGenders(names);

            var i = 0;

            foreach (var item in from item in Data where item.Gender is null select item)
            {
                item.Gender = genders[i];
                i++;
            }

            lstData.Items.Refresh();
        }

        private void btnClearData_Click(object sender, RoutedEventArgs e)
        {
            Data.Clear();
            lstData.Items.Refresh();

            btnRun.IsEnabled = false;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Data.Add(new DataItem()
            {
                Name = txtInput.Text.Trim().Split(' ')[0]
            });

            lstData.Items.Refresh();

            txtInput.Clear();
            txtInput.Focus();

            if (Data.Count >= 3)
            {
                btnRun.IsEnabled = true;
            }
        }

        private void txtInput_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                btnAdd_Click(sender, e);
            }
        }
    }
}
