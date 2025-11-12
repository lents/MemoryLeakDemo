using System;

namespace MemoryLeakDemos
{
    // This class demonstrates a memory leak caused by a delegate holding a reference to an object.
    public class DelegateLeakDemo
    {
        public void Run()
        {
            var manager = new Manager();

            for (int i = 0; i < 100; i++)
            {
                var worker = new DelegateWorker();
                manager.Register(worker.DoWork);
            }

            manager.DoWork();

            Console.WriteLine("DelegateLeakDemo completed. Check memory usage.");
        }
    }

    public class Manager
    {
        private Action _work;

        public void Register(Action work)
        {
            _work += work;
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
