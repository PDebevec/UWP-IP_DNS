using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Json;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UWP_whois
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            if (domena.Text == "")
            {
                if (ip.Text == "")
                {
                    return;
                }
                else
                {
                    try
                    {
                        using (HttpClient client = new HttpClient())
                        {
                            test.Text = ip.Text;
                            client.DefaultRequestHeaders.Add("User-Agent", "ipapi.co/#c-sharp-v1.03");
                            string apiUrl = "https://ipapi.co/"+ ip.Text +"/json/";

                            HttpResponseMessage response = await client.GetAsync(apiUrl);
                            test.Text = response.StatusCode.ToString();
                            response.EnsureSuccessStatusCode();

                            string jsonResponse = await response.Content.ReadAsStringAsync();
                            test.Text = jsonResponse;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"An error occurred: {ex.Message}");
                    }
                }
            }
            else
            {
                try
                {
                    using (HttpClient client = new HttpClient())
                    {
                        test.Text = domena.Text;
                        string apiUrl = "https://networkcalc.com/api/dns/lookup/" + domena.Text;

                        HttpResponseMessage response = await client.GetAsync(apiUrl);
                        response.EnsureSuccessStatusCode();

                        string jsonResponse = await response.Content.ReadAsStringAsync();
                        test.Text = jsonResponse;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
            }
        }
    }
}
