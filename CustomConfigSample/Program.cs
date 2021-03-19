using System;
using System.IO;
using System.Threading.Tasks;
using CustomConfig;

namespace CustomConfigSample
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string Filename;
            
            // if no filename is received set a default one
            Filename = (args.Length == 0) ? "myconfig.json" : args[0];
            
            // create a new configuration object and load it
            CustomConfig<MyConfig> config = new(Path.Combine(Environment.CurrentDirectory, Filename));
            bool loaded = await config.LoadConfigAsync();
            Console.WriteLine($"Configuration loaded: {loaded}");

            config.Settings.Data.Add(new() { Filename = "test.dat", ApiEntryPoint = "api/test/uploadtest" });
            bool saved = await config.SaveConfigAsync();
            Console.WriteLine($"Configuration saved: {saved}");

            Console.ReadKey();
        }
    }
}
