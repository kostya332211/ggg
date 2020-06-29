using System.IO;
using PhonesBook.Core.Repositories;
using PhonesBookInfrastructure.JSON.Repositories;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace PhonesBookInfrastructure.JSON
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly PhonesBookContext _context;

        private IPersonRepository _personRepository;

        public IPersonRepository PersonRepository =>_personRepository ?? (_personRepository = new PersonRepository(_context));

        public UnitOfWork()
        {
            _context = new PhonesBookContext();
        }

        public void Dispose()
        {

        }

        public void Commit()
        {
            var options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true,
                IgnoreNullValues = true
            };

            var json = JsonSerializer.Serialize(PersonRepository.All(), options);
            File.WriteAllText(@"D:\LABS\PIS_SMELOV\LAB6\LABA3EF\LABA3\App_Data\PhoneBook.json", json);
        }
    }
}
