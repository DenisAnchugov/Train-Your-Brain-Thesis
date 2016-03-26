using Xamarin.Forms;

namespace TrainYourBrain.Core
{
    public class App : Application
    {
        public App(ITimer timer)
        {
            var expressionFactory = new ExpressionFactory();
            var mainPageViewModel = new MainPageViewModel(expressionFactory, timer);
            MainPage = new MainPage(mainPageViewModel);
        }
    }
}
