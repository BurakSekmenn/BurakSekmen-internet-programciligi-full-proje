﻿namespace BurakSekmen.Core.Entity
{
    public class Person:BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public ICollection<Sales> Sales { get; set; }
        
    }
}
