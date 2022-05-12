using System;
using System.Collections.Generic;
using System.Linq;

namespace Linq123
{
    public class Ex2
    {
        class Employee
        {
            public int Id { get; set; } 
            public string FirstName { get; set; } 
            public string LastName { get; set; } 
            public int Age { get; set; } 
            public int DepId { get; set; }
        }

        class Department
        {
            public int Id { get; set; } 
            public string Country { get; set; } 
            public string City { get; set; }
        }
       
        
        List<Department> departments = new List<Department>()
        {
                    new Department() { Id = 1, Country = "Ukraine", City = "Donetsk" },
                    new Department() { Id = 2, Country = "Ukraine", City = "Kyiv" }, 
                    new Department() { Id = 3, Country = "France", City = "Paris" }, 
                    new Department() { Id = 4, Country = "Russia", City = "Moscow" }
        }; 
        
        List<Employee> employees = new List<Employee>()
        {
                    new Employee() { Id = 1, FirstName = "Tamara", LastName = "Ivanova", Age = 22, DepId = 2 },
                    new Employee() { Id = 2, FirstName = "Nikita", LastName = "Larin", Age = 33, DepId = 1 },
                    new Employee() { Id = 3, FirstName = "Alica", LastName = "Ivanova", Age = 43, DepId = 3 }, 
                    new Employee() { Id = 4, FirstName = "Lida", LastName = "Marusyk", Age = 22, DepId = 2 }, 
                    new Employee() { Id = 5, FirstName = "Lida", LastName = "Voron", Age = 36, DepId = 4 },
                    new Employee() { Id = 6, FirstName = "Ivan", LastName = "Kalyta", Age = 22, DepId = 2 }, 
                    new Employee() { Id = 7, FirstName = "Nikita", LastName = " Krotov ", Age = 27, DepId = 4 }
        };

        private void RunNotDonetsk()
        {

            var result = employees.Where(x => x.DepId 
                                                    != departments.Where(x => x.City == "Donetsk")
                                                    .Select(x => x.Id).FirstOrDefault());

            foreach (var employee in result)
            {
                Console.WriteLine("{0} {1}", employee.FirstName, employee.LastName);
            }
            Console.WriteLine();
        }

        private void UniqueCountry()
        {
            var result = departments.Select(x => x.Country).Distinct();
            foreach (var country in result)
            {
                Console.WriteLine(country);
            }
        }

        private void FirstThree25()
        {
            var result = employees.Where(x => x.Age > 25).Take(3);


            

            foreach (var employee in result)
            {
                Console.WriteLine("Name: {0} {1}, Age: {2}", employee.FirstName, employee.LastName, employee.Age);
            }
        }

        private void FromKyiev()
        {
            var result = employees.Where(x =>x.Age>23 && 
                                                    x.DepId == departments
                                                    .Where(x => x.City == "Kyiv")
                                                    .Select(x => x.Id).FirstOrDefault());
            foreach (var employee in result)
            {
                Console.WriteLine("Name: {0} {1}, Age: {2}", employee.FirstName, employee.LastName, employee.Age);
            }

        }

        public void run()
        {
            Console.WriteLine("Not from Donetsk");
            Console.WriteLine();
            RunNotDonetsk();

            Console.WriteLine("Unique country");
            Console.WriteLine();
            UniqueCountry();

            Console.WriteLine("First three employees over 25");
            Console.WriteLine();
            FirstThree25();

            Console.WriteLine("Employees from Kyiv");
            Console.WriteLine();
            FromKyiev();
        }
    }
}