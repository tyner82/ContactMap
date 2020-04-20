using System;
using ContactMap3.ViewModels;

namespace ContactMap3.Models
{
    public class Person
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string FirstName { get
            {
                return Name.Split(' ')[0];
            }
        }
        public string LastName {
            get
            {
                string[] result = Name.Split(' ');
                if (result.Length > 1)
                    return result[result.Length-1];
                return " ";
            }
        }
        public Address Address { get; set; }
        public string Phone { get; set; }
        public bool HasActions { get; set; }
        private string _initials;
        public string Initials
        {
            get
            {

                return $"{FirstName[0]}{LastName[0]}".ToUpper();
            }
        }

        public Person()
        {
            Console.WriteLine($"Person Constructor FullName:");// {Name}");
            //this.Initials = "";
        }

        public override string ToString()
        {

            return $"{Name} {Phone}";
        }
    }
}
