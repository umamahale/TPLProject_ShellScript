using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace TPLProjects
{
    class csvhandler
    {
        public static void ImplementCSVDataHandling()
        {
            string importfilePath = @"C:\Users\om\source\repos\TPLProjects\TPLProjects\Utility\address.csv";
            string exportfilePath = @"C:\Users\om\source\repos\TPLProjects\TPLProjects\Utility\export.csv";
            //reading csv file
            using(var reader = new StreamReader(importfilePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture)) 
            {
                var records = csv.GetRecords<AddressData>().ToList();
                Console.WriteLine("Read data successfuly from addresses.csv,here are city");
                foreach(AddressData addressData in records)
                {
                    Console.WriteLine("\t" + addressData.Firstname);
                    Console.WriteLine("\t" + addressData.Lastname);
                    Console.WriteLine("\t" + addressData.Address);
                    Console.WriteLine("\t" + addressData.City);
                    Console.WriteLine("\t" + addressData.State);
                    Console.WriteLine("\t" + addressData.Code);

                }
                Console.WriteLine("\n******Now reading from csv file and write to csv file******");
                // writing csv file
                using (var writer = new StreamWriter(exportfilePath))
                    using(var csvExport= new CsvWriter(writer,CultureInfo.InvariantCulture))
                {
                    csvExport.WriteRecords(records);
                }
            }
        }

           


        
    }
}
