using System;
using System.Threading;

namespace MemoryLeakDemos
{
    // This class demonstrates the solution to the timer memory leak.
    public class TimerLeakSolutionDemo
    {
        public void Run()
        {
            for (int i = 0; i < 100; i++)
            {
                using (var worker = new TimerWorker())
                {
                    worker.Start();
                }
            }

            Console.WriteLine("TimerLeakSolutionDemo completed. Check memory usage.");
        }

        public class TimerWorker : IDisposable
        {
            private Timer? _timer;

            public void Start()
            {
                _timer = new Timer(OnTimerTick, null, 0, 1000);
            }

            private void OnTimerTick(object? state)
            {
                // This method will be called every second.
            }

            public void Dispose()
            {
                _timer?.Dispose();
            }
        }
    }
}
