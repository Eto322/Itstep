using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Linq123
{

    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string City { get; set; }
    }

    public class Ex1
    {
        List<Person> person = new List<Person>()
        {
            new Person() {Name = "Andrey", Age = 24, City = "Kyiv"},
            new Person() {Name = "Liza", Age = 18, City = "Moscow"},
            new Person() {Name = "Oleg", Age = 15, City = "London"},
            new Person() {Name = "Sergey", Age = 55, City = "Kyiv"},
            new Person() {Name = "Sergey", Age = 32, City = "Kyiv"}
        };

        private void RunOlder25()
        {

            var older25 = person.Where(x => x.Age > 25);
            
            foreach (var person in older25)
            {
                
                Console.WriteLine($"Name:{person.Name}, Age:{person.Age}, City:{person.City}");

            }
        }

        private List<Person> RunNotKyiv(bool check)
        {
            var notKyiv = person.Where(x => x.City != "Kyiv");

            if (check)
            {
                foreach (var person in notKyiv)
                {

                    Console.WriteLine($"Name:{person.Name}, Age:{person.Age}, City:{person.City}");

                }
            }
            

            return notKyiv.ToList();
        }

        private void RunNotKyivName(List<Person> personList)
        {
            var Names = personList.Select(x => x.Name);
            
           
                foreach (var name in Names)
                {

                Console.WriteLine(name);
            }
            
            
        }

        private void RunOlder35Sergey()
        {
            var Sergeys = person.Where(x => x.Name == "Sergey" && x.Age > 35);
            
            foreach (var person in Sergeys)
            {

                Console.WriteLine($"Name:{person.Name}, Age:{person.Age}, City:{person.City}");
            }
        }

        private void Runliveinmoskow()
        {
            var moskow = person.Where(x => x.City == "Moscow");
            
            foreach (var person in moskow)
            {

                Console.WriteLine($"Name:{person.Name}, Age:{person.Age}, City:{person.City}");
            }
        }

        public void run()
        {
            Console.WriteLine("Older 25");
            RunOlder25();
            
            Console.WriteLine();
            Console.WriteLine("Not Kyiv");
            RunNotKyiv(true);
            
            Console.WriteLine();
            Console.WriteLine("Not Kyiv Names");
            RunNotKyivName(RunNotKyiv(false));
            
            Console.WriteLine();
            Console.WriteLine("Older 35 Sergeys");
            RunOlder35Sergey();
            
            Console.WriteLine();
            Console.WriteLine("Moskalyaky na gilyaku");
            Runliveinmoskow();

        }

        
    }



}