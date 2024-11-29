using System;
using System.Threading;

namespace ClockAndDisplay
{
    public class TimeEventArgs : EventArgs
    {
        public DateTime _CurrentTime;

        public TimeEventArgs(DateTime currentTime)
        {
            _CurrentTime = currentTime;
        }
    }

    public class Clock
    {
        public event EventHandler<TimeEventArgs> SecondChanged;

        public void Start()
        {
            while (true)
            {
                Thread.Sleep(1000);
                OnSecondChanged();
            }
        }

        protected virtual void OnSecondChanged()
        {
            TimeEventArgs arg = new TimeEventArgs(DateTime.Now);
            SecondChanged?.Invoke(this, arg);
        }
    }

    public class Display
    {
        public void UpdateDisplay(object sender, TimeEventArgs e)
        {
           Console.WriteLine($"Current Time: {e._CurrentTime:hh:mm:ss tt}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("********** Clock And Display **********\n");

            Clock clock = new Clock();
            Display display = new Display();

            clock.SecondChanged += display.UpdateDisplay;

            clock.Start();

            Console.ReadLine();
        }
    }
}
