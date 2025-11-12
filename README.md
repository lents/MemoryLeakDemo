# C# Memory Leak Demos and Solutions

This project contains a C# console application with demos that intentionally create memory leaks for common scenarios, as well as demos that show how to fix them.

## Demos

### Memory Leaks

*   **Events**: Demonstrates a memory leak caused by a long-lived object holding a reference to a short-lived object through an event subscription.
*   **Timers**: Demonstrates a memory leak caused by a timer that is not disposed.
*   **Delegates**: Demonstrates a memory leak caused by a delegate holding a reference to an object.
*   **Collections**: Demonstrates a memory leak caused by a collection that is not cleared.

### Solutions

*   **Events**: Shows how to fix the event memory leak by unsubscribing from the event, in this case by implementing `IDisposable`.
*   **Timers**: Shows how to fix the timer memory leak by properly disposing of the timer.
*   **Delegates**: Shows how to fix the delegate memory leak by unregistering the delegate.
*   **WeakReference**: Demonstrates how to use `WeakReference` to hold a reference to an object without preventing it from being garbage collected, which is a solution for the collection leak.
*   **ConditionalWeakTable**: Demonstrates how to use `ConditionalWeakTable` to associate data with an object without creating a strong reference.

## Running the Demos

To run the demos, you can use the `dotnet run` command:

```bash
dotnet run --project MemoryLeakDemos
```

This will launch a menu where you can select which memory leak demo or solution to run.

## Monitoring Memory Usage

To observe the memory leaks and see how the solutions fix them, you will need to use two separate terminals.

### Terminal 1: Run the Application

1.  Open a terminal and navigate to the root of the project.
2.  Run the application:
    ```bash
    dotnet run --project MemoryLeakDemos
    ```
3.  The application will start and display a menu.

### Terminal 2: Monitor Memory Usage

1.  Open a second terminal.
2.  Find the process ID (PID) of the running application:
    ```bash
    pgrep -f "MemoryLeakDemos/bin/Debug/net8.0/MemoryLeakDemos.dll"
    ```
    This command will output the PID of the application process.
3.  Use the `dotnet-counters` tool to monitor the garbage collection heap size (`gc-heap-size`). Replace `<PID>` with the process ID you found in the previous step:
    ```bash
    dotnet-counters monitor --process-id <PID> System.Runtime --counters gc-heap-size
    ```

### Interpreting the Output

1.  In Terminal 2, you will see the `gc-heap-size` reported every second.
2.  In Terminal 1, select one of the demos (e.g., press `4` for the Collections leak).
3.  Observe the `gc-heap-size` in Terminal 2. You should see it increase significantly.
4.  After the demo is complete, the `gc-heap-size` will remain high.
5.  Now, run the corresponding solution demo (e.g., press `8` for the `WeakReference` solution). You should see that the `gc-heap-size` does not increase significantly, or that it returns to a lower level after the demo completes and garbage collection runs.
6.  You can stop the monitoring by pressing `Ctrl+C` in Terminal 2.
7.  You can stop the application by pressing `10` and then Enter in Terminal 1.
