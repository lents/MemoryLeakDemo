using System;

namespace MemoryLeakDemos
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Select a memory leak demo to run:");
                Console.WriteLine("1. Events");
                Console.WriteLine("2. Timers");
                Console.WriteLine("3. Delegates");
                Console.WriteLine("4. Collections");
                Console.WriteLine("5. Exit");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        new EventLeakDemo().Run();
                        break;
                    case "2":
                        new TimerLeakDemo().Run();
                        break;
                    case "3":
                        new DelegateLeakDemo().Run();
                        break;
                    case "4":
                        new CollectionLeakDemo().Run();
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }
    }
}
