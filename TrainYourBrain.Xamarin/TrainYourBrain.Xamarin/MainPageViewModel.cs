using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using TrainYourBrain.Core.Annotations;
using Xamarin.Forms;

namespace TrainYourBrain.Core
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        ExpressionFactory expressionFactory;
        ITimer timer;

        PlayerStats playerStats;
        Expression expression;
        string expressionString;
        bool isInputEnabled;

        public PlayerStats PlayerStats
        {
            get { return playerStats; }
            set
            {
                if (playerStats == value) return;
                playerStats = value;
                OnPropertyChanged();
            }
        }

        public bool IsInputEnabled
        {
            get { return isInputEnabled; }
            set
            {
                if (isInputEnabled == value) return;
                isInputEnabled = value;
                OnPropertyChanged();
            }
        }

        public string ExpressionString
        {
            get { return expressionString; }
            set
            {
                if (expressionString == value) return;
                expressionString = value;
                OnPropertyChanged();
            }
        }

        public ICommand StartCommand { get; set; }
        public ICommand CheckAnswerCommand { get; set; }

        public MainPageViewModel(ExpressionFactory expressionFactory, ITimer timer)
        {
            this.timer = timer;
            this.expressionFactory = expressionFactory;
            StartCommand = new Command(StartRound);
            CheckAnswerCommand = new Command<int>(CheckAnswer);

        }

        void InitializePlayerStats()
        {
            PlayerStats = new PlayerStats()
            {
                Level = 1,
                Lives = 3,
                Score = 0,
                TimerCount = 5
            };
        }

        void CheckAnswer(int answer)
        {
            if (PlayerStats.Lives == 0) return;
            if (expression.CheckAnswer(answer))
            {
                PlayerStats.Score++;
            }
            else
            {
                PlayerStats.Lives--;
            }
            DeployExpression();
            PlayerStats.TimerCount = 5;
        }

        void StartRound()
        {
            IsInputEnabled = true;
            timer.Stop();
            InitializePlayerStats();
            DeployExpression();
            timer.Start(OnTick, TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(1));
        }

        void DeployExpression()
        {
            if (PlayerStats.Lives != 0)
            {
                expression = expressionFactory.CreateExpression(PlayerStats.Level);
                ExpressionString = expression.ToString();
            }
            else
            {
                EndGame();
            }
        }

        void OnTick()
        {
            PlayerStats.TimerCount--;
            if (PlayerStats.TimerCount != 0) return;

            PlayerStats.Lives--;
            DeployExpression();
            PlayerStats.TimerCount = 5;
        }

        void EndGame()
        {
            timer.Stop();
            IsInputEnabled = false;
            ExpressionString = $"Game over. Your score: {PlayerStats.Score}";
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
