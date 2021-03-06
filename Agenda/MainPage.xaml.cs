using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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

namespace Agenda
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

        private void Home_click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));


        }

        private void Calendar_click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Calendar));


        }

        private void Notes_click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Notes));
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var position = await LocationManager.GetPosition();

            RootObject myWeather = 
                await OpenWeatherMapProxy.GetWeather(
                    position.Coordinate.Latitude, position.Coordinate.Longitude);

            ResultTextBlock.Text = myWeather.name + " - " + ((int)myWeather.main.temp).ToString() + " - " + myWeather.weather[0].description;

        }
    }
}

