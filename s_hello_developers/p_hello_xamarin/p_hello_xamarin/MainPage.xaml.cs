using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models;

namespace p_hello_xamarin
{
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {





        private static readonly List<VisualFeatureTypes> features =
            new List<VisualFeatureTypes>()
            {
                VisualFeatureTypes.Categories,
                VisualFeatureTypes.Description,
                VisualFeatureTypes.Faces,
                VisualFeatureTypes.ImageType,
                VisualFeatureTypes.Tags
            };

        public MainPage()
        {
            InitializeComponent();

            ComputerVisionClient computerVision = new ComputerVisionClient(
                new ApiKeyServiceClientCredentials("key"),
                new System.Net.Http.DelegatingHandler[] { });

            // You must use the same region as you used to get your subscription

            // Specify the Azure region
            computerVision.Endpoint = "https://westcentralus.api.cognitive.microsoft.com/vision/v2.1";

            var t1 = ""; //AnalyzeRemoteAsync(computerVision, remoteImageUrl);
            var t2 = ""; //AnalyzeLocalAsync(computerVision, localImagePath);

            //Task.WhenAll(t1, t2).Wait(5000);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            DisplayAlert("رسالة", " السلام عليكم", "إلغاء");
        }
    }
}