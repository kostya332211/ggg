using System.Collections.Generic;
using System.IO;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using PhonesBook.Core.Entities;

namespace PhonesBookInfrastructure.JSON
{
    class PhonesBookContext 
    {
        public List<Person> Persons { get; set; }

        public PhonesBookContext()
        {
            var text = File.ReadAllText(@"D:\LABS\PIS_SMELOV\LAB6\LABA3EF\LABA3\App_Data\PhoneBook.json");
            Persons = new List<Person>();
            var options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true,
                IgnoreNullValues = true
            };
            if (text != "")
            {
                Persons = JsonSerializer.Deserialize<List<Person>>(text, options);
            }

        }
    }
}
