using System;

namespace MemoryLeakDemos
{
    // This class demonstrates a memory leak caused by a long-lived object holding a reference to a short-lived object through an event subscription.
    public class EventLeakDemo
    {
        public void Run()
        {
            var publisher = new Publisher();

            for (int i = 0; i < 100; i++)
            {
                var subscriber = new Subscriber(publisher);
            }

            // The publisher is still alive, and it holds references to all the subscriber objects.
            // Even though the subscribers are no longer in scope, they won't be garbage collected.
            publisher.DoSomething();

            Console.WriteLine("EventLeakDemo completed. Check memory usage.");
        }
    }

    public class Publisher
    {
        public event EventHandler MyEvent;

        public void DoSomething()
        {
            MyEvent?.Invoke(this, EventArgs.Empty);
        }
    }

    public class Subscriber
    {
        public Subscriber(Publisher publisher)
        {
            publisher.MyEvent += OnMyEvent;
        }

        private void OnMyEvent(object sender, EventArgs e)
        {
            // This method will be called when the event is raised.
        }
    }
}
