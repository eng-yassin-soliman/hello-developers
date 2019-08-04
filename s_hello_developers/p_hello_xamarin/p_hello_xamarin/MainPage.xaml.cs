using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace p_hello_xamarin
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            OrientationSensor.ReadingChanged += v_orientation_;
            OrientationSensor.Start(SensorSpeed.UI);
        }

        void v_orientation_(object p_snd_, OrientationSensorChangedEventArgs p_arg_)
        {
            var l_dta_ = p_arg_.Reading;

            b_txt_.Text =
                l_dta_.Orientation.X.ToString("0.00") + " & " +
                l_dta_.Orientation.Y.ToString("0.00") + " & " +
                l_dta_.Orientation.Z.ToString("0.00") + " & " +
                l_dta_.Orientation.W.ToString("0.00");
        }
    }
}