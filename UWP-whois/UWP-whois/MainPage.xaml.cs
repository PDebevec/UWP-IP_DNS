﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Text.Json;
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
                if (ip.Text != "")
                {
                    try
                    {
                        using (HttpClient client = new HttpClient())
                        {
                            test.Text = ip.Text;
                            client.DefaultRequestHeaders.Add("User-Agent", "ipapi.co/#c-sharp-v1.03");
                            string apiUrl = "https://ipapi.co/" + ip.Text + "/json/";

                            HttpResponseMessage response = await client.GetAsync(apiUrl);
                            test.Text = response.StatusCode.ToString();
                            response.EnsureSuccessStatusCode();

                            string jsonResponse = await response.Content.ReadAsStringAsync();
                            ipapi json = JsonSerializer.Deserialize<ipapi>(jsonResponse);
                            //navigate
                            this.Frame.Navigate(typeof(whois), json);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"An error occurred: {ex.Message}");
                    }
                }
                else return;
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
                        Domain json = JsonSerializer.Deserialize<Domain>(jsonResponse);

                        if (ip.Text == json.records.A[0].address)
                        {
                            //navigate
                            using (HttpClient client2 = new HttpClient())
                            {
                                test.Text = ip.Text;
                                client.DefaultRequestHeaders.Add("User-Agent", "ipapi.co/#c-sharp-v1.03");
                                string apiUrl2 = "https://ipapi.co/" + ip.Text + "/json/";

                                HttpResponseMessage response2 = await client.GetAsync(apiUrl);
                                test.Text = response.StatusCode.ToString();
                                response.EnsureSuccessStatusCode();

                                string jsonResponse2 = await response.Content.ReadAsStringAsync();
                                ipapi json2 = JsonSerializer.Deserialize<ipapi>(jsonResponse);
                                //navigate
                                this.Frame.Navigate(typeof(whois), json2);
                            }
                        }
                        else
                        {
                            ip.Text = json.records.A[0].address;
                        }
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
