using System;
using System.Collections.Generic;
using System.Linq;

namespace MemoryLeakDemos
{
    // This class demonstrates how to use WeakReference to avoid memory leaks in collections.
    public class WeakReferenceDemo
    {
        public void Run()
        {
            var dataStore = new WeakDataStore();

            for (int i = 0; i < 100; i++)
            {
                var data = new byte[1024 * 1024]; // 1MB
                dataStore.Add(data);
            }

            // Force a garbage collection to demonstrate that the objects are being collected.
            GC.Collect();
            GC.WaitForPendingFinalizers();

            Console.WriteLine($"WeakReferenceDemo completed. Items in collection: {dataStore.Count}");
        }
    }

    public class WeakDataStore
    {
        private readonly List<WeakReference<byte[]>> _data = new List<WeakReference<byte[]>>();

        public void Add(byte[] data)
        {
            _data.Add(new WeakReference<byte[]>(data));
        }

        public int Count
        {
            get
            {
                // Remove dead references before returning the count.
                _data.RemoveAll(wr => !wr.TryGetTarget(out _));
                return _data.Count;
            }
        }
    }
}
