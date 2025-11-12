using System;
using System.Threading;

namespace MemoryLeakDemos
{
    // This class demonstrates a memory leak caused by a timer that is not disposed.
    public class TimerLeakDemo
    {
        public void Run()
        {
            for (int i = 0; i < 100; i++)
            {
                var worker = new TimerWorker();
                worker.Start();
            }

            Console.WriteLine("TimerLeakDemo completed. Check memory usage.");
        }
    }

    public class TimerWorker
    {
        private Timer _timer;

        public void Start()
        {
            _timer = new Timer(OnTimerTick, null, 0, 1000);
        }

        private void OnTimerTick(object state)
        {
            // This method will be called every second.
        }
    }
}
