using System;

namespace TPLProjects
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("# Read data from CSV & Write data in CSV");
            // read,write Operation of csv files
            csvhandler.ImplementCSVDataHandling();
            Console.WriteLine();
        }
    }
}
