using System;

namespace MemoryLeakDemos
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Select a memory leak demo or solution to run:");
                Console.WriteLine("1. Events (Leak)");
                Console.WriteLine("2. Timers (Leak)");
                Console.WriteLine("3. Delegates (Leak)");
                Console.WriteLine("4. Collections (Leak)");
                Console.WriteLine("--------------------");
                Console.WriteLine("5. Events (Solution)");
                Console.WriteLine("6. Timers (Solution)");
                Console.WriteLine("7. Delegates (Solution)");
                Console.WriteLine("8. WeakReference (Solution for Collections)");
                Console.WriteLine("9. ConditionalWeakTable");
                Console.WriteLine("10. Exit");

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
                        new EventLeakSolutionDemo().Run();
                        break;
                    case "6":
                        new TimerLeakSolutionDemo().Run();
                        break;
                    case "7":
                        new DelegateLeakSolutionDemo().Run();
                        break;
                    case "8":
                        new WeakReferenceDemo().Run();
                        break;
                    case "9":
                        new ConditionalWeakTableDemo().Run();
                        break;
                    case "10":
                        return;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }
    }
}
