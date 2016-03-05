namespace TrainYourBrain.Xamarin.Windows
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();

            LoadApplication(new TrainYourBrain.Core.App());
        }
    }
}
