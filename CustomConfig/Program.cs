using System;
using System.IO;
using System.Threading.Tasks;

namespace CustomConfig
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // receives the config file name
            CustomConfig<MyConfig> config = new(Path.Combine(Environment.CurrentDirectory, args[0]));
            bool loaded = await config.LoadConfigAsync();
            Console.WriteLine($"Configuration loaded: {loaded}");
            Console.ReadKey();
        }
    }
}
