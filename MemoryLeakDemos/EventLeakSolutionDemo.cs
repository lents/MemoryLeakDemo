using System;

namespace MemoryLeakDemos
{
    // This class demonstrates the solution to the event memory leak.
    public class EventLeakSolutionDemo
    {
        public void Run()
        {
            var publisher = new Publisher();

            for (int i = 0; i < 100; i++)
            {
                using (var subscriber = new Subscriber(publisher))
                {
                    // The subscriber is used here...
                }
                // ...and is disposed of here, unsubscribing from the event.
            }

            publisher.DoSomething();

            Console.WriteLine("EventLeakSolutionDemo completed. Check memory usage.");
        }

        public class Publisher
        {
            public event EventHandler MyEvent;

            public void DoSomething()
            {
                MyEvent?.Invoke(this, EventArgs.Empty);
            }
        }

        public class Subscriber : IDisposable
        {
            private readonly Publisher _publisher;

            public Subscriber(Publisher publisher)
            {
                _publisher = publisher;
                _publisher.MyEvent += OnMyEvent;
            }

            private void OnMyEvent(object? sender, EventArgs e)
            {
                // This method will be called when the event is raised.
            }

            public void Dispose()
            {
                _publisher.MyEvent -= OnMyEvent;
            }
        }
    }
}
