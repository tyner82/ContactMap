﻿using System;

namespace ContactMap3.Models
{
    public class Person
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public Address Address { get; set; }
        public string Phone { get; set; }
    }
}
