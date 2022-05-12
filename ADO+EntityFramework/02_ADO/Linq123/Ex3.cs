using System;
using System.Collections.Generic;
using System.Linq;

namespace Linq123
{
    public class Ex3
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

        List<Department> departments = new List<Department>() { 
            new Department() { Id = 1, Country = "Ukraine", City = "Donetsk" }, 
            new Department() { Id = 2, Country = "Ukraine", City = "Kyiv" }, 
            new Department() { Id = 3, Country = "France", City = "Paris" }, 
            new Department() { Id = 4, Country = "Russia", City = "Moscow" } }; 
        List<Employee> employees = new List<Employee>()
        {
            new Employee() { Id = 1, FirstName = "Tamara", LastName = "Ivanova", Age = 22, DepId = 2 }, 
            new Employee() { Id = 2, FirstName = "Nikita", LastName = "Larin", Age = 33, DepId = 1 },
            new Employee() { Id = 3, FirstName = "Alica", LastName = "Ivanova", Age = 43, DepId = 3 }, 
            new Employee() { Id = 4, FirstName = "Lida", LastName = "Marusyk", Age = 22, DepId = 2 }, 
            new Employee() { Id = 5, FirstName = "Lida", LastName = "Voron", Age = 36, DepId = 4 },
            new Employee() { Id = 6, FirstName = "Ivan", LastName = "Kalyta", Age = 22, DepId = 2 }, 
            new Employee() { Id = 7, FirstName = "Nikita", LastName = "Krotov", Age = 27, DepId = 4 }
        };

        private void RunInUkraineAlpabetic()
        {
            var result = employees.Join(departments, e => e.DepId, d => d.Id,
                (e, d) => new { e.Id, e.FirstName, e.LastName, d.City, d.Country }).Where(e => e.Country == "Ukraine").OrderBy(e => e.FirstName);

            foreach (var employee in result)
            {
                Console.WriteLine("ID:{0} Name: {1} {2}, City: {3}, Country: {4}", employee.Id, employee.FirstName, employee.LastName, employee.City, employee.Country);
            }




        }

        private void RunSortbyAge()
        {
            var result = employees.OrderBy(x => x.Age).ToList();

            foreach (var employee in result)
            {
                Console.WriteLine("ID:{0} Name: {1} {2}, Age: {3}",employee.Id, employee.FirstName, employee.LastName, employee.Age);
            }
        }

        private void RunGroupbyAge()
        {

            var result = employees.GroupBy(x => x.Age).Select(x => new { Age = x.Key, Count = x.Count() });
            foreach (var employee in result)
            {
                Console.WriteLine("Age: {0}, Count: {1}", employee.Age, employee.Count);
            }

        }

        public void run()
        {
            Console.WriteLine("Live in ukraine Alpabetic sort by name");
            Console.WriteLine();
            RunInUkraineAlpabetic();

            Console.WriteLine("Sort by age");
            Console.WriteLine();
            RunSortbyAge();

            Console.WriteLine("age and count");
            Console.WriteLine();
            RunGroupbyAge();

        }
    }
}