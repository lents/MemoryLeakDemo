using System;

namespace MemoryLeakDemos
{
    // This class demonstrates the solution to the delegate memory leak.
    public class DelegateLeakSolutionDemo
    {
        public void Run()
        {
            var manager = new Manager();

            for (int i = 0; i < 100; i++)
            {
                var worker = new DelegateWorker();
                manager.Register(worker.DoWork);
                // In a real application, you would unregister the delegate when the worker is no longer needed.
                // For this demo, we'll unregister it immediately.
                manager.Unregister(worker.DoWork);
            }

            manager.DoWork();

            Console.WriteLine("DelegateLeakSolutionDemo completed. Check memory usage.");
        }

        public class Manager
        {
            private Action? _work;

            public void Register(Action work)
            {
                _work += work;
            }

            public void Unregister(Action work)
            {
                _work -= work;
            }

            public void DoWork()
            {
                _work?.Invoke();
            }
        }

        public class DelegateWorker
        {
            public void DoWork()
            {
                // This method will be called when the manager's DoWork method is called.
            }
        }
    }
}
