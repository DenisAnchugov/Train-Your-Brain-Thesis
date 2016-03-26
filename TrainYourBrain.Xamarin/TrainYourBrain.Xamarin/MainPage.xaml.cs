using System;
using Xamarin.Forms;

namespace TrainYourBrain.Core
{
    public partial class MainPage : ContentPage
    {
        public MainPage(MainPageViewModel viewModel)
        {
            BindingContext = viewModel;
            InitializeComponent();
            this.Padding = new Thickness(10, Device.OnPlatform(20, 0, 10), 10, 5);

            foreach (View view in InputGrid.Children)
            {
                view.SetBinding(View.IsEnabledProperty, "IsInputEnabled");
            }
        }

        void AppendChar_OnClicked(object sender, EventArgs e)
        {
            AnswerField.Text += (sender as Button)?.Text;
        }

        void SubmitAnswer_OnClicked(object sender, EventArgs e)
        {
            if (AnswerField.Text.Length == 0) return;
            var viewModel = BindingContext as MainPageViewModel;
            viewModel?.CheckAnswerCommand.Execute(int.Parse(AnswerField.Text));
            ClearAnswerField();
        }

        void Erase_OnClicked(object sender, EventArgs e)
        {
            if (AnswerField.Text.Length == 0) return;
            AnswerField.Text = AnswerField.Text.Remove(AnswerField.Text.Length - 1);
        }

        void Start_OnClicked(object sender, EventArgs e)
        {
            ClearAnswerField();
        }

        void ClearAnswerField()
        {
            AnswerField.Text = String.Empty;
        }
    }
}
