using Xamarin.Forms;

namespace TrainYourBrain.Core
{
    public class App : Application
    {
        public App(ITimer timer)
        {
            MainPage = new MainPage(new MainPageViewModel(new ExpressionFactory(), timer));
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
