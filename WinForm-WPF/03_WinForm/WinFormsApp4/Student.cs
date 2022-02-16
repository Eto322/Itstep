using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp4.Annotations;

namespace WinFormsApp4 
{
    [Serializable]
    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int Age { get; set; }
        public string Group { get; set; }

        public Student(string firstName, string lastName, int age, string group)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Group = group;
        }

        public Student()
        {

        }


        public override string ToString()
        {
            return  FirstName +" "+LastName+" " +Age + " "+Group;
        }


    }
}
