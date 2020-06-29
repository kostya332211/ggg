using System;
using System.Collections.Generic;
using System.Linq;
using PhonesBook.Core.Entities;
using PhonesBook.Core.Repositories;

namespace PhonesBookInfrastructure.JSON.Repositories
{
    class PersonRepository : IPersonRepository
    {
        private readonly PhonesBookContext _context;

        public PersonRepository(PhonesBookContext context)
        {
            _context = context;
        }

        public Person Get(Predicate<Person> predicate)
        {
            return _context.Persons.ToList().Find(predicate);
        }

        public IEnumerable<Person> All()
        {
            return _context.Persons;
        }

        public void Insert(Person entity)
        { 
            _context.Persons.Add(entity);
        }

        public void Delete(Predicate<Person> predicate)
        {

            _context.Persons.Remove(Get(predicate));
        }

    }
}
