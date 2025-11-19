namespace csharp_homework_garbage_collector;

public class Play : IDisposable
{
    public string Name { get; set; }
    public string Author { get; set; }
    public string Janre { get; set; }
    public string Year { get; set; }

    public Play(string name, string author, string janre, string year)
    {
        Name = name;
        Author = author;
        Janre = janre;
        Year = year;
    }
    public void Dispose()
    {
        Console.WriteLine($"Play with name {Name} was disposed.");
    }
    ~Play()
    {
        Console.WriteLine($"Play with name {Name} was collected.");
    }
}

public class ForeColor : IDisposable
{
    private readonly ConsoleColor _previousColor;

    public ForeColor(ConsoleColor foreColor)
    {
        _previousColor = Console.ForegroundColor;
        Console.ForegroundColor = foreColor;
    }

    public void Dispose()
    {
        Console.ForegroundColor = _previousColor;
    }
}


public class PlayTestDispose
{
    public static void Test()
    {
        Play? play1 = null;
        try
        {
            play1 = new Play("Hamlet", "William Shakespeare", "Tragedy", "1603");
            Console.WriteLine($"GC before disposing - {GC.GetTotalMemory(true)}");
        }
        finally
        {
            play1?.Dispose();
            Console.WriteLine($"GC after disposing - {GC.GetTotalMemory(true)}");
        }
    }
}

public class PlayTestGarbageCollector
{
    public static void Test()
    {
        for (int i = 0; i < 5; i++)
        {
            Play play = new Play($"Play {i}", "Author", "Janre", "Year");
            Console.WriteLine($"GC before disposing - {GC.GetTotalMemory(true)}");
        }
        GC.Collect();
        GC.WaitForPendingFinalizers();
        Console.WriteLine($"GC after collecting - {GC.GetTotalMemory(true)}");
    }
}