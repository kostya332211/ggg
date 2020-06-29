﻿using System;

namespace PhonesBook.Core.Entities
{
    public class Person : Entity<Guid>
    {
        public string PersonName { get; set; }

        public string PhoneNumber { get; set; }
    }

}
