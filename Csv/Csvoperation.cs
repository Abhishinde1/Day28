using CsvHelper;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Csv
{
    public class Csvoperation
    {
       
            public static void CsvSerialize()
            {
                Console.WriteLine("WelCome");
                Student s = new Student();

                string csvFilePath = @"C:\Users\Shree\Desktop\Day28\Csv\Data.csv";

                List<Student> students = new List<Student>()
            {
                new Student(){FName="Abhi",LName="jagtap",Address="Pune",ZipCode=411028},
                new Student(){FName="Harry",LName="doe",Address="Us",ZipCode=987654}
                };
                StreamWriter sw = new StreamWriter(csvFilePath);
                CsvWriter cw = new CsvWriter(sw, CultureInfo.InvariantCulture);

                cw.WriteRecords<Student>(students);
                sw.Close();
                Console.WriteLine("Closed");
            }

            public static void CsvDeserialize()
            {
                string csvFilePath = @"C:\Users\Shree\Desktop\Day28\Csv\Data.csv";

                StreamReader swReader = new StreamReader(csvFilePath);
                CsvReader csvReader = new CsvReader(swReader, CultureInfo.InvariantCulture);

                List<Student> students1 = csvReader.GetRecords<Student>().ToList();

                foreach (Student student in students1)
                {
                    Console.WriteLine(student);
                }
            
        }


        public class Student
        {
            public string FName { get; set; }
            public string LName { get; set; }
            public string Address { get; set; }
            public int ZipCode { get; set; }

            public override string ToString()
            {
                return $"{FName} {LName} {Address} {ZipCode}";
            }
        }
    }
}
