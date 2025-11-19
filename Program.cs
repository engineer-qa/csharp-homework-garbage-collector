using csharp_homework_garbage_collector;

using (new ForeColor(ConsoleColor.Green))
{
    Console.WriteLine("###Starting Play Test Dispose");
}
PlayTestDispose.Test();
using (new ForeColor(ConsoleColor.Green))
{
    Console.WriteLine("###Starting Play Test Garbage Collector");
}
PlayTestGarbageCollector.Test();

using (new ForeColor(ConsoleColor.Green))
{
    Console.WriteLine("###Starting Shop Test Dispose");
}
ShopTestDispose.Test();
using (new ForeColor(ConsoleColor.Green))
{
    Console.WriteLine("###Starting Shop Test Garbage Collector");
}
ShopTestGarbageCollector.Test();