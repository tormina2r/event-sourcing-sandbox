﻿using System;

namespace EventSourcing.BusinessLogic.Models
{
    [Serializable]
    public class Person
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
