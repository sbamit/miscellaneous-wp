using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
//using Windows.System;

namespace miscellaneous
{
    public partial class TestingPage : PhoneApplicationPage
    {
        public TestingPage()
        {
            InitializeComponent();
            this.lbUriCommands.ItemsSource = this.GetUriCommandList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (button == null)
            {
                return;
            }
            UriCommand uriCommand = button.DataContext as UriCommand;
            if (uriCommand != null)
            {
                try
                {
                    Windows.System.Launcher.LaunchUriAsync(new Uri(uriCommand.Uri));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        public IEnumerable<UriCommand> GetUriCommandList()
        {
            return new List<UriCommand>()
            {
                new UriCommand() { 
                    Title = "iTel Mobile Dialer", 
                    ImageUri = "/Images/logo.png", 
                    Uri = "itelmobiledialer:?param1=value1&param2=value2"
                },
                new UriCommand() { 
                    Title = "Location settings", 
                    ImageUri = "/Images/location.png", 
                    Uri = "ms-settings-location:"
                },
                new UriCommand() { 
                    Title = "WiFi settings", 
                    ImageUri = "/Images/wifi.png", 
                    Uri="ms-settings-wifi:"
                },
                new UriCommand() { 
                    Title = "Lock settings", 
                    ImageUri = "/Images/lock.png", 
                    Uri = "ms-settings-lock:"
                },
                new UriCommand() { 
                    Title = "Wallet", 
                    ImageUri = "/Images/wallet.png", 
                    Uri = "wallet:"
                }
            };
        }
       
    }

    public class UriCommand
    {
        public string Title { get; set; }
        public string Uri { get; set; }
        public string ImageUri { get; set; }
    }
}