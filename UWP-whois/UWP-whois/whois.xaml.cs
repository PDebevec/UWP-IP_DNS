using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.ServiceModel.Channels;
using System.Text;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace UWP_whois
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class whois : Page
    {
        public whois()
        {
            this.InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            //base.OnNavigatedTo(e);

            if(e.Parameter is ipapi jsondata)
            {
                ip.Text += jsondata.ip;
                network.Text += jsondata.network;
                version.Text += jsondata.version;
                city.Text += jsondata.city;
                region.Text += jsondata.region;
                region_code.Text += jsondata.region_code;
                country.Text += jsondata.country;
                country_name.Text += jsondata.country_name;
                country_code.Text += jsondata.country_code;
                country_code_iso3.Text += jsondata.country_code_iso3;
                country_capital.Text += jsondata.country_capital;
                country_tld.Text += jsondata.country_tld;
                continent_code.Text += jsondata.continent_code;
                in_eu.Text += jsondata.in_eu;
                postal.Text += jsondata.postal;
                latitude.Text += jsondata.latitude;
                longitude.Text += jsondata.longitude;
                timezone.Text += jsondata.timezone;
                utc_offset.Text += jsondata.utc_offset;
                country_calling_code.Text += jsondata.country_calling_code;
                currency.Text += jsondata.currency;
                currency_name.Text += jsondata.currency_name;
                languages.Text += jsondata.languages;
                country_area.Text += jsondata.country_area;
                country_population.Text += jsondata.country_population;
                asn.Text += jsondata.asn;
                org.Text += jsondata.org;
            }
            else this.Frame.Navigate(typeof(MainPage));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }
    }
}
