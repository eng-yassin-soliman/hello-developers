﻿using System;
using Xamarin.Forms;
using System.ComponentModel;

namespace p_hello_xamarin
{
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        void v_clicked_(object sender, EventArgs e)
        {
            try
            {
                Double l_1st_ = Double.Parse(b_1st_.Text);
                Double l_2nd_ = Double.Parse(b_2nd_.Text);

                Double l_res_ = l_1st_ * l_2nd_;

                b_res_.Text = l_res_.ToString();
            }
            catch
            {
                b_res_.BackgroundColor = Color.LightYellow;
                b_res_.Text = "خطأ في المدخلات";
            }
        }
    }
}