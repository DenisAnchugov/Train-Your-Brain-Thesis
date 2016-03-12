using System;

namespace TrainYourBrain.Core
{
    public interface ITimer
    {
        void Start(Action toExecute, TimeSpan period, TimeSpan dueTime);
        void Stop();
    }
}