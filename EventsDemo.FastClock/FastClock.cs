using System;
using System.Windows.Threading;

namespace EventsDemo.FastClock
{
   public class FastClock
   {
      private readonly DispatcherTimer _timer;
      private bool _isRunning;
      public event EventHandler<DateTime> OneMinuteIsOver;
      public double Mply { get; set; }
      public DateTime CurrentTime { get; private set; }
      public bool IsRunning
      {
         get => _isRunning;
         set 
         {
            if(!_isRunning && value)
            {
               _timer.Start();
            }
            if(_isRunning && !value)
            {
               _timer.Stop();
            }
            _isRunning = value;
         }
      }
      public FastClock(DateTime dateTime)
      {
         CurrentTime = dateTime;
         _timer = new DispatcherTimer();
         _timer.Tick += OnTimerTick;
         _timer.Interval = TimeSpan.FromMilliseconds(1);
      }

      private void OnTimerTick(object sender, EventArgs e)
      {
         CurrentTime = CurrentTime.AddMinutes(Mply/1000);
         OnOneMinuteIsOver(CurrentTime);
      }

      protected virtual void OnOneMinuteIsOver(DateTime currentTime)
      {
         OneMinuteIsOver?.Invoke(this, currentTime);
      }
   }
}
