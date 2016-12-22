using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Tasks;
using Microsoft.Phone.Net.NetworkInformation;
using System.Text;

namespace miscellaneous
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            FillListBox();

            //TEST
            string newPass = "5797";
            string theNonce = "6E371C77";//1E1";
            string xoredValue = getXORedNewPass(newPass,theNonce);
            string orgValue = getXORedNewPass(xoredValue, theNonce);
            System.Diagnostics.Debug.WriteLine("xoredValue: " + xoredValue);
            System.Diagnostics.Debug.WriteLine( "orgValue: " + orgValue);
            //TEST


            //testing the code from image
            var _listBox = listBox1 as ListBox;
           // foreach (var _listBoxItem in _listBox.Items)
            for(int i=0; i<_listBox.Items.Count ;i++)
            {
                var _container = _listBox.ItemContainerGenerator.ContainerFromIndex(i);
                //var _container = _listBox.ItemContainerGenerator.ContainerFromItem(_listBoxItem);
                if (_container == null) continue;
                var _children = AllChildren(_container);
                var _name = "actorsName";
                var _control  = (TextBox)_children.First(c => c.Name == _name);
                //TO DO
                if (_control is TextBox)
                {
                    TextBox tb = _control as TextBox;
                    tb.FontSize = 20;
                }
            }
            //testing the code from image


            my_list.ItemsSource = new List<string>() { "Option 1", "Option 2", "Option 3", "Option 4", "Option 5", "Option 6" };
            string info="";

            var CellularNetwork = Microsoft.Phone.Net.NetworkInformation.DeviceNetworkInformation.CellularMobileOperator;
            info += "CellularNetwork: " + CellularNetwork;
            //Microsoft.Phone.Net.NetworkInformation.NetworkInterfaceInfo nti = Microsoft.Phone.Net.NetworkInformation.NetworkInterfaceType.MobileBroadbandGsm;
            var NetworkType = Microsoft.Phone.Net.NetworkInformation.NetworkInterfaceType.MobileBroadbandGsm ; //nti.InterfaceType;
            info += "\nNetworkType: " + NetworkType;


            string testInfos="";
            string countryCode = System.Globalization.CultureInfo.CurrentCulture.Name;
            testInfos += countryCode;
            try
            {
                System.Globalization.RegionInfo reg = new System.Globalization.RegionInfo(countryCode);
                string name = reg.Name; testInfos += name;
                string displayname = reg.DisplayName; testInfos += displayname;
                string ISORegion = reg.TwoLetterISORegionName; testInfos += ISORegion;
                string currency = reg.CurrencySymbol; testInfos += currency;
                string eng = reg.EnglishName; testInfos += eng;
                string native = reg.NativeName; testInfos += native;
            }
            catch (ArgumentException argEx)
            {
                // The country code was not valid 
            }

            //trying to get cell id or cell tower id
            NetworkInterfaceList networkInterfaceList = new NetworkInterfaceList();
            foreach (NetworkInterfaceInfo networkInterfaceInfo in networkInterfaceList)
            {
                if (networkInterfaceInfo.InterfaceSubtype == NetworkInterfaceSubType.Cellular_HSPA)
                {
                    MessageBox.Show(networkInterfaceInfo.InterfaceSubtype.ToString());
                }
            }


            //MessageBox.Show(CellularNetwork);
            //MessageBox.Show(System.Globalization.RegionInfo.CurrentRegion.TwoLetterISORegionName);
           // MessageBox.Show( HostInformation.PublisherHostId);
            //var id = Microsoft.Phone.Info.DeviceExtendedProperties.GetValue("DeviceUniqueId");
            //byte[] thisID = id as byte[];
            //string s = System.Text.Encoding.UTF8.GetString(thisID, 0, thisID.Length);
            //string msg = thisID.ToString();
            //MessageBox.Show( s);

            byte[] myDeviceID = (byte[])Microsoft.Phone.Info.DeviceExtendedProperties.GetValue("DeviceUniqueId");
            string DeviceIDAsString = Convert.ToBase64String(myDeviceID);
            //MessageBox.Show(DeviceIDAsString);

            string OriginalMobileOperatorName = (string)Microsoft.Phone.Info.DeviceExtendedProperties.GetValue("OriginalMobileOperatorName");
            info += "\nOriginalMobileOperatorName: " + OriginalMobileOperatorName;
            //MessageBox.Show(info);

            //SmsComposeTask smsComposeTask = new SmsComposeTask();

            //smsComposeTask.To = "2065550123";
            //smsComposeTask.Body = "Try this new application. It's great!";

            //smsComposeTask.Show();


          //string msg =  System.Windows.Phone.System.Analytics.HostInformation.PublisherHostId;
            //object uniqueId;
            //var hexString = string.Empty;
            //if (Microsoft.Phone.Info.DeviceExtendedProperties.TryGetValue("DeviceUniqueId", out uniqueId))
                //hexString = BitConverter.ToString((byte[])uniqueId).Replace("-", string.Empty);
            //MessageBox.Show("myDeviceID:" + hexString);

        }


        private string getXORedNewPass(string pass, string nonce)
        {

            String xoredPass = "";

            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < pass.Length; i++)
            {
                builder.Append((char)(pass.ToCharArray().ElementAt(i) ^ nonce.ToCharArray().ElementAt(i % nonce.Length)));
                xoredPass = builder.ToString();
            }
            return xoredPass;
        }

        private string OLD_getXORedNewPass(string newPass, string theNonce)
        {

            byte[] pass = Encoding.Unicode.GetBytes(newPass);
            byte[] nonce = Encoding.Unicode.GetBytes(theNonce);
            int passLen = pass.Length;

            byte[] result = new byte[passLen];
            for (int i = 0; i < passLen; i++)
            {
                result[i] = (byte)(pass[i] ^ nonce[i % nonce.Length]);
            }

            return Encoding.Unicode.GetString(result, 0, passLen);
        }

        public List<Control> AllChildren(DependencyObject parent)
        {
            var _list = new List<Control> ();
            
            for (int j = 0; j < VisualTreeHelper.GetChildrenCount(parent); j++)
            {
                var _child = VisualTreeHelper.GetChild(parent, j);
                if (_child is Control)
                    _list.Add(_child as Control);
                _list.AddRange(AllChildren(_child));
            }
            return _list;
        }

        private void FillListBox()
        {
            //listBox1.ItemsSource = 
            MovieList moviesList = new MovieList();
            listBox1.DataContext = moviesList;
        }

        //Variables to store the count of checked Checkboxes and their data
        string option_selected = "";
        int check_count = 0;

        //SearchElement populates above variables for checkboxes in specified "targeted_control"
        private void SearchElement(DependencyObject targeted_control)
        {
            var count = VisualTreeHelper.GetChildrenCount(targeted_control);   // targeted_control is the listbox
            if (count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    var child = VisualTreeHelper.GetChild(targeted_control, i);
                    if (child is CheckBox) // specific/child control 
                    {
                        CheckBox targeted_element = (CheckBox)child;
                        if (targeted_element.IsChecked == true)
                        {
                            if (option_selected != "")
                            {
                                option_selected = option_selected + " , " + targeted_element.Tag;
                            }
                            else
                            {
                                // get the value associated with the "checked" checkbox  
                                option_selected = targeted_element.Tag.ToString();
                            }
                            // count the number of "Checked" checkboxes
                            check_count = check_count + 1;
                            return;
                        }
                    }
                    else
                    {
                        SearchElement(child);
                    }
                }
            }
            else
            {
                return;
            }
        }

        private void cbx_state_Checked(object sender, RoutedEventArgs e)
        {
            check_count = 0;
            option_selected = "";
            SearchElement(my_list);
            MessageBox.Show(" Total Selected Checkboxes : " + check_count.ToString()
                 + Environment.NewLine + " Value Associated : " + option_selected);
        }

        private void cbx_state_Unchecked(object sender, RoutedEventArgs e)
        {
            check_count = 0;
            option_selected = "";
            SearchElement(my_list);
            MessageBox.Show(" Total Selected Checkboxes : " + check_count.ToString()
                + Environment.NewLine + " Value Associated : " + option_selected);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //try
            //{
            //    Windows.System.Launcher.LaunchUriAsync(new Uri("ms-settings-wifi:"));
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
            NavigationService.Navigate(new Uri("/TestingPage.xaml", UriKind.Relative));
            //NavigationService.Navigate(new Uri("/AnimationPage.xaml",UriKind.Relative));
        }


    }

    public class MovieList : List<Movie>
    {
        public MovieList()
        {
            Add(new Movie { Name = "Kaavalan", Actor = "Vijay", });
            Add(new Movie { Name = "Velayutham", Actor = "Vijay", });
            Add(new Movie { Name = "7th Sense", Actor = "Surya", });
            Add(new Movie { Name = "Billa 2", Actor = "Ajith Kumar", });
            Add(new Movie { Name = "Nanban", Actor = "Vijay", });

        }
    }


    public class Movie
    {
        public string Actor { get; set; }
        public string Name { get; set; }

    }
}