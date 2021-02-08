using System;
using System.IO;
using ConfigLoader;

namespace ConfigLoaderTest
{ 
    class Program
    {
        private static ConfigLoader.ConfigLoader Loader;


        static void Main(string[] args)
        {
            Loader = new ConfigLoader.ConfigLoader(Path.Combine(Environment.CurrentDirectory, "configs", "test.cfg"));
            Loader.LoadConfig();
        }
    }
}
