using CsvHelper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace TPLProjects
{
    class ReadCSV_And_WriteJSON
    {
        public static void ImplementCSVToJSON()
        {
            string importfilePath = @"C:\Users\om\source\repos\TPLProjects\TPLProjects\Utility\address.csv";
            string exportfilePath = @"C:\Users\om\source\repos\TPLProjects\TPLProjects\Utility\export.csv";
            // reading csv file
            using(var reader= new StreamReader(importfilePath))
                using(var csv= new CsvReader(reader,CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<AddressData>().ToList();
                Console.WriteLine("Read data succeccfully from address.csv, here are codes");
                foreach(AddressData addressData in records)
                {
                    Console.WriteLine("\t" + addressData.Code);
                }
                Console.WriteLine("\n*************Now reading from csv files and write to json file");
                // write data to json file
                JsonSerializer serializer = new JsonSerializer();
                using(StreamWriter sw = new StreamWriter(exportfilePath))
                    using(JsonWriter writer = new JsonTextWriter(sw))
                {
                    serializer.Serialize(writer, records);
                }
            }
                                                                                   
        }
    }
}
