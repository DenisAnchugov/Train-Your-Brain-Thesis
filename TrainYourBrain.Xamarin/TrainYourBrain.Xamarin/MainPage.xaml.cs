using Xamarin.Forms;

namespace TrainYourBrain.Core
{
    public partial class MainPage : ContentPage
    {
        public MainPage(MainPageViewModel viewModel)
        {
            BindingContext = viewModel;
            InitializeComponent();

        }
    }
}
