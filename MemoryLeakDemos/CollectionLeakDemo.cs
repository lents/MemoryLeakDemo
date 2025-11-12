using System;
using System.Collections.Generic;

namespace MemoryLeakDemos
{
    // This class demonstrates a memory leak caused by a collection that is not cleared.
    public class CollectionLeakDemo
    {
        public void Run()
        {
            var dataStore = new DataStore();

            for (int i = 0; i < 100; i++)
            {
                var data = new byte[1024 * 1024]; // 1MB
                dataStore.Add(data);
            }

            Console.WriteLine("CollectionLeakDemo completed. Check memory usage.");
        }
    }

    public class DataStore
    {
        private static readonly List<byte[]> _data = new List<byte[]>();

        public void Add(byte[] data)
        {
            _data.Add(data);
        }
    }
}
