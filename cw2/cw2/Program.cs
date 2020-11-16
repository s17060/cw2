using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Xml.Serialization;

namespace cw2
{
    class Program
    {
        static void Main(string[] args)
        {
            string inFile = "data.csv";
            string outFile = "result.xml";
            string dataType = "xml";
            try
            {
                if(args.Length == 3)
                {
                    inFile = args[0];
                    outFile = args[1];
                    dataType = args[2];
                }
            } catch(Exception e)
            {
                if(e is FormatException)
                {
                    logWrite("ArgumentException", "Podana sciezka jest niepoprawna");
                } else if(e is FileNotFoundException)
                {
                    logWrite("FileNotFoundException", "Plik nie istnieje");
                }
                
            }
            

            using (StreamReader reader = new StreamReader(inFile))
            using (CsvReader csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                Student student = new Student();
                csv.Configuration.HasHeaderRecord = false;
                List<Student> records = csv.GetRecords<Student>().ToList();
                
                if(dataType.Equals("xml"))
                {
                    FileStream writer = new FileStream(outFile, FileMode.Create);
                    XmlSerializer serializer = new XmlSerializer(typeof(List<Student>), new XmlRootAttribute("uczelnia"));
                    serializer.Serialize(writer, records);
                    writer.Close();
                } else if (dataType.Equals("json"))
                {
                    string jsonString = JsonSerializer.Serialize(records);
                    File.WriteAllText(outFile, jsonString);
                }
                
            }
        }

        public static void logWrite(string name, string desc)
        {
            string date = DateTime.Now.ToString(@"MM\/dd\/yyyy h\:mm tt");

            using (StreamWriter w = File.AppendText("log.txt"))
            {
                w.WriteLine(date + " " + name + ": " + desc);
            }
        }
    }
}
