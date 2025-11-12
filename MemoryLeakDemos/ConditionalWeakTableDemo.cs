using System;
using System.Runtime.CompilerServices;

namespace MemoryLeakDemos
{
    // This class demonstrates how to use ConditionalWeakTable to associate data with an object without creating a strong reference.
    public class ConditionalWeakTableDemo
    {
        public void Run()
        {
            var manager = new Manager();
            var key = new object();
            manager.SetData(key, "some data");

            // The key is now out of scope and can be garbage collected.
            // The ConditionalWeakTable will automatically remove the entry.
            key = null;

            GC.Collect();
            GC.WaitForPendingFinalizers();

            Console.WriteLine($"ConditionalWeakTableDemo completed. Data is still alive: {manager.IsDataAlive}");
        }

        public class Manager
        {
            private readonly ConditionalWeakTable<object, string> _table = new ConditionalWeakTable<object, string>();
            private WeakReference<string> _weakRefToData;

            public void SetData(object key, string data)
            {
                _table.Add(key, data);
                _weakRefToData = new WeakReference<string>(data);
            }

            public bool IsDataAlive
            {
                get
                {
                    return _weakRefToData.TryGetTarget(out _);
                }
            }
        }
    }
}
