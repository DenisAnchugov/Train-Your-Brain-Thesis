using Microsoft.Phone.Controls;
using Xamarin.Forms.Platform.WinPhone;

namespace TrainYourBrain.WinPhone
{
    public partial class MainPage : FormsApplicationPage
    {
        public MainPage()
        {
            SupportedOrientations = SupportedPageOrientation.PortraitOrLandscape;

            global::Xamarin.Forms.Forms.Init();
            LoadApplication(new TrainYourBrain.Core.App());
        }
    }
}