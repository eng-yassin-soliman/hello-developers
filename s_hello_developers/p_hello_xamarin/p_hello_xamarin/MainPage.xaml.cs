using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.ComponentModel;
using Xamarin.Forms;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;

namespace p_hello_xamarin
{
    [DesignTimeVisible(true)]
    public partial class MainPage : ContentPage
    {
        MediaFile s_pic_;
        string s_key_ = "c3318aca676c4592adc99af635a0ced6";
        string s_end_ = "https://westcentralus.api.cognitive.microsoft.com";

        public MainPage()
        {
            InitializeComponent();

            b_cap_.Clicked += v_capture_;
            b_img_.Clicked += v_image_;
            b_txt_.Clicked += v_text_;
        }

        async void v_capture_(object p_snd_, EventArgs p_arg_)
        {
            s_pic_ = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
            {
                PhotoSize = PhotoSize.Custom,   // Resize to 10% of original
                CustomPhotoSize = 10            // for better performance
            });

            if (s_pic_ == null) { return; }

            b_pic_.Source = ImageSource.FromStream(() =>
            {
                return s_pic_.GetStream();
            });
        }

        async void v_image_(object p_snd_, EventArgs p_arg_)
        {
            // Submit the image to Azure's Computer Vision API
            ComputerVisionClient l_vis_ = new ComputerVisionClient(new ApiKeyServiceClientCredentials(s_key_))
            { Endpoint = s_end_ };

            List<VisualFeatureTypes> l_fet_ = // Features to detect
                new List<VisualFeatureTypes>()
                {
                    VisualFeatureTypes.Description,
                    VisualFeatureTypes.Categories,
                    VisualFeatureTypes.Faces,
                    VisualFeatureTypes.ImageType,
                    VisualFeatureTypes.Tags,
                    VisualFeatureTypes.Brands,
                    VisualFeatureTypes.Color,
                    VisualFeatureTypes.Objects
                };

            ImageAnalysis l_ans_ = await l_vis_.AnalyzeImageInStreamAsync(s_pic_.GetStream(), l_fet_);
            string l_des_ = l_ans_.Description.Captions[0].Text;

            string l_tra_ = _c_translation.f_translate_(l_des_);
            await DisplayAlert("الكاميرا", l_tra_, "Ok");
        }

        async void v_text_(object p_snd_, EventArgs p_arg_)
        {
            ComputerVisionClient l_vis_ = new ComputerVisionClient(new ApiKeyServiceClientCredentials(s_key_))
            { Endpoint = s_end_ };

            BatchReadFileInStreamHeaders l_hed_ = 
                await l_vis_.BatchReadFileInStreamAsync(s_pic_.GetStream());

            string l_oid_ = l_hed_.OperationLocation.ToString().Substring(l_hed_.OperationLocation.Length - 36);

            Thread.Sleep(4000);

            ReadOperationResult l_res_ = await l_vis_.GetReadOperationResultAsync(l_oid_);

            foreach (TextRecognitionResult i_res_ in l_res_.RecognitionResults)
            {
                foreach (Line i_lin_ in i_res_.Lines)
                {
                    await DisplayAlert("الكاميرا", i_lin_.Text, "Ok");
                }
            }
        }
    }
}