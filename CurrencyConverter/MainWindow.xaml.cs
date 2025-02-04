using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;
using Newtonsoft.Json.Linq;

namespace CurrencyConverter
{
    public partial class MainWindow : Window
    {
        private const string API_URL = "https://api.frankfurter.app/currencies"; // URL list of currencies

        public MainWindow()
        {
            InitializeComponent();
            LoadCurrencies(); // Load currencies on start
        }

        private async void LoadCurrencies()
        {
            try
            {
                using HttpClient client = new HttpClient();
                string response = await client.GetStringAsync(API_URL);
                var currencies = JObject.Parse(response);

                List<string> currencyList = new List<string>(currencies.Properties().Select(p => p.Name));

                // delete existing items
                FromCurrency.ItemsSource = null;
                ToCurrency.ItemsSource = null;

                // Lists of currencies
                FromCurrency.ItemsSource = currencyList;
                ToCurrency.ItemsSource = currencyList;

                FromCurrency.SelectedItem = "EUR"; // default currency
                ToCurrency.SelectedItem = "CZK";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Chyba při načítání měn: " + ex.Message);
            }
        }



        private async void ConvertButton_Click(object sender, RoutedEventArgs e)
        {
            if (!decimal.TryParse(AmountBox.Text, out decimal amount))
            {
                MessageBox.Show("Zadejte platnou částku.");
                return;
            }

            string fromCurrency = FromCurrency.SelectedItem.ToString();
            string toCurrency = ToCurrency.SelectedItem.ToString();

            if(fromCurrency!=toCurrency)
            {
                decimal rate = await GetExchangeRate(fromCurrency, toCurrency);
                decimal result = amount * rate;

                ResultText.Text = $"{amount} {fromCurrency} = {result:F2} {toCurrency}";
            }
            else
            {
                ResultText.Text = "Vyberte odlišné měny";
            }

            
        }

        private async Task<decimal> GetExchangeRate(string from, string to)
        {
            string url = $"https://api.frankfurter.app/latest?from={from}&to={to}";

            using HttpClient client = new HttpClient();
            string response = await client.GetStringAsync(url);
            var rates = JObject.Parse(response)["rates"];

            return rates[to].Value<decimal>();
        }
    }
}
