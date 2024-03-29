﻿using System;
using System.Threading.Tasks;
using Tesseract;
using Xamarin.Forms;
using XLabs.Ioc;
using Xamarin.Essentials;
using System.IO;
using SkiaSharp;

namespace p_scratchy
{
    public partial class MainPage : ContentPage
    {
        ITesseractApi g_tss;
        SKBitmap g_bmp = new SKBitmap();

        public MainPage()
        {
            InitializeComponent();

            g_tss = Resolver.Resolve<ITesseractApi>();
            g_tss.Init("eng", OcrEngineMode.TesseractOnly);
        }

        async Task v_process(FileResult p_res)
        {
            if (p_res.FileName == null) { return; }

            var l_pth = p_res.FullPath;

            g_bmp = SKBitmap.Decode(new FileStream(l_pth, FileMode.Open));
            u_img.Source = ImageSource.FromStream(() => new FileStream(l_pth, FileMode.Open));
        }

        async void v_pick(object p_snd, EventArgs p_arg)
        {
            var l_res = await MediaPicker.PickPhotoAsync();
            await v_process(l_res);
        }

        async void v_capture(object p_snd, EventArgs p_arg)
        {
            var l_res = await MediaPicker.CapturePhotoAsync();
            await v_process(l_res);
        }

        async void v_message(object p_snd, EventArgs p_arg)
        { 
            await Device.InvokeOnMainThreadAsync(() =>
            {
                try
                {
                    u_msg.Text = "width: " + g_bmp.Width.ToString() + ", height: " + g_bmp.Height.ToString();
                    u_ms2.Text = "X: " + u_img.X.ToString() + ", Y: " + u_img.Y.ToString() + ", scale: " + u_img.Scale.ToString();
                }
                catch (Exception p_exp)
                {
                    u_msg.Text = p_exp.Message;
                }
            });
        }

        async Task v_recognize(Stream p_str)
        {
            try
            {
                await g_tss.SetImage(p_str);
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "Cancel");
            }
            finally
            {
                //activityIndicator.IsRunning = false;
            }

            await DisplayAlert("Ok", g_tss.Text, "Cancel");
            //var words = g_tss.Results(PageIteratorLevel.Word);
            //var symbols = g_tss.Results(PageIteratorLevel.Symbol);
            //var blocks = g_tss.Results(PageIteratorLevel.Block);
            //var paragraphs = g_tss.Results(PageIteratorLevel.Paragraph);
            //var lines = g_tss.Results(PageIteratorLevel.Textline);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            Device.BeginInvokeOnMainThread(() =>
            {
                u_rct.HeightRequest = Width * 0.13; // Aspect ratio
            });
        }
    }
}