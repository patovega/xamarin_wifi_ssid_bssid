using Android.Content;
using Android.Net.Wifi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
 

namespace App4
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(true)]
    public partial class MainPage : ContentPage
    {
        public bool IsNotConnected { get; set; }
        public MainPage()
        {
            InitializeComponent();
           
            var seconds = TimeSpan.FromSeconds(3);

            Device.StartTimer(seconds, () => {

                // call your method to check for notifications here
                Run();
                // Returning true means you want to repeat this timer
                return true;
            });

        }
        private void Run()
        {
            var text = GetCurrentSSID();
            
            lblWelcome.Text = text  ;
        }

        public string GetCurrentSSID()
        {
            string wifiInfo = "Info: ";

            try
            {
       
                WifiManager wifiManager = (WifiManager)Android.App.Application.Context.GetSystemService(Context.WifiService);
                WifiInfo info = wifiManager.ConnectionInfo;
                int networkId = info.NetworkId;

                wifiInfo = "Rssi " + info.Rssi + " SSID " + info.SSID +  "  BSSID " + info.BSSID;
             
            }
            catch (Exception ex)
            {
                wifiInfo = "Without data";
            }
           
            return wifiInfo;

        }
    }
}
