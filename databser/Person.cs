using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace databser
{
    internal class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public static List<Person> people = new List<Person>();

        public Person(int id, string name)
        {
            Id = id;
            Name = name;
        }

    }
}

    
