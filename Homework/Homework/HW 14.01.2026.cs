using System;
using System.Diagnostics;

class MemoryAllocator : IDisposable
{
    private int[][] data;
    private bool disposed = false;

    public MemoryAllocator(int size)
    {
        // Allocate a large array of objects
        data = new int[size][];
        for (int i = 0; i < size; i++)
        {
            data[i] = new int[10];
        }
    }

    // Simulate active memory usage
    public void SimulateUsage(int iterations)
    {
        for (int i = 0; i < iterations; i++)
        {
            int[] temp = new int[100];
        }
    }

    public int GetObjectGeneration()
    {
        return GC.GetGeneration(data);
    }

    // Explicit resource release
    public void Dispose()
    {
        if (!disposed)
        {
            data = null;
            disposed = true;
            Console.WriteLine("Dispose() called: memory released manually.");
        }
        GC.SuppressFinalize(this);
    }

    // Destructor
    ~MemoryAllocator()
    {
        Console.WriteLine("Destructor called: MemoryAllocator finalized.");
    }
}

class Program
{
    static void RunTest(int dataSize)
    {
        Console.WriteLine("\n--- Test with data size: " + dataSize + " ---");

        Stopwatch sw = new Stopwatch();
        sw.Start();

        MemoryAllocator allocator = new MemoryAllocator(dataSize);
        Console.WriteLine("Initial generation: " + allocator.GetObjectGeneration());

        allocator.SimulateUsage(200_000);

        Console.WriteLine("Heap memory before GC: {0} bytes",
            GC.GetTotalMemory(false));

        // Force garbage collection
        GC.Collect();
        GC.WaitForPendingFinalizers();
        GC.Collect();

        Console.WriteLine("Heap memory after GC: {0} bytes",
            GC.GetTotalMemory(false));

        Console.WriteLine("Generation after GC: " +
            allocator.GetObjectGeneration());

        allocator.Dispose();
        allocator = null;

        GC.Collect();
        GC.WaitForPendingFinalizers();

        sw.Stop();
        Console.WriteLine("Execution time: {0} ms", sw.ElapsedMilliseconds);
    }

    static void Main()
    {
        RunTest(100_000);
        RunTest(500_000);
        RunTest(1_000_000);

        Console.WriteLine("\nProgram finished.");
    }
}
