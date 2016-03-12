using System.ComponentModel;
using System.Runtime.CompilerServices;
using TrainYourBrain.Core.Annotations;

namespace TrainYourBrain.Core
{
    public class PlayerStats : INotifyPropertyChanged
    {
        int lives;
        int score;
        int level;
        int timerCount;

        public int Lives
        {
            get { return lives; }
            set
            {
                if (lives == value) return;
                lives = value;
                OnPropertyChanged();
            }
        }

        public int Score
        {
            get { return score; }
            set
            {
                if (score == value) return;
                score = value;
                OnPropertyChanged();
            }
        }

        public int Level
        {
            get { return level; }
            set
            {
                if (level == value) return;
                level = value;
                OnPropertyChanged();
            }
        }

        public int TimerCount
        {
            get { return timerCount; }
            set
            {
                if (timerCount == value) return;
                timerCount = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}