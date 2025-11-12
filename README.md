# C# Memory Leak Demos

This project contains a C# console application with demos that intentionally create memory leaks for the following scenarios:

*   Events
*   Timers
*   Delegates
*   Collections

## Running the Demos

To run the demos, you can use the `dotnet run` command:

```bash
dotnet run --project MemoryLeakDemos
```

This will launch a menu where you can select which memory leak demo to run.

## Monitoring Memory Usage

To observe the memory leaks, you will need to use two separate terminals.

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
4.  After the demo is complete, the `gc-heap-size` will remain high and will not return to its original level. This indicates that memory has been allocated but is not being released by the garbage collector, which is the memory leak.
5.  You can stop the monitoring by pressing `Ctrl+C` in Terminal 2.
6.  You can stop the application by pressing `5` and then Enter in Terminal 1.
