using System;
using System.Threading;
using TrainYourBrain.Core;

namespace TrainYourBrain.Xamarin.Droid
{
    public class AndroidTimer : ITimer
    {
        Timer timer;

        public void Start(Action toExecute, TimeSpan period, TimeSpan dueTime)
        {
            timer?.Dispose();
            timer = new Timer(state => toExecute(), null, dueTime, period);
        }

        public void Stop()
        {
            timer?.Dispose();
        }
    }
}