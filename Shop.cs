namespace csharp_homework_garbage_collector
{
    public class Shop : IDisposable
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Type { get; set; }

        public Shop(string name, string address, string type)
        {
            Name = name;
            Address = address;
            Type = type;
        }

        public void Dispose()
        {
            Console.WriteLine($"Shop with name {Name} was disposed.");
        }

        ~Shop()
        {
            Console.WriteLine($"Shop with name {Name} was collected.");
        }
    }

    public class ShopTestDispose
    {
        public static void Test()
        {
            Shop? shop1 = null;
            try
            {
                shop1 = new Shop("Corner Store", "123 Main St", "Grocery");
                Console.WriteLine($"GC before disposing - {GC.GetTotalMemory(true)}");
            }
            finally
            {
                shop1?.Dispose();
                Console.WriteLine($"GC after disposing - {GC.GetTotalMemory(true)}");
            }
        }
    }

    public class ShopTestGarbageCollector
    {
        public static void Test()
        {
            for (int i = 0; i < 5; i++)
            {
                Shop shop = new Shop($"Shop {i}", "Address", "Type");
                Console.WriteLine($"GC before disposing - {GC.GetTotalMemory(true)}");
            }
            GC.Collect();
            GC.WaitForPendingFinalizers();
            Console.WriteLine($"GC after disposing - {GC.GetTotalMemory(true)}");
        }
    }
}
