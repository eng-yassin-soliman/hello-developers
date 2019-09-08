﻿using System.ComponentModel;
using Xamarin.Forms;

namespace hello_hybrid
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
            b_web_.Source = "https://arbweb.org";
        }
    }
}